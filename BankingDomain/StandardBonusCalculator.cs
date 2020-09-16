using System;
using System.Collections.Generic;
using System.Text;

namespace BankingDomain
{
    public class StandardBonusCalculator : ICalculateBankAccountBonuses
    {
        public decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit)
        {
            // accoutns with at least 1000 & it is before 5pm get 10%, otherwise 8%
            if (EligibleForBonus(balance))
            {
                if (BeforeCutoff())
                {
                    return amountToDeposit * .1M;
                }
                else
                {
                    return amountToDeposit * .08M;
                }
            }
            return 0;
        }

        protected virtual bool BeforeCutoff()
        {
            return DateTime.Now.Hour < 17;
        }

        private bool EligibleForBonus(decimal balance)
        {
            return balance >= 1000;
        }
    }
}
