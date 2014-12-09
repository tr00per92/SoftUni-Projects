using System;

namespace _02_Bank
{
    public class MortgageAccount : Account, IDepositable
    {
        public MortgageAccount(decimal interestPerMonth, decimal balance, Customer customer)
            : base(interestPerMonth, balance, customer)
        {
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer == Customer.Company)
            {
                if (months <= 12)
                {
                    return this.Balance * (this.InterestPerMonth / 2) * months;
                }

                return (this.Balance * (this.InterestPerMonth / 2) * 12) +
                    (months * this.InterestPerMonth * (months - 12));
            }

            if (months <= 6)
            {
                return 0;
            }
            
            return this.Balance * this.InterestPerMonth * (months - 6);
        }
    }
}
