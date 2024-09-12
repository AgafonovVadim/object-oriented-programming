namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.FileCommandHandler;

public abstract class BaseFileCommandHandler : BaseCommandHandler
{
    protected BaseFileCommandHandler(BaseFileCommandHandler? nextCommand = null)
        : base(nextCommand)
    {
    }
}