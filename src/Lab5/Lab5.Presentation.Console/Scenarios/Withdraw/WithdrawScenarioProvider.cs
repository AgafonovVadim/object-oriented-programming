using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios.Withdraw;

public class WithdrawScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;
    private readonly ICurrentUserService _currentUser;

    public WithdrawScenarioProvider(
        IAccountService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new WithdrawScenario(_service);
        return true;
    }
}