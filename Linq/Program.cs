using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq;

public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string Registration { get; set; }
    public int EngineSize { get; set; }

    public override string ToString()
    {
        return $"{Make} {Model} - {Registration} - {EngineSize} cc";
    }
}



class Program
{
    static void Main()
    {
        List<Car> fleet = new List<Car>
        {
            new Car { Make = "Toyota", Model = "Camry", Registration = "ABC123", EngineSize = 2000 },
            new Car { Make = "Mazda", Model = "CX-5", Registration = "DEF456", EngineSize = 1800 },
            new Car { Make = "Ford", Model = "Focus", Registration = "GHI789", EngineSize = 1600 },
            // Add more cars as needed
        };

        // 1. List all cars in ascending registration order
        var carsByRegistration = fleet.OrderBy(car => car.Registration);
        PrintCars("Cars in ascending registration order:", carsByRegistration);

        // 2. List the models for all Mazda cars in the fleet
        var mazdaModels = fleet.Where(car => car.Make == "Mazda").Select(car => car.Model);
        Console.WriteLine("Mazda car models:");
        foreach (var model in mazdaModels)
        {
            Console.WriteLine(model);
        }

        // 3. List all cars in descending engine size order
        var carsByEngineSize = fleet.OrderByDescending(car => car.EngineSize);
        PrintCars("Cars in descending engine size order:", carsByEngineSize);

        // 4. List just the make and model for cars whose engine size is 1600 cc
        var carsWith1600CC = fleet.Where(car => car.EngineSize == 1600).Select(car => $"{car.Make} {car.Model}");
        Console.WriteLine("Cars with engine size 1600 cc:");
        foreach (var carInfo in carsWith1600CC)
        {
            Console.WriteLine(carInfo);
        }

        // 5. Count the number of cars whose engine size is 1600 cc or less
        var countOfSmallEngineCars = fleet.Count(car => car.EngineSize <= 1600);
        Console.WriteLine($"Number of cars with engine size 1600 cc or less: {countOfSmallEngineCars}");
    }

    static void PrintCars(string header, IEnumerable<Car> cars)
    {
        Console.WriteLine(header);
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
        Console.WriteLine();
    }
}
