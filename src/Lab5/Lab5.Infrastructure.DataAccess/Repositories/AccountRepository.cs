using System.Data;
using Dev.Platform.Postgres.Connection;
using Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Accounts;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<Account> GetUserAccount(string username)
    {
        const string sql = """
                           select *
                           from accounts
                           where user_id == (select user_id
                           from users
                           where user_name = :username)
                           """;
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);

        using NpgsqlDataReader reader = await command
            .ExecuteReaderAsync()
            .ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            throw new DataException();

        return new Account(
            Id: reader.GetInt64(0),
            UserId: reader.GetInt64(1),
            Balance: reader.GetInt64(2));
    }

    public async void UpdateAccountBalance(long userId, long newBalance)
    {
        const string sql = """
                           update accounts
                           set balance = @newBalance
                           where user_id = @userId;
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("newBalance", newBalance);
        command.AddParameter("userId", userId);
        await command.ExecuteScalarAsync().ConfigureAwait(false);
    }
}