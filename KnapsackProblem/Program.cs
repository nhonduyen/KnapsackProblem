using KnapsackProblem;

int[] values = { 60, 100, 120 };
int[] weights = { 10, 20, 30 };
int capacity = 50;

Console.WriteLine($"Values: {string.Join(" ", values)}");
Console.WriteLine($"Weights: {string.Join(" ", weights)}");
Console.WriteLine($"Capacity: {capacity}");

int maxValue = await KnapsackResolver.Knapsack(values, weights, capacity);
Console.WriteLine("Method 1: Maximum value in Knapsack: " + maxValue);

var result = KnapsackResolver.KnapsackDP(weights, values, capacity);
Console.WriteLine($"Method 2: Maximum value in knapsack: {result.MaxValue}");
Console.WriteLine("Selected items (0-based index): " + string.Join(", ", result.SelectedItems));
Console.WriteLine($"{string.Join(" + ", result.SelectedItems.Select(x => values[x]))} = {result.SelectedItems.Sum(x => values[x])}");
