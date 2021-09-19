using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    public interface IShape
    {
        Random Left { get; set; }
        Random Top { get; set; }
        public bool[,] IsNotEmptySpace { get; set; }
        public void GenerateShape();
    }

    public class Line : IShape
    {
        public bool[,] IsNotEmptySpace { get; set; } = new bool[81, 26];
        public Random Left { get; set; } = new Random();
        public Random Top { get; set; } = new Random();
        public Random Length { get; set; } = new Random();

        public void GenerateShape()
        {
            IsNotEmptySpace.Reset();

            int column = Left.Next(1, 79);
            int row = Top.Next(1, 24);

            int lineLength = Length.Next(2, 10);

            Console.SetCursorPosition(column, row);

            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < lineLength; i++)
            {
                if (column + i >= 80 || row >= 25)
                    break;

                Console.Write("=");
                IsNotEmptySpace[column + i, row] = true;
            }
        }
    }

    public class Square : IShape
    {
        public bool[,] IsNotEmptySpace { get; set; } = new bool[81, 26];
        public Random Left { get; set; } = new Random();
        public Random Top { get; set; } = new Random();
        public Random Size { get; set; } = new Random();

        public void GenerateShape()
        {
            IsNotEmptySpace.Reset();

            int column = Left.Next(1, 79);
            int row = Top.Next(1, 24);

            int squareSize = Size.Next(3, 10);

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < squareSize; i++)
            {
                Console.SetCursorPosition(column, row + i);
                for (int j = 0; j < squareSize; j++)
                {
                    if (column + j >= 80 || row + i >= 25)
                        break;

                    Console.Write("+");
                    IsNotEmptySpace[column + j, row + i] = true;

                }
                if (column >= 80 || row + i >= 25)
                    break;

                Console.WriteLine();
            }
        }
    }

    public class Rectangle : IShape
    {
        public bool[,] IsNotEmptySpace { get; set; } = new bool[81, 26];
        public Random Left { get; set; } = new Random();
        public Random Top { get; set; } = new Random();
        public Random Size { get; set; } = new Random();

        public void GenerateShape()
        {
            IsNotEmptySpace.Reset();

            int column = Left.Next(1, 79);
            int row = Top.Next(1, 24);

            int rectangleSize1 = Size.Next(2, 10);
            int rectangleSize2 = Size.Next(3, 10);

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < rectangleSize1; i++)
            {
                Console.SetCursorPosition(column, row + i);
                for (int j = 0; j < rectangleSize2; j++)
                {
                    if (column + j >= 80 || row + i >= 25)
                        break;

                    Console.SetCursorPosition(column + i, row + j);
                    Console.Write("@");
                    IsNotEmptySpace[column + j, row + i] = true;
                }
                if (column >= 80 || row + i >= 25)
                    break;

                Console.WriteLine();
            }
        }
    }

    public class Triangle : IShape
    {
        public bool[,] IsNotEmptySpace { get; set; } = new bool[81, 26];
        public Random Left { get; set; } = new Random();
        public Random Top { get; set; } = new Random();
        public Random Size { get; set; } = new Random();

        public void GenerateShape()
        {
            IsNotEmptySpace.Reset();

            int column = Left.Next(1, 79);
            int row = Top.Next(1, 24);

            int size = Size.Next(2, 9);
            Console.SetCursorPosition(column, row);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for (int i = 0; i < size; i++)
            {
                Console.SetCursorPosition(column, row + i);
                for (int j = 0; j <= i; j++)
                {
                    if (column + j >= 80 || row + i >= 25)
                    {
                        column = row + j;
                        break;
                    }

                    Console.Write("^");
                    IsNotEmptySpace[column + j, row + i] = true;
                }
                if (column >= 80 || row + i >= 25)
                    break;

                Console.WriteLine();
            }
        }
    }
}
