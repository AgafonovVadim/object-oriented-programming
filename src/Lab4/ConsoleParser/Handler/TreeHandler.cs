using System;
using ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.TreeCommandHandler;
using ObjectOrientedProgramming.Lab4.TreePrinter;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler;

public class TreeHandler : BaseCommandHandler
{
    public TreeHandler(BaseCommandHandler? nextHandler, AbstractTreePrinter? treePrinter)
        : base(nextHandler, treePrinter)
    {
    }

    public override string? Handle(string[]? command)
    {
        if (command is null || !command[0].Equals("tree", StringComparison.Ordinal)) return CallNext(command);
        BaseTreeCommandHandler gotoCommandHandler = new GoToCommandHandler();
        BaseTreeCommandHandler listCommandHandler = new ListCommandHandler(gotoCommandHandler, TreePrinter);
        return listCommandHandler.Handle(command);
    }
}