// using Lab5.Presentation.Console.Scenarios.Deposit;

using Lab5.Presentation.Console.Scenarios.Deposit;
using Lab5.Presentation.Console.Scenarios.Login;
using Lab5.Presentation.Console.Scenarios.SignUp;
using Lab5.Presentation.Console.Scenarios.Transactions;
using Lab5.Presentation.Console.Scenarios.Withdraw;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, SignUpScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawScenarioProvider>();
        collection.AddScoped<IScenarioProvider, TransactionsHistoryScenarioProvider>();

        return collection;
    }
}