using System;
using System.IO;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.FileCommandHandler;

public class CopyCommandHandler : BaseFileCommandHandler
{
    public CopyCommandHandler(BaseFileCommandHandler? nextCommand = null)
        : base(nextCommand)
    {
    }

    public override string? Handle(string[]? command)
    {
        if (command is null || !command[1].Equals("copy", StringComparison.Ordinal)) return CallNext(command);

        string sourcePathCopy = GetFullPath(command[2]);
        string destinationPathCopy = GetFullPath(command[3]);
        File.Copy(sourcePathCopy, destinationPathCopy);
        return "File was successfully copied";
    }
}