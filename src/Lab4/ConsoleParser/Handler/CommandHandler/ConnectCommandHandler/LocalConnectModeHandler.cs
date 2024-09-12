using System;
using ObjectOrientedProgramming.Lab4.CustomExceptions;

namespace ObjectOrientedProgramming.Lab4.ConsoleParser.Handler.CommandHandler.ConnectCommandHandler;

public class LocalConnectModeHandler : BaseConnectModeHandler
{
    public LocalConnectModeHandler(BaseConnectModeHandler? nextMode = null)
        : base(nextMode)
    {
    }

    public override string? Handle(string[]? command)
    {
        if (command is null || !command[2].Equals("-m", StringComparison.Ordinal))
            throw new InvalidKeyException();
        if (command[3].Equals("local", StringComparison.Ordinal))
        {
            Path = GetFullPath(command[1]);
            return "The new connection was successful";
        }

        throw new InvalidModeException();
    }
}