using System;
using System.IO;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.FileCommandHandler;

public class DeleteCommandHandler : BaseFileCommandHandler
{
    public DeleteCommandHandler(BaseFileCommandHandler? nextCommand)
        : base(nextCommand)
    {
    }

    public override string? Handle(string[]? command)
    {
        if (command == null || !command[1].Equals("delete", StringComparison.Ordinal)) return CallNext(command);

        string deletePath = GetFullPath(command[2]);
        File.Delete(deletePath);
        return "File was successfully deleted";
    }
}