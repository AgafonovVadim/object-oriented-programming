using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Abstractions.Repositories;

public interface ITransactionRepository
{
    Task<string?> GetAllTransactions(string username);
    void AddTransaction(long userId, TransactioinType type, int amount);
}