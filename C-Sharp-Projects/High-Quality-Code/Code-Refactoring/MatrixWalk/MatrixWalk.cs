using System;
using System.Text;

public class MatrixWalk
{
    private const int NumberOfDirections = 8;

    private readonly int[,] matrix;

    private int dimensions;
    
    public MatrixWalk(int dimensions)
    {
        this.Dimensions = dimensions;
        this.matrix = new int[this.dimensions, this.dimensions];
        this.FindFreeCell();
        this.FillAllFreeCells();
    }

    public int CurrentRow { get; private set; }

    public int CurrentCol { get; private set; }

    public int Dimensions
    {
        get
        {
            return this.dimensions;
        }

        private set
        {
            if (value < 1 || value > 100)
            {
                throw new ArgumentException("The dimensions must be between 1 and 100");
            }

            this.dimensions = value;
        }
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        for (int row = 0; row < this.dimensions; row++)
        {
            for (int col = 0; col < this.dimensions; col++)
            {
                result.AppendFormat("{0,3}", this.matrix[row, col]);
            }

            result.AppendLine();
        }

        return result.ToString();
    }

    private void ChangeDirection(ref int dirRow, ref int dirCol)
    {
        int[] rowDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] colDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };
        int currDirection = 0;

        for (int i = 0; i < NumberOfDirections; i++)
        {
            if (rowDirections[i] == dirRow && colDirections[i] == dirCol)
            {
                currDirection = i;
                break;
            }
        }

        if (currDirection == NumberOfDirections - 1)
        {
            dirRow = rowDirections[0];
            dirCol = colDirections[0];
            return;
        }

        dirRow = rowDirections[currDirection + 1];
        dirCol = colDirections[currDirection + 1];
    }

    private void FindFreeCell()
    {
        this.CurrentRow = 0;
        this.CurrentCol = 0;

        for (int row = 0; row < this.dimensions; row++)
        {
            for (int col = 0; col < this.dimensions; col++)
            {
                if (this.matrix[row, col] == 0)
                {
                    this.CurrentRow = row;
                    this.CurrentCol = col;
                    return;
                }
            }
        }
    }

    private void FillAllFreeCells()
    {
        int directionRow = 1;
        int directionCol = 1;
        int number = 1;

        while (true)
        {
            this.matrix[this.CurrentRow, this.CurrentCol] = number;

            if (!this.CellIsAvailable(this.CurrentRow, this.CurrentCol))
            {
                this.FindFreeCell();
                if (this.CellIsAvailable(this.CurrentRow, this.CurrentCol))
                {
                    number++;
                    this.matrix[this.CurrentRow, this.CurrentCol] = number;
                    directionRow = 1;
                    directionCol = 1;
                }
                else
                {
                    break;
                }
            }

            int nextRow = this.CurrentRow + directionRow;
            int nextCol = this.CurrentCol + directionCol;

            if (!this.NumberIsInRange(nextRow) || !this.NumberIsInRange(nextCol) || this.matrix[nextRow, nextCol] != 0)
            {
                while (!this.NumberIsInRange(nextRow) || !this.NumberIsInRange(nextCol) || this.matrix[nextRow, nextCol] != 0)
                {
                    this.ChangeDirection(ref directionRow, ref directionCol);

                    nextRow = this.CurrentRow + directionRow;
                    nextCol = this.CurrentCol + directionCol;
                }
            }

            this.CurrentRow = nextRow;
            this.CurrentCol = nextCol;
            number++;
        }
    }

    private bool CheckIfNextCellIsEmpty(int row, int col, int[] directionRow, int[] directionCol)
    {
        for (int dirIndex = 0; dirIndex < NumberOfDirections; dirIndex++)
        {
            int nextRow = row + directionRow[dirIndex];
            int nextCol = col + directionCol[dirIndex];

            if (this.matrix[nextRow, nextCol] == 0)
            {
                return true;
            }
        }

        return false;
    }

    private bool CellIsAvailable(int row, int col)
    {
        int[] rowDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] colDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };

        for (int i = 0; i < NumberOfDirections; i++)
        {
            int nextRow = row + rowDirections[i];

            if (!this.NumberIsInRange(nextRow))
            {
                rowDirections[i] = 0;
            }

            int nextCol = col + colDirections[i];

            if (!this.NumberIsInRange(nextCol))
            {
                colDirections[i] = 0;
            }
        }

        return this.CheckIfNextCellIsEmpty(row, col, rowDirections, colDirections);
    }

    private bool NumberIsInRange(int value)
    {
        if (value >= this.dimensions || value < 0)
        {
            return false;
        }

        return true;
    }
}
