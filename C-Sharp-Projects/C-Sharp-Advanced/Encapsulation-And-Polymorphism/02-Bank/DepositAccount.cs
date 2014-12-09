using System;

namespace _02_Bank
{
    public class DepositAccount : Account, IWithdrawable, IDepositable
    {
        public DepositAccount(decimal interestPerMonth, decimal balance, Customer customer)
            : base(interestPerMonth, balance, customer)
        {
        }

        public void Withraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance <= 1000)
            {
                return 0;
            }
            
            return this.Balance * this.InterestPerMonth * months;
        }
    }
}
