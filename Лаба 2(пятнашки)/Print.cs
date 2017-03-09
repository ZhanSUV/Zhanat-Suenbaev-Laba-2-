using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_2_пятнашки_
{
    class Print
    {
        public static void Error()
        {
            Console.WriteLine("Wrong measures");
        } 
        public static void Win()
        {
            Console.WriteLine("YOU WIN!!!");
        }
        public static void AskNewGame()
        {
            Console.WriteLine("Do you want to play a new game: YES/NO ");
        }
        public static void AskNumber()
        {
            Console.Write("Type your number to move to zero ");
        }
        public static void AskSize()
        {
            Console.WriteLine("Type a size of your field ");
        }
        public static void Field(int[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                Console.Write("\t");
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public static void ClearingConsole()
        {
            Console.Clear();
        }
        public static void End()
        {
            Console.WriteLine("Good bye");
            Console.WriteLine("Add enter to exit from the game");
            Console.ReadLine();
        }
        public static string ReadUserAnswer()
        {
            return Console.ReadLine();
        }
    }
}
