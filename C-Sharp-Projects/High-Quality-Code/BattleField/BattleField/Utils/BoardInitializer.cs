namespace BattleField.Utils
{
    using System;
    using Interfaces;

    public class BoardInitializer : IBoardInitializable
    {
        private const double MinMinesPercentage = 0.15;
        private const double MaxMinesPercentage = 0.3;
        private readonly Random randomGenerator = new Random();

        public string[,] InitializeBoard(int size, string emptyFieldSymbol)
        {
            var board = new string[size, size];
            for (var row = 0; row < size; row++)
            {
                for (var col = 0; col < size; col++)
                {
                    board[row, col] = emptyFieldSymbol;
                }
            }

            var minMines = Convert.ToInt32(MinMinesPercentage * size * size);
            var maxMines = Convert.ToInt32(MaxMinesPercentage * size * size);
            var numberOfMines = this.randomGenerator.Next(minMines, maxMines + 1);
            for (var i = 0; i < numberOfMines; i++)
            {
                var row = this.randomGenerator.Next(0, size);
                var col = this.randomGenerator.Next(0, size);
                if (board[row, col] == emptyFieldSymbol)
                {
                    board[row, col] = this.randomGenerator.Next(1, 6).ToString();
                }
                else
                {
                    numberOfMines--;
                }
            }

            return board;
        }
    }
}
