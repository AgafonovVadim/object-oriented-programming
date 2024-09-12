using System;
using ObjectOrientedProgramming.Lab4.TreePrinter;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler;

public class DisconnectHandler : BaseCommandHandler
{
    public DisconnectHandler(BaseCommandHandler? nextHandler, AbstractTreePrinter? treePrinter)
        : base(nextHandler, treePrinter)
    {
    }

    public override string? Handle(string[]? command)
    {
        if (command is null || !command[0].Equals("disconnect", StringComparison.Ordinal)) return CallNext(command);
        Path = string.Empty;
        return "Disconnect was successful";
    }
}