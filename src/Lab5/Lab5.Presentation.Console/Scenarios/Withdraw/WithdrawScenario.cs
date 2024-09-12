using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Withdraw;

public class WithdrawScenario : IScenario
{
    private readonly IAccountService _accountService;

    public WithdrawScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Withdraw";

    public void Run()
    {
        int deposit = AnsiConsole.Ask<int>("Enter amount of withdrawal");
        OperationResult result = _accountService.Withdraw(deposit);

        string message = result switch
        {
            OperationResult.Success => "Successful withdraw",
            OperationResult.Fail => "Not enough money",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}