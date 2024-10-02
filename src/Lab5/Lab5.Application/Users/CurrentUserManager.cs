using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Users;

internal class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
}