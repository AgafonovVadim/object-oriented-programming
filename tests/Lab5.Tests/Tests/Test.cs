using System;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Accounts;
using Moq;
using Xunit;

namespace ObjectOrientedProgramming.Lab5.Tests.Tests;

public class Test
{
    [Fact]
    public void CheckCorrectBalanceWithdraw()
    {
        var repo = new MockRepository(MockBehavior.Strict);
        Mock<IAccountService> accountServiceMock = repo.Create<IAccountService>();
        var acc = new Account(1, 1, 100);
        int accBalance = (int)acc.Balance;
        accountServiceMock.Setup(s => s.Withdraw(100)).Callback<int>(amount => accBalance -= amount).Returns(OperationResult.Success);

        accountServiceMock.Object.Withdraw(100);

        Assert.Equal(0, accBalance);
    }

    [Fact]
    public void CheckInCorrectBalanceWithdraw()
    {
        var repo = new MockRepository(MockBehavior.Strict);
        Mock<IAccountService> accountServiceMock = repo.Create<IAccountService>();
        accountServiceMock.Setup(s => s.Withdraw(100)).Throws(new NotSupportedException("Withdraw failed"));

        var acc = new Account(1, 1, 10);
        Assert.Throws<NotSupportedException>(() => accountServiceMock.Object.Withdraw(100));
    }

    [Fact]
    public void CheckCorrectBalanceDeposit()
    {
        {
            var repo = new MockRepository(MockBehavior.Strict);
            Mock<IAccountService> accountServiceMock = repo.Create<IAccountService>();
            var acc = new Account(1, 1, 10);
            int accBalance = (int)acc.Balance;
            accountServiceMock.Setup(s => s.Deposit(100)).Callback<int>(amount => accBalance += amount).Returns(OperationResult.Success);

            accountServiceMock.Object.Deposit(100);

            Assert.Equal(110, accBalance);
        }
    }
}