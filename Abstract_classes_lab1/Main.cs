using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Abstract_classes_lab1
{
    static class MainTest
    {

        static void Main(string[] args)
        {
            Sphere s1 = new Sphere(5);
            Sphere s2 = new Sphere(10);
            Sphere s3 = new Sphere(15);


           /* Console.WriteLine(s1.CalcVol());
            Console.WriteLine(s1.ToString());*/


            List<Sphere> spheres = new List<Sphere> {s1, s2, s3 };

            /*spheres.Add(s1);
            spheres.Add(s2);
            spheres.Add(s3);*/

            foreach (Sphere s in spheres)
            {
               /*Console.WriteLine(s.CalcVol());*/
               Console.WriteLine(s.ToString());
            }

        }
    }
}
