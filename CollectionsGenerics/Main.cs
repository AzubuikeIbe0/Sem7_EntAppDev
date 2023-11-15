using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsGenerics
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student S1 = new Student("x0029284", "John", Gender.Male);
                Student S2 = new Student("x0092832", "Jessica", Gender.Female);

                StudentClass oosdev2 = new StudentClass("oed1", "Tom");

                oosdev2.addStudent(S2);
                oosdev2.addStudent(S1);

                Console.WriteLine("Class: CRN " + oosdev2.CRN + " Lecturer " + oosdev2.Lecturer);

                foreach(Student s in oosdev2)
                {
                    Console.WriteLine(s);
                }

            }
            catch (ArgumentException e1)
            {
                Console.WriteLine (e1.Message);
            }
            catch(Exception e2)
            {
                Console.WriteLine(e2.Message);
            }
        }
    }
}
