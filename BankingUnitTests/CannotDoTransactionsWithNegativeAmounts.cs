using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class CannotDoTransactionsWithNegativeAmounts
    {
        ////Establish you understand the undesirable behavior
        //[Fact]
        //public void DepositAllowsNegativeNumbers()
        //{
        //    var account = new BankAccount(new Mock<ICalculateBankAccountBonuses>().Object, new Mock<INotifyTheFeds>().Object);
        //    var openingBalance = account.GetBalance();

        //    account.Deposit(-100);

        //    Assert.Equal(openingBalance -100, account.GetBalance());
        //}

        // Write a test that shows how it SHOULD work

        [Fact]
        public void DepositsDoNotAllowNegativeNumbers()
        {
            var account = new BankAccount(new Mock<ICalculateBankAccountBonuses>().Object, new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();

            Assert.Throws<NoNegativeTransactionsException>(() => account.Deposit(-100));

            
        }

    }
}
