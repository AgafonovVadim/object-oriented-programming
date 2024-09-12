using System;
using ObjectOrientedProgramming.Lab4.CustomExceptions;
using ObjectOrientedProgramming.Lab4.TreePrinter;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.TreeCommandHandler.TreeModeHandler;

public class ConsoleTreeModeHandler : BaseTreeModeHandler
{
    public ConsoleTreeModeHandler(BaseTreeModeHandler? nextMode, AbstractTreePrinter? treePrinter)
        : base(nextMode, treePrinter)
    {
    }

    public override string? Handle(string[]? command)
    {
        if (command is null || !command[2].Equals("-d", StringComparison.Ordinal)) return CallNext(command);
        int deep = int.Parse(command[3], null);
        if (Path != null) return TreePrinter?.Print(GetFullPath(Path), deep);
        throw new PathIsNotReadableException();
    }
}