namespace ObjectOrientedProgramming.Lab4.CustomExceptions;

public class InvalidKeyException : System.Exception
{
    public InvalidKeyException(string message)
        : base(message)
    {
    }

    public InvalidKeyException()
    {
    }

    public InvalidKeyException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}