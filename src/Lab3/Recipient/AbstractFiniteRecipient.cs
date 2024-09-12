using ObjectOrientedProgramming.Lab3.Mail;

namespace ObjectOrientedProgramming.Lab3.Recipient;

public abstract class AbstractFiniteRecipient : IRecipientable
{
    protected AbstractFiniteRecipient(int importance) => Importance = importance;

    public int Importance { get; }
    public abstract void GetMessage(Message? message);
}