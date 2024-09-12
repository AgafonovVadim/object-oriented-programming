using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    Task<Account> GetUserAccount(string username);
    void UpdateAccountBalance(long userId, long newBalance);
}