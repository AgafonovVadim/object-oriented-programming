namespace Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    OperationResult Withdraw(int amount);
    OperationResult Deposit(int amount);
}