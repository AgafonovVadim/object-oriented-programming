using ObjectOrientedProgramming.Lab3.Logger;
using ObjectOrientedProgramming.Lab3.Mail;
using ObjectOrientedProgramming.Lab3.Recipient;

namespace ObjectOrientedProgramming.Lab3.Addressee;

public abstract class AbstractAddressee : IAddressable
{
    private Message? _receivedMessage;
    private IRecipientable[] _finiteAddressee;

    protected AbstractAddressee(params IRecipientable[] finiteAddressee)
    {
        _finiteAddressee = finiteAddressee;
    }

    public ILoggable? Logger { get; set; }

    public void GetMessage(Message? message)
    {
        _receivedMessage = message;
    }

    public virtual void Send()
    {
        Logger = Logger ?? new ConsoleLogger();
        foreach (IRecipientable finiteRecipient in _finiteAddressee)
        {
            if (AccessedToGet(finiteRecipient))
            {
                SendToFiniteAddressee(finiteRecipient);
                Logger.Log("The message has been sent to the recipient.");
                continue;
            }

            Logger.Log("The message was not sent to the recipient because the recipient has an insufficient level of importance.");
        }
    }

    private bool AccessedToGet(IRecipientable finiteRecipient)
    {
        return _receivedMessage is not null && finiteRecipient.Importance >= _receivedMessage.Importance;
    }

    private void SendToFiniteAddressee(IRecipientable finiteRecipient)
    {
        finiteRecipient.GetMessage(_receivedMessage);
    }
}