using System.Data;
using Dev.Platform.Postgres.Connection;
using Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Transactions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<string?> GetAllTransactions(string username)
    {
        const string sql = """
                           select *
                           from transactions
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
        List<Transaction> transactionsList = new();

        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            transactionsList.Add(new Transaction(
                Id: reader.GetInt64(0),
                UserId: reader.GetInt64(1),
                Type: await reader.GetFieldValueAsync<TransactioinType>(2).ConfigureAwait(false),
                Amount: reader.GetInt32(3)));
        }

        return transactionsList.ToString();
    }

    public async void AddTransaction(long userId, TransactioinType type, int amount)
    {
        const string sql = """
                                        INSERT INTO transactions(user_id, transaction_type, transaction_amount)
                                        VALUES (@user_id, @type, @amount);
                                       """;
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("user_id", userId);
        command.AddParameter("type", type);
        command.AddParameter("amount", amount);
        await command.ExecuteScalarAsync().ConfigureAwait(false);
    }
}