using System;

namespace _02_Bank
{
    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(decimal interestPerMonth, decimal balance, Customer customer)
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
                if (months <= 2)
                {
                    return 0;
                }

                return this.Balance * this.InterestPerMonth * (months - 2);
            }

            if (months <= 3)
            {
                return 0;
            }

            return this.Balance * this.InterestPerMonth * (months - 3);
        }
    }
}
