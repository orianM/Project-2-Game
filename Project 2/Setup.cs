using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    public class Setup
    {
        public bool[,] CheckIfEmptySpace { get; set; } = new bool[120, 30];
        List<IShape> shapeTypes { get; set; } = new List<IShape>();
        List<IShape> shapeList { get; set; } = new List<IShape>(15);
        public int AmountOfshapes { get; set; }
        public Random GetRandomNum { get; set; } = new Random();
        public int PointsToWin { get; set; } = 0;

        public bool Finished { get; set; }

        public Setup()
        {
            shapeTypes.Add(new Line());
            shapeTypes.Add(new Square());
            shapeTypes.Add(new Triangle());
            shapeTypes.Add(new Rectangle());
            AmountOfshapes = GetRandomNum.Next(3, 6);
        }

        public void Begin()
        {
            Console.SetWindowSize(81, 26);
            int playerPoints = 0;

            while (AmountOfshapes != 15 && PointsToWin != 30)
            {
                Console.Clear();
                CheckIfEmptySpace.Reset();
                Console.BackgroundColor = ConsoleColor.Black;

                for (int i = 0; i < AmountOfshapes; i++)
                {
                    int chosenShape = GetRandomNum.Next(0, 4);
                    shapeList.Add(shapeTypes[chosenShape]);
                }

                foreach (var shape in shapeList)
                {
                    shape.GenerateShape();
                    Finished = CompareEmptySpace(shape.IsNotEmptySpace, CheckIfEmptySpace);
                    if (Finished == false)
                    {
                        CheckIfEmptySpace.Reset();
                        shapeList.Clear();
                        PointsToWin++;
                        break;
                    }
                }

                if (Finished == true)
                {
                    Player player = new Player();
                    CheckIfEmptySpace = player.GeneratePlayer(CheckIfEmptySpace, ref playerPoints);
                    AmountOfshapes++;
                }
                Console.Clear();
            }

            if (AmountOfshapes == 15 || PointsToWin == 30)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Game over\nscore: {playerPoints} points");
            }
        }

        public bool CompareEmptySpace(bool[,] pos1, bool[,] pos2)
        {
            for (int i = 0; i < pos1.GetLength(0); i++)
            {
                for (int j = 0; j < pos1.GetLength(1); j++)
                {
                    if (pos1[i, j] == true && pos2[i, j] == false)
                    {

                        pos2[i, j] = true;

                    }
                    else if (pos1[i, j] == true && pos2[i, j] == true) return false;
                }
            }
            return true;
        }
    }
    public static class ResetArray
    {
        public static bool[,] Reset(this bool[,] arrayToReset)
        {
            for (int i = 0; i < arrayToReset.GetLength(0); i++)
            {
                for (int j = 0; j < arrayToReset.GetLength(1); j++)
                {
                    arrayToReset[i, j] = false;
                }
            }
            return arrayToReset;
        }
    }
}
