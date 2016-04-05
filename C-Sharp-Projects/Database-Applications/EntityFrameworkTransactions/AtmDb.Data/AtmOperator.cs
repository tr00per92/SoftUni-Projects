namespace AtmDb.Data
{
    using System;
    using System.Data;
    using System.Linq;

    public static class AtmOperator
    {
        public static void Withdraw(string cardNumber, string pin, decimal money)
        {
            if (money <= 0)
            {
                throw new ArgumentException("The amount of money be positive.");
            }

            using (var db = new AtmDb())
            {
                using (var transaction = db.Database.BeginTransaction(IsolationLevel.RepeatableRead))
                {
                    try
                    {
                        var card = db.CardAccounts.FirstOrDefault(c => c.CardNumber == cardNumber);
                        if (card == null)
                        {
                            throw new ArgumentException("Invalid Card Number.");
                        }

                        if (card.CardPIN != pin)
                        {
                            throw new ArgumentException("Invalid PIN.");
                        }

                        if (card.CardCash < money)
                        {
                            throw new ArgumentException("Insufficient Balance.");
                        }

                        card.CardCash -= money;
                        db.SaveChanges();

                        db.TransactionHistories.Add(new TransactionHistory
                        {
                            CardNumber = cardNumber,
                            TransactionDate = DateTime.Now,
                            Amount = money
                        });

                        db.SaveChanges();
                        transaction.Commit();
                        Console.WriteLine("Transaction Successful.");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("Error: {0}", e.Message);
                    }
                }
            }
        }
    }
}
