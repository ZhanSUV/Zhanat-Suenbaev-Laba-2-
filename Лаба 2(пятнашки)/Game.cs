using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_2_пятнашки_
{
    class Game
    {
        private int[,] field;
        public Game(int size)
        {
            this.field = new int[size, size];
        }
        private int[] GetLocation(int value)
        {
            int[] adress = new int[2];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == value)
                    {
                        adress[0] = j;
                        adress[1] = i;
                    }
                }
            }
            return adress;
        }
        public void Shift(int value)
        {
            int[] adressOfValue = GetLocation(value);
            int[] adressOfZero = GetLocation(0);
            int x = adressOfValue[0];
            int y = adressOfValue[1];
            int x1 = adressOfZero[0];
            int y1 = adressOfZero[1];
            if ((y == y1 + 1 && x == x1) || (y == y1 - 1 && x == x1) || (y == y1 && x == x1 - 1)) // находится слева посередине(соседствуют 3 нуля)
            {
                field[y1, x1] = field[y, x];
                field[y, x] = 0;
            }
            else if ((y == y1 + 1 && x == x1) || (y == y1 && x == x1 + 1) || (y == y1 - 1 && x == x1)) //находится справа посередине(соседствуют 3 нуля)
            {
                field[y1, x1] = field[y, x];
                field[y, x] = 0;
            }
            else if ((y == y1 && x == x1 + 1) || (y == y1 && x == x1 - 1) || (y == y1 + 1 && x == x1) || (y == y1 - 1 && x == x1)) // находится посередине(соседствуют 4 нуля)
            {
                field[y1, x1] = field[y, x];
                field[y, x] = 0;
            }
            else if ((y == y1 && x == x1 + 1) || (x == x1 && y == y1 - 1) || (y == y1 && x == x1 - 1)) //находится сверху посередине(соседствуют 3 нуля)
            {
                field[y1, x1] = field[y, x];
                field[y, x] = 0;
            }
            else if ((y == y1 && x == x1 + 1) || (x == x1 && y == y1 + 1) || (y == y1 && x == x1 - 1)) //находится снизу посередине(соседствуют 3 нуля)
            {
                field[y1, x1] = field[y, x];
                field[y, x] = 0;
            }
            else if ((y == y1 && x == x1 - 1) || (y == y1 - 1 && x == x1)) // находится в левем верхнем углу(соседствуют 2 нуля)
            {
                field[y1, x1] = field[y, x];
                field[y, x] = 0;
            }
            else if ((y == y1 && x == x1 - 1) || (y == y1 + 1 && x == x1)) // находится в левем нижнем углу(соседствуют 2 нуля)
            {
                field[y1, x1] = field[y, x];
                field[y, x] = 0;
            }
            else if ((y == y1 && x == x1 + 1) || (y == y1 + 1 && x == x1)) // находится в правом верхнем углу(соседствуют 2 нуля) + на - поставил
            {
                field[y1, x1] = field[y, x];
                field[y, x] = 0;
            }
            else if ((y == y1 && x == x1 + 1) || (y == y1 + 1 && x == x1)) // находится в правом нижнем углу(соседствуют 2 нуля)
            {
                field[y1, x1] = field[y, x];
                field[y, x] = 0;
            }
            else
            {
                Console.WriteLine("Your value is wrong");
            }
        }
        public void Filling(Random Gen)
        {       
            int[] numbers = new int[field.Length];
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                if (i != numbers.Length - 1)
                {
                    numbers[i] = i + 1;
                }             
            }
            int measure = 1;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (measure != field.Length)
                    {
                        field[i, j] = measure;
                        measure++;
                    }
                    else
                    {
                        field[i, j] = 0;
                    }
                }
            }
            //for (int i = 0; i < field.GetLength(0); i++)
            //{
            //    for (int j = 0; j < field.GetLength(1); j++)
            //    {
            //        int index = Gen.Next(0, field.Length);
            //        for (int k = 0; k < numbers.Length; k++)
            //        {
            //            while (numbers[index] == numbers[k] && numbers[k] == -1)
            //            {
            //                index = Gen.Next(0, field.Length);
            //            }
            //        }
            //        field[i, j] = numbers[index];
            //        numbers[index] = -1;
            //    }
            //}
        }
        public void Printing()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public bool CheckingSequence()
        {
            int[] numbers = new int[field.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == numbers.Length - 1)
                {
                    numbers[i] = 0;
                }
                else
                {
                    numbers[i] = i + 1;
                }
            }
            int count = 0;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i,j] != numbers[count])
                    {
                        return false;
                    }
                    count++;
                }
            }
            return true;
        }
    }
}
