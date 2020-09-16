using BankingDomain;
using BankingUnitTests.TestDoubles;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class AccountWithdrawls
    {

        [Fact]

        public void WithdrawlDecreaseBalance()
        {
            var account = new BankAccount(new DummyBonusCalculator());
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 1M;

            account.Withdraw(amountToWithdraw);

            Assert.Equal(
                openingBalance - amountToWithdraw, account.GetBalance());
        }
    }
}
