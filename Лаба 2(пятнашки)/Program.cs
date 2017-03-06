using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Лаба_2_пятнашки_
{
    class Program
    {
        static void Main(string[] args)
        {
            Random Gen = new Random();
            Console.WriteLine("Welcome to my first game :)");
            Console.Write("Type your size of field (add one number) ");
            int a = Convert.ToInt32(Console.ReadLine());
            Game player = new Game(a); //new Game(Convert.ToInt32(Console.ReadLine()));
            Console.Clear();
            while (player.CheckWrongSize(a))
            {
                Console.WriteLine("Wrong size");
                Console.Write("Type your size of field (add one number) ");
                a = Convert.ToInt32(Console.ReadLine());
                player = new Game(a);
                Console.Clear();
            }
            Console.Clear();
            player.Filling(Gen);
            while (!player.CheckingSequence())
            {
                player.Printing();
                Console.Write("Type your number to move to zero ");
                int value = Convert.ToInt32(Console.ReadLine());
                player.Shift(value);
                Console.Clear();
            }
            player.Printing();
            Console.WriteLine("YOU WIN");
            Console.WriteLine("Do you want to play new game: YES/NO ");
            string answer = Convert.ToString(Console.ReadLine());
            while (answer == "YES")
            {
                Console.WriteLine("Type your size of field (add one number) ");
                player = new Game(Convert.ToInt32(Console.ReadLine()));
                player.Filling(Gen);
                while (!player.CheckingSequence())
                {
                    player.Printing();
                    Console.Write("Type your number to move to zero ");
                    int value = Convert.ToInt32(Console.ReadLine());
                    player.Shift(value);
                    Console.Clear();
                }
                player.Printing();
                Console.WriteLine("YOU WIN");
                Console.WriteLine("Do you want to play new game: YES/NO ");
                answer = Convert.ToString(Console.ReadLine());
            }
            Console.WriteLine("GOOD BUY!!!");
            Console.ReadLine();
        }
    }
}
