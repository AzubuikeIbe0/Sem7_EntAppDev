using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq;

// Define the Car class
class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string Registration { get; set; }
    public int EngineSize { get; set; }

    // Override the ToString method
    public override string ToString()
    {
        return $"{Make} {Model} ({Registration}), {EngineSize} cc";
    }
}

class Program
{
    static void Main()
    {
        // Create a fleet collection and populate with some cars
        var fleet = new List<Car>()
        {
            new Car() { Make = "Mazda", Model = "3", Registration = "12-D-3456", EngineSize = 1600 },
            new Car() { Make = "Toyota", Model = "Corolla", Registration = "10-D-1234", EngineSize = 1800 },
            new Car() { Make = "Ford", Model = "Fiesta", Registration = "11-D-5678", EngineSize = 1400 },
            new Car() { Make = "Mazda", Model = "6", Registration = "13-D-7890", EngineSize = 2000 },
            new Car() { Make = "Honda", Model = "Civic", Registration = "14-D-2468", EngineSize = 1600 }
        };

        // Write LINQ queries on the fleet

        // 1. List all cars in ascending registration order
        var query1 = from car in fleet
                     orderby car.Registration ascending
                     select car;

        // 2. List the models for all Mazda cars in the fleet
        var query2 = from car in fleet
                     where car.Make == "Mazda"
                     select car.Model;

        // 3. List all cars in descending engine size order
        var query3 = from car in fleet
                     orderby car.EngineSize descending
                     select car;

        // 4. List just the make and model for cars whose engine size is 1600 cc
        var query4 = from car in fleet
                     where car.EngineSize == 1600
                     select new { car.Make, car.Model };

        // 5. Count the number of cars whose engine size is 1600 cc or less
        var query5 = (from car in fleet
                      where car.EngineSize <= 1600
                      select car).Count();

        // Execute the queries and display the results
        Console.WriteLine("Query 1: List all cars in ascending registration order");
        foreach (var car in query1)
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\nQuery 2: List the models for all Mazda cars in the fleet");
        foreach (var model in query2)
        {
            Console.WriteLine(model);
        }

        Console.WriteLine("\nQuery 3: List all cars in descending engine size order");
        foreach (var car in query3)
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\nQuery 4: List just the make and model for cars whose engine size is 1600 cc");
        foreach (var car in query4)
        {
            Console.WriteLine($"{car.Make} {car.Model}");
        }

        Console.WriteLine("\nQuery 5: Count the number of cars whose engine size is 1600 cc or less");
        Console.WriteLine(query5);
    }
}
