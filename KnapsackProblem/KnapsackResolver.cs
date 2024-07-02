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

        public static (int MaxValue, List<int> SelectedItems) KnapsackDP(int[] weights, int[] values, int capacity)
        {
            int n = weights.Length;
            int[,] dp = new int[n + 1, capacity + 1];

            // Build table dp[][] in bottom up manner
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

            // Find the selected items
            List<int> selectedItems = new List<int>();
            int maxValue = dp[n, capacity];
            int remainingCapacity = capacity;

            for (int i = n; i > 0 && maxValue > 0; i--)
            {
                // If the value comes from the top (dp[i-1][w]), it means the item is not included
                if (maxValue != dp[i - 1, remainingCapacity])
                {
                    // This item is included.
                    selectedItems.Add(i - 1);

                    // Since this weight is included, its value is deducted
                    maxValue -= values[i - 1];
                    remainingCapacity -= weights[i - 1];
                }
            }

            selectedItems.Reverse(); // Reverse to maintain the order of items as in the original array

            return (dp[n, capacity], selectedItems);
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
                    //Console.Write(matrix[i, j] + "\t");
                }
                await streamWriter.WriteLineAsync(line);
                //Console.WriteLine();
            }
        }
    }
}
