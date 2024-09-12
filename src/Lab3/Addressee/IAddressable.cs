using ObjectOrientedProgramming.Lab3.Mail;

namespace ObjectOrientedProgramming.Lab3.Addressee;

public interface IAddressable
{
    void GetMessage(Message? message);
    void Send();
}