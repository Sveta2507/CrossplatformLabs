using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    public class Program    
    {
        static void Main()
        {
            var input = File.ReadAllLines("input2.txt");
            var firstLine = input[0].Split();
            int N = int.Parse(firstLine[0]); //рядки
            int M = int.Parse(firstLine[1]); //стовбці бази

            var startCoords = input[1].Split(); //отриуємо початкові координати
            int startX = int.Parse(startCoords[0]) - 1;
            int startY = int.Parse(startCoords[1]) - 1; //приводимо до нульової індексації

            int[,] basePlan = new int[N, M]; //матриця-карта бази
            for (int i = 0; i < N; i++)
            {
                var row = input[i + 2].Split();
                for (int j = 0; j < M; j++)
                { // 1 відповідає стінці, 0 - її відсутності
                    basePlan[i, j] = int.Parse(row[j]); //заповнюємо матрицю значеннями бази з файлу
                }
            }

            int H = int.Parse(input[N + 2]); //кількість гіпертунелів
            Dictionary<(int, int), (int, int)> tunnels = new Dictionary<(int, int), (int, int)>();//словник для співставлення початкових координат тунелів з кінцевими
            for (int i = 0; i < H; i++)
            {
                var tunnelCoords = input[N + 3 + i].Split();
                int x1 = int.Parse(tunnelCoords[0]) - 1; //отримуємо координати входу та виходу гіпертунелів
                int y1 = int.Parse(tunnelCoords[1]) - 1; 
                int x2 = int.Parse(tunnelCoords[2]) - 1;
                int y2 = int.Parse(tunnelCoords[3]) - 1; 
                tunnels[(x1, y1)] = (x2, y2); //заносимо в словник
            }

            int K = int.Parse(input[N + 3 + H]); //кількість виходів
            var exits = new List<(int, int)>(); //список для кооржинат виходів
            for (int i = 0; i < K; i++)
            {
                var exitCoords = input[N + 4 + H + i].Split();
                int exitX = int.Parse(exitCoords[0]) - 1;
                int exitY = int.Parse(exitCoords[1]) - 1; 
                exits.Add((exitX, exitY)); //заносимо координати виходів в список
            }

            int result = BFS(startX, startY, basePlan, tunnels, exits);
            if (result == -1)
            {
                File.WriteAllText("output.txt", "Impossible");
            }
            else
            {
                File.WriteAllText("output.txt", result.ToString()); //записує кількість позицій до виходу у файл
            }
        }

        public static int BFS(int startX, int startY, int[,] basePlan, Dictionary<(int, int), (int, int)> tunnels, List<(int, int)> exits)
        {
            int N = basePlan.GetLength(0);
            int M = basePlan.GetLength(1); //розміри бази
            var directions = new (int, int)[] { (0, 1), (1, 0), (0, -1), (-1, 0) }; //можливі рухи картою

            Queue<(int, int, int)> queue = new Queue<(int, int, int)>(); // черга для координат позицій та відстанню до них
            HashSet<(int, int)> visited = new HashSet<(int, int)>(); //вже відвідані позиції

            queue.Enqueue((startX, startY, 0)); // початкова позиція
            visited.Add((startX, startY)); //додаємо початкову до відвіданих

            while (queue.Count > 0) //поки в черзі є позиції
            {
                var (x, y, distance) = queue.Dequeue(); //видалили поточну позицію та відстань до неї

                if (exits.Contains((x, y))) //якщо поточна позиція по координатам співпадає з виходом
                {
                    return distance + 1; // покидаємо позицію
                }

                foreach (var (dx, dy) in directions)//для кожного нового напрямку (сусіднього) 
                {
                    int newX = x + dx; //координати нової позиції
                    int newY = y + dy;

                    if (IsValid(newX, newY, N, M, basePlan, visited)) //якщо допустима
                    {
                        visited.Add((newX, newY)); //то заносимо у відвідувані та чергу
                        queue.Enqueue((newX, newY, distance + 1));
                    }
                }

                if (tunnels.ContainsKey((x, y))) //робимо те саме й для гіпертунеля
                {
                    var (tunnelExitX, tunnelExitY) = tunnels[(x, y)];
                    if (!visited.Contains((tunnelExitX, tunnelExitY)))
                    {
                        visited.Add((tunnelExitX, tunnelExitY));
                        queue.Enqueue((tunnelExitX, tunnelExitY, distance + 1)); //входимо в гіпертунель
                    }
                }
            }

            return -1; //шлях знайти неможливо
        }

        static bool IsValid(int x, int y, int N, int M, int[,] basePlan, HashSet<(int, int)> visited)
        { //перевірка координат, чи вони в межах бази, чи позиція проходима (без стіни), чи позиція була відвідана
            return x >= 0 && x < N && y >= 0 && y < M && basePlan[x, y] == 0 && !visited.Contains((x, y));
        }
    }
}
