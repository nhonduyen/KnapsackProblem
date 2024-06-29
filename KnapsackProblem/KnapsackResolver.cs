namespace KnapsackProblem
{
    public class KnapsackResolver
    {
        public static async Task<int> Knapsack(int[] values, int[] weights, int capacity)
        {
            int n = values.Length;
            int[,] dp = new int[n + 1, capacity + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= capacity; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        dp[i, w] = 0;
                    }
                    else if (weights[i - 1] <= w)
                    {
                        dp[i, w] = Math.Max(values[i - 1] + dp[i - 1, w - weights[i - 1]], dp[i - 1, w]);
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];
                    }
                }
            }

            await Print2DArray<int>(dp);

            return dp[n, capacity];
        }

        public static async Task Print2DArray<T>(T[,] matrix)
        {
            var file = "matrix.txt";
            using var streamWriter = new StreamWriter(file);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var line = string.Empty;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    line += matrix[i, j] + "\t";
                    Console.Write(matrix[i, j] + "\t");
                }
                await streamWriter.WriteLineAsync(line);
                Console.WriteLine();
            }
        }
    }
}
