using System;

namespace BankingDomain
{
    public enum AccountType { Standard, Gold }
    public class BankAccount
    {
        

        private decimal _balance = 1000M;
        private ICalculateBankAccountBonuses _bonusCalculator;

        public AccountType AccountType;

        public BankAccount(ICalculateBankAccountBonuses bonusCalculator)
        {
            _bonusCalculator = bonusCalculator;
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public virtual void Deposit(decimal amountToDeposit)
        {
            decimal bonus = _bonusCalculator.GetDepositBonusFor(_balance, amountToDeposit);
            _balance += amountToDeposit + bonus;
            
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw > _balance)
            {
                throw new OverdraftException();
            }
            _balance -= amountToWithdraw;
        }
    }
}