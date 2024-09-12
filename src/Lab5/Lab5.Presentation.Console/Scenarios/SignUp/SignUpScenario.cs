using System.Security.Authentication;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.SignUp;

public class SignUpScenario : IScenario
{
    private readonly IUserService _userService;

    public SignUpScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "SignUp";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");
        int pin = AnsiConsole.Ask<int>("Enter your pin-code");
        string userRole = AnsiConsole.Ask<string>("Enter your role");

        if (!Enum.TryParse(userRole, true, out UserRole role))
            throw new AuthenticationException("Invalid role");
        SignUpResult result = _userService.AddUser(username, pin, role);

        string message = result switch
        {
            SignUpResult.Success => "Successfully signed up",
            SignUpResult.AccountAlreadyExists => "User already exists",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Login to start work.");
    }
}