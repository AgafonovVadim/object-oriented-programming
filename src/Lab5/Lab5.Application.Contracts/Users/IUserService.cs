using Lab5.Application.Models.Users;

namespace Lab5.Application.Contracts.Users;

public interface IUserService
{
    LoginResult Login(string username, int accountNumber, int pinCode);
    SignUpResult AddUser(string username, int pinCode, UserRole role);

    Task<string?> GetAllTransactions(string username);
}