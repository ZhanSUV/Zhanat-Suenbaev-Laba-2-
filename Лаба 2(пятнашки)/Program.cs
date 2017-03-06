using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_2_пятнашки_
{
    class Program
    {
        static void Main(string[] args)
        {
            Random Gen = new Random();
            Game player = new Game(3);
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
