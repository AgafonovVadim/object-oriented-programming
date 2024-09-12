using System.ComponentModel.Design;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly CurrentUserManager _currentUserManager;
    private readonly ITransactionRepository _transactionRepository;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager, ITransactionRepository transactionRepository)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
        _transactionRepository = transactionRepository;
    }

    public LoginResult Login(string username, int accountNumber, int pinCode)
    {
        Task<User> user = _repository.FindUserByUsername(username);

        if (user is null)
        {
            return LoginResult.NotFound;
        }

        if (user.Result.AccountNumber != accountNumber || user.Result.PinCode != pinCode)
            throw new CheckoutException("Incorrect Account number or pin-code");

        _currentUserManager.User = user.Result;
        return LoginResult.Success;
    }

    public SignUpResult AddUser(string username, int pinCode, UserRole role) => _repository.AddUser(username, pinCode, role).Result ? SignUpResult.Success : SignUpResult.AccountAlreadyExists;
    public Task<string?> GetAllTransactions(string username)
    {
        return _transactionRepository.GetAllTransactions(username);
    }
}