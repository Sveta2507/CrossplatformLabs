using System;
using System.IO;

namespace Lab2
{
    public class Program
    {
        const int INF = 1_000_000_000; // константа умовоного максимуму

        static void Main()
        {
            string projectDirectory = Directory.GetCurrentDirectory();
            string inputFilePath = Path.Combine(projectDirectory, "input1.txt");
            string outputFilePath = Path.Combine(projectDirectory, "output.txt");

            int minimumCost = CalculateMinimumCost(inputFilePath);

            File.WriteAllText(outputFilePath, minimumCost.ToString());
        }

        public static int CalculateMinimumCost(string inputFilePath)
        {
            string[] inputLines = File.ReadAllLines(inputFilePath);
            int n = int.Parse(inputLines[0]); // перша строка - номер кінцевої станцій (кількість станцій N+1)

            int[,] cost = new int[n + 1, n + 1]; //матриця вартості для кожної пари станцій

            //заповнюємо матрицю
            int index = 1; //починаємо з першого рядка, оскільки нульовий рядок це N
            //всі наступні рядки - вартість від станції до станції, на кожній строчці збільшується перший номер станції, тобто:
            // (від станції 0 до 1),(1 до 2),(2 до 3)...(N-1 до N)
            for (int z = 0; z < n; z++) //по всім станціям-рядкам
            {
                string[] prices = inputLines[index++].Split(); // отримуємо всі вартості за рядками та розділяємо їх
                for (int x = z + 1; x <= n; x++) // починаючи з сусідньої до z та далі по рядку
                {
                    cost[z, x] = int.Parse(prices[x - z - 1]); //записуємо цінм проїзду
                }
            }

            int[] best = new int[n + 1]; //масив мінімальних вартостей до станцій
            for (int i = 0; i <= n; i++)
            {
                best[i] = INF; //спочатку заповнюємо масив макс константою, бо ми не знаємо ціни
            }
            best[0] = 0; //вартість проїзду зі станції 0 до 0 дорівнює 0

            for (int z = 1; z <= n; z++) //для кожній станції
            {
                for (int x = 0; x < z; x++)//по кожній попередній станції
                {
                    best[z] = Math.Min(best[z], best[x] + cost[x, z]); //записуємо мінімальну вартість до станції z через найдешевші станції х
                }
            }
            return best[n]; //повертаємо мінімальну вартість проїзду до станції N
        }
    }
}