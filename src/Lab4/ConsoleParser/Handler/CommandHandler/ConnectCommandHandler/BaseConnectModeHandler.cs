namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.ConnectCommandHandler;

public abstract class BaseConnectModeHandler : BaseCommandHandler
{
    protected BaseConnectModeHandler(BaseConnectModeHandler? nextMode = null)
        : base(nextMode)
    {
    }
}