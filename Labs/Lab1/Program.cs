using System;
using System.IO;

namespace Lab1
{
    public class Program
    {
        static void Main()
        {
            string projectDirectory = Directory.GetCurrentDirectory();// та, де виконуємо команди білда

            string inputFilePath = Path.Combine(projectDirectory, "input.txt");
            string outputFilePath = Path.Combine(projectDirectory, "output.txt");
 
            long n;

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                n = long.Parse(reader.ReadLine());
            }

            string result = GetDivisorsCount(n);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine(result);
            }
        }

        public static string GetDivisorsCount(long n)
        {
            if (n > 1018)
            {
                return "число завелике";
            }

            int count = 0;
            for (long i = 1; i <= n; i++)
            {
                if (n % i == 0) //якщо залишок від ділення 0
                {
                    count++; //додаємо 1 до лічильника
                }
            }

            return count.ToString(); //повертаємо кількість дільників як строчний тип
        }
    }
}
