namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.FileCommandHandler.FileKeyHandler;

public abstract class BaseFileKeyHandler : BaseFileCommandHandler
{
    protected BaseFileKeyHandler(BaseFileKeyHandler? nextKey)
        : base(nextKey)
    {
    }
}