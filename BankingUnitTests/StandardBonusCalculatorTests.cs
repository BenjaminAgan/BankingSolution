﻿using BankingDomain;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class StandardBonusCalculatorTests
    {
        // Balances below 1000 never get a bonus (either before or after cutoff)(2)
        // Balances at or over 1000 
        //  - Before cutoff get 10%
        //  - After cutoff get 8%
        [Fact]
        public void BonusBeforeCutff()
        {
            var calculator = new BeforeCutoffBonusCalculator();
            var bonus = calculator.GetDepositBonusFor(1000, 100);
            Assert.Equal(10, bonus);
        }

        [Fact]
        public void BonusAfterCutoff()
        {
            var calculator = new AfterCutoffBonusCalculator();
            var bonus = calculator.GetDepositBonusFor(1000, 100);
            Assert.Equal(8, bonus);
        }

    }

    public class BeforeCutoffBonusCalculator : StandardBonusCalculator
    {
        protected override bool BeforeCutoff()
        {
            return true;
        }
    }
    public class AfterCutoffBonusCalculator : StandardBonusCalculator
    {
        protected override bool BeforeCutoff()
        {
            return false;
        }
    }


}
