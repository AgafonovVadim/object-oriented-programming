using System.Data;
using System.Net.NetworkInformation;
using Dev.Platform.Postgres.Connection;
using Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Users;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User> FindUserByUsername(string username)
    {
        const string sql = """
        select user_id, user_name, user_role, user_account_number, user_account_pin
        from users
        where user_name = :username;
        """;
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            throw new DataException();

        return new User(
            Id: reader.GetInt64(0),
            Username: reader.GetString(1),
            UserRole: await reader.GetFieldValueAsync<UserRole>(2).ConfigureAwait(false),
            AccountNumber: reader.GetInt32(3),
            PinCode: reader.GetInt32(4));
    }

    public async Task<bool> AddUser(string username, int pinCode, UserRole role)
    {
        const string userCreationSql = """
                               INSERT INTO users(user_name, user_role, user_account_pin)
                               VALUES (@username, @role, @pin)
                               RETURNING user_id;
                               """;

        const string accountCreationSql = """
                                       INSERT INTO accounts(user_id, balance)
                                       VALUES (@user_id, 0)
                                       RETURNING account_id;
                                       """;
        const string updateUserAccount = """
                                         UPDATE users 
                                         SET user_account_number = @user_account_number 
                                         WHERE user_id = @user_id
                                         """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(false);
        if (FindUserByUsername(username) is not null)
        {
            return false;
        }

        using var userCreationCommand = new NpgsqlCommand(userCreationSql, connection);

        userCreationCommand.AddParameter("username", username);
        userCreationCommand.AddParameter("role", role);
        userCreationCommand.AddParameter("pin", pinCode);

        long userId = (long)(await userCreationCommand.ExecuteScalarAsync().ConfigureAwait(false) ?? -1);
        if (userId == -1)
            throw new PingException("Some database problems, use terminal later");
        using var accountCreationCommand = new NpgsqlCommand(accountCreationSql, connection);
        accountCreationCommand.AddParameter("user_id", userId);
        int accountNumber = await accountCreationCommand.ExecuteNonQueryAsync().ConfigureAwait(false);

        using var updateUserAccountCommand = new NpgsqlCommand(updateUserAccount, connection);

        updateUserAccountCommand.AddParameter("user_account_number", accountNumber);
        updateUserAccountCommand.AddParameter("user_id", userId);
        await updateUserAccountCommand.ExecuteNonQueryAsync().ConfigureAwait(false);
        return true;
    }
}
