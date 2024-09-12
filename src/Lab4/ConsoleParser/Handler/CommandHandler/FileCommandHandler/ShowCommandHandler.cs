using System;
using System.IO;
using ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.FileCommandHandler.FileKeyHandler;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.FileCommandHandler;

public class ShowCommandHandler : BaseFileCommandHandler
{
    public ShowCommandHandler(BaseFileCommandHandler? nextCommand)
        : base(nextCommand)
    {
    }

    public override string? Handle(string[]? command)
    {
        if (command == null || !command[1].Equals("show", StringComparison.Ordinal)) return CallNext(command);

        if (command.Length > 3)
        {
            var consoleMode = new MFileKeyHandler();
            return consoleMode.Handle(command);
        }

        return Path is not null ? File.ReadAllText(Path) : NextHandle?.Handle(command);
    }
}