using Moq;
using ObjectOrientedProgramming.Lab3.Addressee;
using ObjectOrientedProgramming.Lab3.Exception;
using ObjectOrientedProgramming.Lab3.Logger;
using ObjectOrientedProgramming.Lab3.Mail;
using ObjectOrientedProgramming.Lab3.Recipient.Messenger;
using ObjectOrientedProgramming.Lab3.Recipient.User;
using Xunit;

namespace ObjectOrientedProgramming.Lab3.Tests.BasicTestCases;

public class Tests
{
    [Fact]
    public void TheReceivedMessageIsUnread()
    {
        var james = new FiniteUser(5);
        string header = "You have been accepted into our team!";
        string body = "Hi, James. We are glad to see you in our team. We hope for a long and productive cooperation";
        Message message = new Message.Builder()
            .SetHeader(header)
            .SetBody(body)
            .SetImportance(0)
            .Build();
        var jamesAdressee = new UserAddressee(james);
        jamesAdressee.GetMessage(message);
        jamesAdressee.Send();
        Assert.Equal(Status.Unread, james.MessageArchive[message]);
    }

    [Fact]
    public void ChangingTheStatusOfMessageByReading()
    {
        var james = new FiniteUser(5);
        string header = "You have been accepted into our team!";
        string body = "Hi, James. We are glad to see you in our team. We hope for a long and productive cooperation";
        Message message = new Message.Builder()
            .SetHeader(header)
            .SetBody(body)
            .SetImportance(0)
            .Build();
        var jamesAdressee = new UserAddressee(james);
        jamesAdressee.GetMessage(message);
        jamesAdressee.Send();
        james.ReadMessage(message);
        Assert.Equal(Status.Read, james.MessageArchive[message]);
    }

    [Fact]
    public void ErrorReadingTheReadMessage()
    {
        var james = new FiniteUser(5);
        string header = "You have been accepted into our team!";
        string body = "Hi, James. We are glad to see you in our team. We hope for a long and productive cooperation";
        Message message = new Message.Builder()
            .SetHeader(header)
            .SetBody(body)
            .SetImportance(0)
            .Build();
        var jamesAdressee = new UserAddressee(james);
        jamesAdressee.GetMessage(message);
        jamesAdressee.Send();
        james.ReadMessage(message);
        try
        {
            james.ReadMessage(message);
            Assert.Fail();
        }
        catch (UnavailableActionException)
        {
            Assert.Equal(Status.Read, james.MessageArchive[message]);
        }
    }

    [Fact]
    public void TheMessageDidNotReachTheUserWithInsufficientImportance()
    {
        var james = new Mock<FiniteUser>(5);
        string header = "You have been accepted into our team!";
        string body = "Hi, James. We are glad to see you in our team. We hope for a long and productive cooperation";
        Message message = new Message.Builder()
            .SetHeader(header)
            .SetBody(body)
            .SetImportance(15)
            .Build();
        var jamesAdresseeMock = new Mock<UserAddressee>(james.Object);
        var console = new Mock<ILoggable>();
        jamesAdresseeMock.Object.Logger = console.Object;
        UserAddressee jamesAdressee = jamesAdresseeMock.Object;
        jamesAdresseeMock.CallBase = true;
        jamesAdressee.GetMessage(message);
        jamesAdressee.Send();
        console.Verify(mock => mock.Log(It.Is<string>(receivedLog => receivedLog == "The message was not sent to the recipient because the recipient has an insufficient level of importance.")), Times.Once);
    }

    [Fact]
    public void CheckingLoggingOfSendingAMessage()
    {
        var james = new Mock<FiniteUser>(5);
        string header = "You have been accepted into our team!";
        string body = "Hi, James. We are glad to see you in our team. We hope for a long and productive cooperation";
        Message message = new Message.Builder()
            .SetHeader(header)
            .SetBody(body)
            .SetImportance(0)
            .Build();
        var jamesAdresseeMock = new Mock<UserAddressee>(james.Object);
        var console = new Mock<ILoggable>();
        jamesAdresseeMock.Object.Logger = console.Object;
        UserAddressee jamesAdressee = jamesAdresseeMock.Object;
        jamesAdresseeMock.CallBase = true;
        jamesAdressee.GetMessage(message);
        jamesAdressee.Send();
        console.Verify(mock => mock.Log(It.Is<string>(receivedLog => receivedLog == "The message has been sent to the recipient.")), Times.Once);
    }

    [Fact]
    public void CheckingTheBehaviorOfTheMessenger()
    {
        var vkontakte = new Mock<FiniteMessenger>(5);
        string header = "You have been accepted into our team!";
        string body = "Hi, James. We are glad to see you in our team. We hope for a long and productive cooperation";
        Message message = new Message.Builder()
            .SetHeader(header)
            .SetBody(body)
            .SetImportance(0)
            .Build();
        var vkontakteAdresseeMock = new Mock<MessengerAddressee>(vkontakte.Object);
        var console = new Mock<ILoggable>();
        vkontakteAdresseeMock.Object.Logger = console.Object;
        MessengerAddressee vkontakteAdressee = vkontakteAdresseeMock.Object;
        vkontakteAdresseeMock.CallBase = true;
        vkontakteAdressee.GetMessage(message);
        vkontakteAdressee.Send();
        vkontakte.Verify(mock => mock.GetMessage(message), Times.Once);
    }
}