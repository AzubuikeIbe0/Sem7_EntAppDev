using CollectionsGenerics2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsGeneric2
{
    static class TextClass
    {
        public static void Main(string[] args)
        {

            try
            {
                Student S1 = new Student("x001", "Foo", Gender.Male);
                Student S2 = new Student("x002", "Bar", Gender.Female);
                Student S3 = new Student("x003", "Booz", Gender.Male);

                StudentClass sdev2 = new StudentClass("os2", "Mike");
                sdev2.AddStudent(S3);
                sdev2.AddStudent(S2);
                sdev2.AddStudent(S1);

                Console.WriteLine("CRN: " + sdev2.Crn + "\nLecturer: " + sdev2.Lecturer);
                Console.WriteLine("-----------------------------------");

                foreach (Student student in sdev2)
                {
                    Console.WriteLine(student);
                    Console.WriteLine("------------------------------------");
                }

                // Testing the indexes
                Student s = sdev2["x005"];
                Console.WriteLine("Found: " + s);

                Student s2 = sdev2[2];
                Console.WriteLine("Found: " + s2);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
