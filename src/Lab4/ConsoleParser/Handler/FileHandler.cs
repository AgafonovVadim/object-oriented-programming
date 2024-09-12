using System;
using ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.FileCommandHandler;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler;

public class FileHandler : BaseCommandHandler
{
    public FileHandler(BaseCommandHandler? nextHandler = null)
        : base(nextHandler)
    {
    }

    public override string? Handle(string[]? command)
    {
        if (command is null || !command[0].Equals("file", StringComparison.Ordinal)) CallNext(command);
        BaseFileCommandHandler copyFileHandler = new CopyCommandHandler();
        BaseFileCommandHandler deleteFileHandler = new CopyCommandHandler(copyFileHandler);
        BaseFileCommandHandler moveFileHandler = new CopyCommandHandler(deleteFileHandler);
        BaseFileCommandHandler renameFileHandler = new CopyCommandHandler(moveFileHandler);
        BaseFileCommandHandler showFileHandler = new CopyCommandHandler(renameFileHandler);
        return showFileHandler.Handle(command);
    }
}