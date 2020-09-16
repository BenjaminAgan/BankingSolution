using BankingDomain;
using BankingUnitTests.TestDoubles;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class AccountOverdraft
    {
        // Withdraw more than balance of account

        [Fact]
        public void BalanceStaystheSame()
        {
            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();
            try
            {
                account.Withdraw(openingBalance + 1M);
            }
            catch (OverdraftException)
            {

                //Gulp
            }
            Assert.Equal(
                openingBalance,
                account.GetBalance());
        }

        [Fact]
        public void WithdrawToZero()
        {
            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFeds>().Object);


            account.Withdraw(account.GetBalance());
            

            Assert.Equal(
                0,
                account.GetBalance());
        }

        [Fact]
        public void OverdraftGivesException()
        {
            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();
            Assert.Throws<OverdraftException>(() => account.Withdraw(openingBalance+1M));
        }
    }
}
