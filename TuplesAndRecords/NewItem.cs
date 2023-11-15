using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // A method that returns a tuple with named fields for average and median
    static (double average, double median) CalculateStats(IEnumerable<int> values)
    {
        // Check if the collection is empty or null
        if (values == null || !values.Any())
        {
            throw new ArgumentException("The collection cannot be empty or null.");
        }

        // Calculate the average using LINQ
        double average = values.Average();

        // Sort the collection and find the middle element(s)
        var sorted = values.OrderBy(x => x).ToList();
        int count = sorted.Count;
        int middle = count / 2;

        // Calculate the median depending on the parity of the count
        double median;
        if (count % 2 == 0) // Even number of elements
        {
            // The median is the average of the middle two elements
            median = (sorted[middle - 1] + sorted[middle]) / 2.0;
        }
        else // Odd number of elements
        {
            // The median is the middle element
            median = sorted[middle];
        }

        // Return a tuple with named fields
        return (average, median);
    }

    static void Main(string[] args)
    {
        // Test the method with some examples
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var array = new int[] { 6, 7, 8, 9, 10 };
        var queue = new Queue<int>(new[] { 11, 12, 13, 14, 15 });

        // Invoke the method and print the results
        Console.WriteLine($"The average and median of {string.Join(", ", list)} are {CalculateStats(list)}");
        Console.WriteLine($"The average and median of {string.Join(", ", array)} are {CalculateStats(array)}");
        Console.WriteLine($"The average and median of {string.Join(", ", queue)} are {CalculateStats(queue)}");
    }
}
