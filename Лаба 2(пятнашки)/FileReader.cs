using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Лаба_2_пятнашки_
{
    class FileReader
    {
        public static int[] ReadingFile(string path)
        {  
            string symbolsFromFile = File.ReadAllText(path, Encoding.GetEncoding(1251));
            string[] lineMeasures = symbolsFromFile.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[lineMeasures.Length];
            if (CheckNumbersFromFile(lineMeasures))
            {
                for (int i = 0; i < lineMeasures.Length; i++)
                {
                    numbers[i] = int.Parse(lineMeasures[i]);
                }
                if (CheckNumbers(numbers))
                {
                    return numbers;
                }
                else
                {
                    throw new Exception("Wrong Measures");
                }
            }
            else
            {
                throw new Exception("Wrong Measures");
            }
        }
        private static bool CheckNumbersFromFile(string[] lineOfMeasures)
        {
            for (int i = 0; i < lineOfMeasures.Length; i++)
            {
                char[] symbols = lineOfMeasures[i].ToCharArray();
                for (int j = 0; j < symbols.Length; j++)
                {
                    if (!char.IsDigit(symbols[j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private static bool CheckCorrectSequence(int[] numbers)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (count == numbers[j])
                    {
                        count++;
                        break;
                    }
                }
            }
            if (count == numbers.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool CheckSquareField(int[] numbers)
        {
            int size = SizeOfField(numbers);
            if (Math.Pow(size, 2) == numbers.Length)
            {
                return true;
            }
            return false;
        }
        private static int SizeOfField(int[] numbers)
        {
            int count = numbers.Length;
            return (int)(Math.Sqrt(count));
        }
        private static bool CheckPositiveNumbers(int[] numbers)
        {
            bool check = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    check = false;
                    break;
                }
            }
            return check;
        }
        private static bool CheckUniqueNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i != j)
                    {
                        if (numbers[i] == numbers[j])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private static bool CheckNumbers(int[] numbers)
        {
            return CheckSquareField(numbers) && CheckCorrectSequence(numbers) && CheckPositiveNumbers(numbers) && CheckUniqueNumbers(numbers);

        }
    }
}
