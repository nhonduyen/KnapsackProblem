using KnapsackProblem;

int[] values = { 60, 100, 120 };
int[] weights = { 10, 20, 30 };
int capacity = 50;

int maxValue = await KnapsackResolver.Knapsack(values, weights, capacity);
Console.WriteLine("Maximum value in Knapsack: " + maxValue);