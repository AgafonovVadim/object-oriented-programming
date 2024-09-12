namespace ObjectOrientedProgramming.Lab4.CustomExceptions;

public class InvalidModeException : System.Exception
{
    public InvalidModeException(string message)
        : base(message)
    {
    }

    public InvalidModeException()
    {
    }

    public InvalidModeException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}