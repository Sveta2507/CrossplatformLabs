using System;
using System.IO;

namespace Lab1
{
    public class Program
    {
        static void Main()
        {
            string projectDirectory = Directory.GetCurrentDirectory();

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
            if (n > 1000000000000000000 || n < 1) //10^18
            {
                return "число некоректне";
            }

            int count = 0;
            long sqrtN = (long)Math.Sqrt(n); //для кпащих часових показників не будемо ітерувати до заданого числа n, а до кореня цього числа

            for (long i = 1; i <= sqrtN; i++)
            {
                if (n % i == 0)//якщо залишок від ділення 0
                {
                    count++;//то це дільник (збільшили лічильник)
                    if (i != n / i) //якщо при діленні числа на дільник отримуємо інше число
                    {
                        count++; // то це також дільник
                    }
                }
            }

            return count.ToString();
        }
    }
}
