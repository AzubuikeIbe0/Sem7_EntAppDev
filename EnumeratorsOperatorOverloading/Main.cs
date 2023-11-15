using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorsOperatorOverloading
{
    static class TestProgram
    {
        static void Main(string[] args)
        {
           
                try
                {

                    Student s1 = new Student("X00000111", "Joe Soap", Gender.Male);
                    Student s2 = new Student("X00000222", "Jane Doe", Gender.Female);

                    StudentClass oosdev2 = new StudentClass("ead1", "Gary Clynch");

                    oosdev2.AddStudent(s1);
                    oosdev2.AddStudent(s2);

                    // Print details of class and each student using a foreach loop
                    Console.WriteLine("Class: CRN " + oosdev2.Crn + " Lecturer " + oosdev2.Lecturer);
                    foreach (Student student in oosdev2)
                    {
                        Console.WriteLine(student);
                    }

           
                }
                catch (ArgumentException e1)
                {
                    Console.WriteLine(e1.Message);
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2.Message);
                }
            }

        
    }
}
