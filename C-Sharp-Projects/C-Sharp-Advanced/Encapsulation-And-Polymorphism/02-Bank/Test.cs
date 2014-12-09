using System;

namespace _02_Bank
{
    class Test
    {
        static void Main()
        {
            Account[] accounts =
            {
                new DepositAccount(0.05m, 2000, Customer.Company),
                new DepositAccount(0.035m, 3000, Customer.Individual),
                new DepositAccount(0.062m, 1500, Customer.Company),
                new LoanAccount(0.065m, -10000, Customer.Company), 
                new LoanAccount(0.085m, -7250, Customer.Individual),
                new MortgageAccount(0.09m, -17500, Customer.Individual), 
            };

            foreach (var account in accounts)
            {
                Console.WriteLine("Interest for 1 year: " + account.CalculateInterest(12));
                Console.WriteLine("Balance after 1 year: " + account.AccomulatedBalance(12));
                Console.WriteLine("Interest for 6 months: " + account.CalculateInterest(6));
                Console.WriteLine("Balance after 6 months: " + account.AccomulatedBalance(6));
                Console.WriteLine();
            }
        }
    }
}
