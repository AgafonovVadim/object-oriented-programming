using ObjectOrientedProgramming.Lab3.Recipient;

namespace ObjectOrientedProgramming.Lab3.Addressee;

public class GroupAddressee : AbstractAddressee
{
    public GroupAddressee(params IRecipientable[] finiteAddressee)
        : base(finiteAddressee)
    {
    }
}