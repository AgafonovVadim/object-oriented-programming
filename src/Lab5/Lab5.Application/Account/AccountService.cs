using System.Data;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Account;

public class AccountService : IAccountService
{
    private readonly ICurrentUserService _currentUser;
    private readonly IAccountRepository _repository;
    private readonly ITransactionRepository _transactions;

    public AccountService(ICurrentUserService currentUser, IAccountRepository repository, ITransactionRepository transactions)
    {
        _currentUser = currentUser;
        _repository = repository;
        _transactions = transactions;
    }

    public OperationResult Withdraw(int amount)
    {
        if (_currentUser.User is not null)
        {
            Models.Accounts.Account account = _repository.GetUserAccount(_currentUser.User.Username).Result;
            if (account.Balance >= amount)
            {
                _repository.UpdateAccountBalance(_currentUser.User.Id, account.Balance - amount);
                _transactions.AddTransaction(_currentUser.User.Id, TransactioinType.Withdrawal, amount);
                return OperationResult.Success;
            }

            return OperationResult.Fail;
        }

        throw new DataException("User doesnt log in");
    }

    public OperationResult Deposit(int amount)
    {
        if (_currentUser.User is not null)
        {
            Models.Accounts.Account account = _repository.GetUserAccount(_currentUser.User.Username).Result;
            _repository.UpdateAccountBalance(_currentUser.User.Id, account.Balance + amount);
            _transactions.AddTransaction(_currentUser.User.Id, TransactioinType.Withdrawal, amount);
            return OperationResult.Success;
        }

        throw new DataException("User doesnt log in");
    }
}