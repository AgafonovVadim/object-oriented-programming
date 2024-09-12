using ObjectOrientedProgramming.Lab3.Mail;

namespace ObjectOrientedProgramming.Lab3.Recipient.Display;

public class FiniteDisplay : AbstractFiniteRecipient
{
    public FiniteDisplay(int importance, DisplayDriver displayDriver)
        : base(importance)
    {
        DisplayDriver = displayDriver;
    }

    public DisplayDriver DisplayDriver { get; private set; }
    public override void GetMessage(Message? message)
    {
        DisplayDriver.Print(message);
    }
}