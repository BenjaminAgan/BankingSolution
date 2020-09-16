using BankingDomain;
using BankingUnitTests.TestDoubles;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;
using Xunit;

namespace BankingUnitTests
{
    public class NewAccounts
    {

        [Fact]
        public void NewAccountsHaveCorrectBalance()
        {
            //Write The Code You Wish You had 
            //Given
            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFeds>().Object);
            //When
            decimal balance = account.GetBalance();
            //Then
            Assert.Equal(1000M, balance);
        }
    }
}
