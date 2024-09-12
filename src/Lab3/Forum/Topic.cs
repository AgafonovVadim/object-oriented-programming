using ObjectOrientedProgramming.Lab3.Addressee;
using ObjectOrientedProgramming.Lab3.Mail;

namespace ObjectOrientedProgramming.Lab3.Forum;

public class Topic
{
    private readonly IAddressable[] _addressees;

    public Topic(string name, params IAddressable[] addressees)
    {
        Name = name;
        _addressees = addressees;
    }

    public string Name { get; }

    public void GetMessage(Message? message)
    {
        foreach (IAddressable addressee in _addressees)
        {
            addressee.GetMessage(message);
        }
    }
}