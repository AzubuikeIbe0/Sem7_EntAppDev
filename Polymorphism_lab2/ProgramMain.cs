using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_lab2
{

        static class Program
        {
            static void Main(string[] args)
            {
                Vertex V1 = new Vertex(8, 34);

                Console.WriteLine(V1.ToString());

            /*Shape s1 = new Shape(Colors.red);*/

            Line L1 = new Line(2, 3, 6, 4, Colors.red);
            Console.WriteLine(L1.ToString());

            Circle C1 = new Circle(3, 7, 5, Colors.green);
            Console.WriteLine(C1.ToString());

            Shape[] collection = {new Circle(3, 7, 5, Colors.red), new Line(2,3,4,5,Colors.blue), new Circle(8,90, 35, Colors.green), new Line(6,9, 12, 45, Colors.red) };
            Console.WriteLine(collection[0].ToString());

            }


        }
    
}
