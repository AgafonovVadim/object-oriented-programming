using System;

namespace ObjectOrientedProgramming.Lab3.Logger;

public class ConsoleLogger : ILoggable
{
    public void Log(string log)
    {
        Console.WriteLine(log);
    }
}