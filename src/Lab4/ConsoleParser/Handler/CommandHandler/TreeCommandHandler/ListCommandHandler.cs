using System;
using ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.TreeCommandHandler.TreeModeHandler;
using ObjectOrientedProgramming.Lab4.TreePrinter;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.TreeCommandHandler;

public class ListCommandHandler : BaseTreeCommandHandler
{
    public ListCommandHandler(BaseTreeCommandHandler? nextCommand = null, AbstractTreePrinter? treePrinter = null)
        : base(nextCommand, treePrinter)
    {
    }

    public override string? Handle(string[]? command)
    {
        if (command == null || !command[1].Equals("list", StringComparison.Ordinal)) return CallNext(command);

        if (command.Length > 3)
        {
            var consoleMode = new ConsoleTreeModeHandler(null, TreePrinter);
            return consoleMode.Handle(command);
        }

        return Path is not null ? TreePrinter?.Print(GetFullPath(Path)) : NextHandle?.Handle(command);
    }
}