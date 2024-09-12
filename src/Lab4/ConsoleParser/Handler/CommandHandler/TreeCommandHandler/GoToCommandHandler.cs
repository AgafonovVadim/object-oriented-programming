using System;
using ObjectOrientedProgramming.Lab4.TreePrinter;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.TreeCommandHandler;

public class GoToCommandHandler : BaseTreeCommandHandler
{
    public GoToCommandHandler(BaseTreeCommandHandler? nextCommand = null, AbstractTreePrinter? treePrinter = null)
        : base(nextCommand, treePrinter)
    {
    }

    public override string? Handle(string[]? command)
    {
        if (command == null || !command[1].Equals("goto", StringComparison.Ordinal)) return CallNext(command);
        Path = GetFullPath(command[2]);
        return "GoTo was successfully done";
    }
}