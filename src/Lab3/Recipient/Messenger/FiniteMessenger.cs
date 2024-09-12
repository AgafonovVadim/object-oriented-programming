using System;
using ObjectOrientedProgramming.Lab3.Mail;

namespace ObjectOrientedProgramming.Lab3.Recipient.Messenger;

public class FiniteMessenger : AbstractFiniteRecipient
{
    public FiniteMessenger(int importance)
        : base(importance)
    {
    }

    public override void GetMessage(Message? message) => Console.WriteLine("messenger: " + message?.GetText());
}