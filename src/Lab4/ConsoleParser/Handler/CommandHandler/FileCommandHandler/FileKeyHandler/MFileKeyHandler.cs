using System;
using ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.FileCommandHandler.FileModeHandler;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.FileCommandHandler.FileKeyHandler;

public class MFileKeyHandler : BaseFileKeyHandler
{
    public MFileKeyHandler(BaseFileKeyHandler? nextKey = null)
        : base(nextKey)
    {
    }

    public override string? Handle(string[]? command)
    {
        if (command != null && command[2].Equals("-m", StringComparison.Ordinal))
        {
            var consoleMode = new ConsoleFileModeHandler();
            return consoleMode.Handle(command);
        }

        return CallNext(command);
    }
}