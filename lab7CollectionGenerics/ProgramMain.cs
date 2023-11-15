using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7CollectionGenerics
{
    static class ProgramMain
    {

        static void Main()
        {
            try
            {
                Student S1 = new Student("x00", "John", Gender.Male);
                Student S2 = new Student("x01", "Jane", Gender.Female);
                Student S3 = new Student("x02", "Jessy", Gender.Male);

                StudentClass SC1 = new StudentClass("oosdev", "Mike");

                SC1.addStudent(S1);
                SC1.addStudent(S2);
                SC1.addStudent(S3);

                foreach (Student student in SC1)
                {
                    Console.WriteLine(student);
                }

                Student s = SC1["x02"];
                Console.WriteLine("Found: "+ s);
                Student s2 = SC1[1];
                Console.WriteLine("Found: " + s2);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }

       
    }
}
