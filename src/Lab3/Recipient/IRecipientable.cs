using ObjectOrientedProgramming.Lab3.Mail;

namespace ObjectOrientedProgramming.Lab3.Recipient;

public interface IRecipientable
{
    public int Importance { get; }
    public void GetMessage(Message? message);
}