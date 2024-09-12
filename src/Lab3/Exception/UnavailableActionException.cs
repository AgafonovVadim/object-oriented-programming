namespace ObjectOrientedProgramming.Lab3.Exception;

public class UnavailableActionException : System.Exception
{
    public UnavailableActionException(string message)
        : base(message)
    {
    }

    public UnavailableActionException()
    {
    }

    public UnavailableActionException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}