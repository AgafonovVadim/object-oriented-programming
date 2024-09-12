using System;

namespace ObjectOrientedProgramming.Lab4.CustomExceptions;

public class PathIsNotReadableException : Exception
{
    public PathIsNotReadableException(string message)
        : base(message)
    {
    }

    public PathIsNotReadableException()
    {
    }

    public PathIsNotReadableException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}