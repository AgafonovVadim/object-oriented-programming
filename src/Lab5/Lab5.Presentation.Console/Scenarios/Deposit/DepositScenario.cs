using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Deposit;

public class DepositScenario : IScenario
{
    private readonly IAccountService _accountService;

    public DepositScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Deposit";

    public void Run()
    {
        int deposit = AnsiConsole.Ask<int>("Enter amount of deposit");
        _accountService.Deposit(deposit);
        AnsiConsole.Ask<string>("Ok");
    }
}