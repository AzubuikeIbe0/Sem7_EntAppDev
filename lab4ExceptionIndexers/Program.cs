using System;
using System.Text;
using System.Xml;

namespace lab4ExceptionIndexers
{
    public class Calculator
    {

        public static double DivideNum(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new ArgumentException("Cannot divide by 0");
            }
            else
            {
                return num1 / num2;
            }
        }

    }

    public class ModuleCA
    {
        public string Name { get; set; }
        public int NumCredits { get; set; }
        public string ModuleName { get; set; }

        private const int MAX = 50;

        private double[] results = new double[MAX];

        private int next = 0;


        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append($"Name: {Name}\nNumber of Credits: {NumCredits}\nModule Name: {ModuleName}");
            for (int i = 0; i < next; i++)
            {
                output.Append(results[i] + " ");
            }
            return output.ToString();
        }



        public double this[int CA]
        {
            get
            {
                int index = CA - 1;
                if ((index >= 0) && (index < next))
                {
                    return results[index];
                }
                else
                {
                    throw new ArgumentException("Invalid CA number");
                }
            }
            set
            {
                int index = CA - 1;

                if((index >= 0) && (index <= next) && (index < (MAX)))
                {
                    results[index] = value;
                    if(index == next)
                    {
                        next++;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid CA number");
                    }

                }
            }
        }


    }
}