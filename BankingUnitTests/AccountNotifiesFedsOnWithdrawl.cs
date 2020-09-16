
using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class AccountNotifiesFedsOnWithdrawl
    {
        [Fact]
        public void FedIsNotifiedOnWithdrawl()
        {
            var mockedFed = new Mock<INotifyTheFeds>();
            var account = new BankAccount(new Mock<ICalculateBankAccountBonuses>().Object, mockedFed.Object);

            account.Withdraw(1);

            mockedFed.Verify(f => f.NotifyOfWithdraw(account, 1m));
        }
    }
}
