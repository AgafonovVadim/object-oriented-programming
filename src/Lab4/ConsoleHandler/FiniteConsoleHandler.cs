using System.IO;

namespace ObjectOrientedProgramming.Lab4.ConsoleHandler;

public class FiniteConsoleHandler : AbstractHandler
{
    public FiniteConsoleHandler(StreamReader? reader = null)
        : base(reader)
    {
    }
}