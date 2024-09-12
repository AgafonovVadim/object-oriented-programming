using System;
using ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.ConnectCommandHandler;
using ObjectOrientedProgramming.Lab4.TreePrinter;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler;

public class ConnectHandler : BaseCommandHandler
{
    public ConnectHandler(BaseCommandHandler? nextHandler, AbstractTreePrinter? treePrinter)
        : base(nextHandler, treePrinter)
    {
    }

    public override string? Handle(string[]? command)
    {
        if (command is null || !command[0].Equals("connect", StringComparison.Ordinal))
            return NextHandle?.Handle(command);
        BaseConnectModeHandler localModeHandler = new LocalConnectModeHandler();
        return localModeHandler.Handle(command);
    }
}