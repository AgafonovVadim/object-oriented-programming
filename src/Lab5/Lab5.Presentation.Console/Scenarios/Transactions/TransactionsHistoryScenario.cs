using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Transactions;

public class TransactionsHistoryScenario : IScenario
{
    private readonly ICurrentUserService _userService;
    private readonly IUserService _service;

    public TransactionsHistoryScenario(ICurrentUserService userService, IUserService service)
    {
        _userService = userService;
        _service = service;
    }

    public string Name => "Get Transactions history";

    public void Run()
    {
        if (_userService.User != null && _userService.User.Username != null)
            AnsiConsole.WriteLine(_service.GetAllTransactions(_userService.User.Username).Result ?? "no transactions");
        AnsiConsole.Ask<string>("Ok");
    }
}