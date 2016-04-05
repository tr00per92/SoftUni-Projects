namespace AtmDb.ConsoleClient
{
    using AtmDb.Data;

    public class ConsoleClient
    {
        public static void Main()
        {
            AtmOperator.Withdraw("1111111111", "0123", 500);
            AtmOperator.Withdraw("2222222222", "1234", 200);
        }
    }
}
