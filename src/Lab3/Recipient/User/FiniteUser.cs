using System.Collections.Generic;
using ObjectOrientedProgramming.Lab3.Exception;
using ObjectOrientedProgramming.Lab3.Mail;

namespace ObjectOrientedProgramming.Lab3.Recipient.User;

public class FiniteUser : AbstractFiniteRecipient
{
    public FiniteUser(int importance)
        : base(importance)
    {
        MessageArchive = new Dictionary<Message, Status>();
    }

    public Dictionary<Message, Status> MessageArchive { get; private set; }

    public override void GetMessage(Message? message)
    {
        if (message is not null) MessageArchive.Add(message, Status.Unread);
    }

    public void ReadMessage(Message? message)
    {
        if (message is not null && MessageArchive[message] == Status.Unread)
        {
            MessageArchive[message] = Status.Read;
        }
        else
        {
            throw new UnavailableActionException("Unavailable action: you cannot read the the message twice");
        }
    }
}