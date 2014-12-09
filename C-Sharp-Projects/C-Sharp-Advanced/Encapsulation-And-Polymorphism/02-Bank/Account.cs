using System;

namespace _02_Bank
{
    public abstract class Account
    {
        protected Account(decimal interestPerMonth, decimal balance, Customer customer)
        {
            this.InterestPerMonth = interestPerMonth;
            this.Balance = balance;
            this.Customer = customer;
        }

        public Customer Customer { get; protected set; }
        public decimal Balance { get; protected set; }
        public decimal InterestPerMonth { get; protected set; }

        public virtual decimal CalculateInterest(int months)
        {
            return this.InterestPerMonth * months;
        }

        public decimal AccomulatedBalance(int months)
        {
            return this.Balance + Math.Abs(this.CalculateInterest(months));
        }
    }
}
