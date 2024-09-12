namespace ObjectOrientedProgramming.Lab4.CustomExceptions;

public class UnsupportedCommandException : System.Exception
{
    public UnsupportedCommandException(string message)
        : base(message)
    {
    }

    public UnsupportedCommandException()
    {
    }

    public UnsupportedCommandException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}