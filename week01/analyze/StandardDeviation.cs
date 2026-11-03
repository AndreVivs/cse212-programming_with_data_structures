/// <summary>
/// These 3 functions will (in different ways) calculate the standard
/// deviation from a list of numbers.  The standard deviation
/// is defined as the square root of the variance.  The variance is 
/// defined as the average of the squared differences from the mean.
/// </summary>
public static class StandardDeviation {
    public static void Run() {
        var numbers = new[] { 600, 470, 170, 430, 300 };
        Console.WriteLine(StandardDeviation1(numbers)); // Should be 147.322 
        Console.WriteLine(StandardDeviation2(numbers)); // Should be 147.322 
        Console.WriteLine(StandardDeviation3(numbers)); // Should be 147.322 
    }
// big O notation: O(n) Linear time complexity.
    private static double StandardDeviation1(int[] numbers) {
        var total = 0.0;
        var count = 0;
        foreach (var number in numbers) {
            total += number;
            count += 1;
        }

        var avg = total / count;
        var sumSquaredDifferences = 0.0;
        foreach (var number in numbers) {
            sumSquaredDifferences += Math.Pow(number - avg, 2);
        }

        var variance = sumSquaredDifferences / count;
        return Math.Sqrt(variance);
    }

// big O notation: O(n^2) Quadratic time complexity, where n is the number of elements in the array.
// This is because there are two nested loops: the outer loop runs n times,
// and for each iteration of the outer loop, the inner loop runs up to n times in the worst case.
    private static double StandardDeviation2(int[] numbers) {
        var sumSquaredDifferences = 0.0;
        var countNumbers = 0;
        foreach (var number in numbers) {
            var total = 0;
            var count = 0;
            foreach (var value in numbers) {
                total += value;
                count += 1;
            }

            var avg = total / count;
            sumSquaredDifferences += Math.Pow(number - avg, 2);
            countNumbers += 1;
        }

        var variance = sumSquaredDifferences / countNumbers;
        return Math.Sqrt(variance);
    }

// big O notation: O(n) Linear time complexity.
    private static double StandardDeviation3(int[] numbers) {
        var count = numbers.Length;
        var avg = (double)numbers.Sum() / count;
        var sumSquaredDifferences = 0.0;
        foreach (var number in numbers) {
            sumSquaredDifferences += Math.Pow(number - avg, 2);
        }

        var variance = sumSquaredDifferences / count;
        return Math.Sqrt(variance);
    }
}

//3. Other Common Big O Notations**

// Merge Sort: O(n log n) — Linearithmic Time.
// Traveling Salesman:** O(2^n) — Exponential Time (for the exponential approach discussed in the assignment).

//4. Big O Notations Ranked from Best to Worst Performance (for large n)**

//1. O(1) — Constant Time
//2. O(log n) — Logarithmic Time
//3. O(n) — Linear Time
//4. O(n log n) — Linearithmic Time
//5. O(n²) — Quadratic Time
//6. O(2^n) — Exponential Time

//Constant time offers the best asymptotic performance because its number of operations does not grow with the input size.
// Logarithmic and linear algorithms grow relatively slowly, while quadratic and exponential algorithms grow much faster
// as the input size increases.