using System;

namespace GeometryAPI
{
    class Program
    {
        private static ExtendendFigureController GetFigureController()
        {
            return new ExtendendFigureController();
        }

        static void Main()
        {
            var figController = GetFigureController();

            int figCreationsCount = int.Parse(Console.ReadLine());
            int endCommandsCount = 0;

            while (endCommandsCount < figCreationsCount)
            {
                figController.ExecuteCommand(Console.ReadLine());
                if (figController.EndCommandExecuted)
                {
                    endCommandsCount++;
                }
            }
        }
    }
}
