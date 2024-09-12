using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task<User> FindUserByUsername(string username);
    Task<bool> AddUser(string username, int pinCode, UserRole role);
}