using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Test the CalculateAverageAndMedian method
        List<int> numbers = new List<int> { 12, 7, 3, 14, 9, 20 };
        var result = CalculateAverageAndMedian(numbers);
        Console.WriteLine($"Average: {result.Average}, Median: {result.Median}");

        // Test the Employee record
        var employee1 = new Employee(1, "John Doe", "123 Main St");
        Console.WriteLine(employee1);

        var employee2 = employee1 with { Address = "456 Elm St" };
        Console.WriteLine(employee2);

        // Test the deconstructor
        var (id, name, address) = employee2;
        Console.WriteLine($"Deconstructed: ID: {id}, Name: {name}, Address: {address}");
    }

    public static (double Average, double Median) CalculateAverageAndMedian(IEnumerable<int> numbers)
    {
        List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();
        double average = sortedNumbers.Average();

        double median;
        if (sortedNumbers.Count % 2 == 0)
        {
            int mid1 = sortedNumbers.Count / 2;
            int mid2 = mid1 - 1;
            median = (sortedNumbers[mid1] + sortedNumbers[mid2]) / 2.0;
        }
        else
        {
            int mid = sortedNumbers.Count / 2;
            median = sortedNumbers[mid];
        }

        return (average, median);
    }
}

record Employee(int StaffId, string Name, string Address);
