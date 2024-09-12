using System;
using System.IO;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.FileCommandHandler.FileModeHandler;

public class ConsoleFileModeHandler : BaseFileModeHandler
{
    public ConsoleFileModeHandler(BaseFileModeHandler? nextKey = null)
        : base(nextKey)
    {
    }

    public override string? Handle(string[]? command)
    {
        if (command is not null && command[3].Equals("console", StringComparison.Ordinal))
        {
            if (Path != null) return File.ReadAllText(Path);
        }

        return CallNext(command);
    }
}