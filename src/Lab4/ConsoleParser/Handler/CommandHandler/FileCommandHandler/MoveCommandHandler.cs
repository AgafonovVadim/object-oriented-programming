using System;
using System.IO;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.FileCommandHandler;

public class MoveCommandHandler : BaseFileCommandHandler
{
    public MoveCommandHandler(BaseFileCommandHandler? nextCommand)
        : base(nextCommand)
    {
    }

    public override string? Handle(string[]? command)
    {
        if (command == null || !command[1].Equals("move", StringComparison.Ordinal)) return CallNext(command);

        string sourcePath = GetFullPath(command[2]);
        string destinationPath = GetFullPath(command[3]);
        File.Move(sourcePath, destinationPath);
        return "File was successfully moved";
    }
}