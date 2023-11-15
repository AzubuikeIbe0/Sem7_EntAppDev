using System;

// A record for an Employee with a staff ID, a name, and an address
record Employee(int StaffID, string Name, string Address);

class Program
{
    static void Main(string[] args)
    {
        // Test the record by creating an employee
        var employee = new Employee(123, "Alice", "Dublin");

        // Print the employee details
        Console.WriteLine(employee);

        // Test the copying feature by creating a copy with a different address
        var employeeCopy = employee with { Address = "Cork" };

        // Print the copy details
        Console.WriteLine(employeeCopy);

        // Test the value equality feature by comparing the employee and the copy
        Console.WriteLine($"Are the employee and the copy equal? {employee == employeeCopy}");

        // Test the deconstructor feature by extracting the fields of the employee
        var (id, name, address) = employee;

        // Print the extracted fields
        Console.WriteLine($"The employee has ID {id}, name {name}, and address {address}");
    }
}
