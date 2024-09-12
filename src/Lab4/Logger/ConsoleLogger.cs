using System;

namespace ObjectOrientedProgramming.Lab4.Logger;

public class ConsoleLogger : ILoggable
{
    public void Log(string? log)
    {
        Console.WriteLine(log);
    }
}