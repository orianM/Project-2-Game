using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    class Player
    {
        private Random left = new Random();
        private Random top = new Random();

        public bool[,] GeneratePlayer(bool[,] isNotEmptySpace, ref int points)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            int column = left.Next(1, 79);
            int row = top.Next(1, 24);
            Console.SetCursorPosition(column, row);
            Console.CursorVisible = false;
            Console.Write("*");

            Console.ForegroundColor = ConsoleColor.Blue;

            try
            {
                while (isNotEmptySpace[column, row] == false)
                {
                    ConsoleKeyInfo input = Console.ReadKey();
                    switch (input.Key)
                    {
                        case ConsoleKey.UpArrow:
                            Console.SetCursorPosition(column, row);
                            isNotEmptySpace[column, row] = true;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            row--;
                            Console.Write('*');
                            break;

                        case ConsoleKey.DownArrow:
                            Console.SetCursorPosition(column, row);
                            isNotEmptySpace[column, row] = true;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            row++;
                            Console.Write('*');
                            break;

                        case ConsoleKey.LeftArrow:
                            Console.SetCursorPosition(column, row);
                            isNotEmptySpace[column, row] = true;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            column--;
                            Console.Write('*');
                            break;

                        case ConsoleKey.RightArrow:
                            Console.SetCursorPosition(column, row);
                            isNotEmptySpace[column, row] = true;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            column++;
                            Console.Write('*');
                            break;
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(column, row);
                    points++;
                    Console.Write("*");
                }
            }

            catch
            {
                return isNotEmptySpace;
            }

            Console.BackgroundColor = ConsoleColor.Black;
            return isNotEmptySpace;
        }
    }
}
