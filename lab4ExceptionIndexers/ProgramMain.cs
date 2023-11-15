using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4ExceptionIndexers
{
    static class ProgramMain
    {
        static void Main(string[] args)
        {
            Calculator C1 = new Calculator();

            try
            {
                double num1 = 0, num2 = 0;
                bool valid = true;

                do
                {
                    try
                    {
                        Console.WriteLine("Enter 1st number: ");
                        num1 = Double.Parse(Console.ReadLine());
                        valid = true;
                    }
                    catch (FormatException)
                    {
                        valid = false;
                    }
                    catch(OverflowException)
                    {
                        valid=false;
                    }
                } while (!valid);


                do
                {
                    try
                    {
                        Console.WriteLine("Enter 2nd number: ");
                        num2 = Double.Parse(Console.ReadLine());
                        valid = true;
                    }
                    catch(Exception)
                    {
                        valid = false;
                    }
                } while (!valid);
            }
            catch(ArgumentException e1)
            {
                Console.WriteLine(e1.Message);
            }

            double results = Calculator.DivideNum(10, 5);

            Console.WriteLine(results);

            try
            {
                ModuleCA result = new ModuleCA() { Name = "John", NumCredits = 10, ModuleName = "oosdev" };

                result[1] = 24;
                result[2] = 85;
                result[3] = 89;
                result[4] = 99;
                result[5] = 102;

                Console.WriteLine(result);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

       
    }
}
