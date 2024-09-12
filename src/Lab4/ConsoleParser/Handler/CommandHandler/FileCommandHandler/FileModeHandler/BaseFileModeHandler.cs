namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.FileCommandHandler.FileModeHandler;

public abstract class BaseFileModeHandler : BaseFileCommandHandler
{
    protected BaseFileModeHandler(BaseFileModeHandler? nextKey)
        : base(nextKey)
    {
    }
}