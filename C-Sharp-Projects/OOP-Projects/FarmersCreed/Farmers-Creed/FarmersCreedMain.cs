namespace FarmersCreed
{
    using Simulator;

    public class FarmersCreedMain
    {
        public static void Main()
        {
            FarmSimulator simulator = new UpdatedFarmSimulator();
            simulator.Run();
        }
    }
}
