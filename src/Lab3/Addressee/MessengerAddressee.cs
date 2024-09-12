using ObjectOrientedProgramming.Lab3.Recipient.Messenger;

namespace ObjectOrientedProgramming.Lab3.Addressee;

public class MessengerAddressee : AbstractAddressee
{
    public MessengerAddressee(FiniteMessenger finiteAddressee)
        : base(finiteAddressee)
    {
    }
}