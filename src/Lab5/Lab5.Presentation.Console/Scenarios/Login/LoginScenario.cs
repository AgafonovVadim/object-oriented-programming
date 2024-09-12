using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");
        int accountNumber = AnsiConsole.Ask<int>("Enter your account number");
        int pin = AnsiConsole.Ask<int>("Enter your pin-code");

        LoginResult result = _userService.Login(username, accountNumber, pin);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}