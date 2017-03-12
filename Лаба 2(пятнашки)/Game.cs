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
            Random Gen = new Random();
            Filling(Gen);
        }
        public Game(string path)
        {
            int[] numbers = FileReader.ReadingFile(path);
            int size = (int)Math.Sqrt(numbers.Length);
            this.field = new int[size, size];
            FillingFromSymbolsFromFile(path);
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
        private bool Shift(int value)
        {
            int[] adressOfValue = GetLocation(value);
            int[] adressOfZero = GetLocation(0);
            int x = adressOfValue[0];
            int y = adressOfValue[1];
            int x1 = adressOfZero[0];
            int y1 = adressOfZero[1];
            if (Math.Sqrt(Math.Pow((x - x1), 2) + Math.Pow((y - y1), 2)) == 1) 
            {
                return true;
            }
            return false;
        }
        private void ChangeKnuckles()
        {
            Print.ClearingConsole();
            while (!CheckingSequence())
            {
                Print.Field(field);
                Print.AskNumber();
                int value = Convert.ToInt32(Print.ReadUserAnswer());
                if (Shift(value))
                {
                    int[] adressOfValue = GetLocation(value);
                    int[] adressOfZero = GetLocation(0);
                    int x = adressOfValue[0];
                    int y = adressOfValue[1];
                    int x1 = adressOfZero[0];
                    int y1 = adressOfZero[1];
                    field[y1, x1] = field[y, x];
                    field[y, x] = 0;
                }
                Print.ClearingConsole();
            }
            Print.Win();
            Print.AskNewGame();
            string answer = Print.ReadUserAnswer();
            while (answer.ToLower() == "yes")
            {
                Print.AskSize();
                Game newgame = new Game(Convert.ToInt32(Print.ReadUserAnswer()));
            }
            Print.End();       
        }
        private void Filling(Random Gen)
        {       
            int[] numbers = new int[field.Length];
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                if (i != numbers.Length - 1)
                {
                    numbers[i] = i + 1;
                }             
            }
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    int index = Gen.Next(0, field.Length);
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        while (numbers[index] == numbers[k] && numbers[k] == -1)
                        {
                            index = Gen.Next(0, field.Length);
                        }
                    }
                    field[i, j] = numbers[index];
                    numbers[index] = -1;
                }
            }
            ChangeKnuckles();
        }
        private void FillingFromSymbolsFromFile(string path)
        {
            int[] numbers = FileReader.ReadingFile(path);
            int count = 0;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = numbers[count];
                    count++;
                }
            }
            ChangeKnuckles();
        }
        private bool CheckingSequence()
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
