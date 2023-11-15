using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsGenerics2
{
    public enum Gender { 
        Male, 
        Female
    }

    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }

        public Student(string id, string name, Gender gender)
        {
            this.Id = id;
            this.Name = name;
            this.Gender = gender;
        }

        public override string ToString()
        {
            return $"ID: {Id}\nName: {Name}\nGender: {Gender}";
        }

    }

    public class StudentClass : IEnumerable
    {
        public string Crn { get; set; }
        public string Lecturer { get; set; }
        private List<Student> students;

        public StudentClass(string crn, string lecturer)
        {
            this.Crn = crn;
            this.Lecturer = lecturer;
            students = new List<Student>();
        }


        public void AddStudent(Student student)
        {
            if (students.Exists(s => s.Id == student.Id))
            {
                throw new ArgumentException("Error: Student with ID" + student.Id + " is already in the list");
            }
            else
            {
                students.Add(student);
            }
        }

      /*  public void AddStudent(Student student)
        {
            foreach (var existingStudent in students)
            {
                if (((Student)existingStudent).Id == student.Id)
                {
                    throw new ArgumentException("Error: Student with ID " + student.Id + " is already in the list");
                }
            }

            students.Add(student);
        }*/

        public Student this[int index]
        {
            get
            {
                if(index >= 0 && index < students.Count)
                {
                    return students[index];
                }
                else
                {
                    throw new ArgumentException("Error: Index out of range");
                }
            }
        }


        public Student this[string id]
        {
            get
            {
                Student student = students.FirstOrDefault(s => s.Id == id);

                if (student != null)
                {
                    return student;  
                }
                else
                {
                    throw new ArgumentException("Student cannot be null");
                }
            }
        }


       /* public Student this[string id]
        {
            get
            {
                Student student = students.Cast<Student>().FirstOrDefault(s => s.Id == id);

                if (student == null)
                {
                    throw new ArgumentException("Student cannot be null");
                }
                else
                {
                    return student;
                }
            }
        }*/



        public IEnumerator GetEnumerator()
        {
           foreach(Student student in students)
            {
                yield return student;
            }
        }
    }

}