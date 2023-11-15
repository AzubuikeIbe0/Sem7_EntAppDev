using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lab7CollectionGenerics
{
    public enum Gender
    {
        Male,
        Female,
    }

    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }

        public Student(string id, string name, Gender gender)
        {
            Id = id;
            Name = name;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"ID: {Id} Name: {Name} Gender: {Gender}";
        }
    }

    public class StudentClass : IEnumerable
    {
        public string Crn { get; set; }
        public string LecturerName { get; set; }
        private List<Student> students;


        public StudentClass(string crn, string lecturerName)
        {
            Crn = crn;
            LecturerName = lecturerName;
            students = new List<Student>();
        }

        public void addStudent(Student student)
        {
            if(students.Exists(s=>s.Id == student.Id))
            {
                throw new ArgumentException("Error: Student already exists");
            }
            else
            {
                students.Add(student);
            }
        }

        public Student this[int i]
        {
            get
            {
                if(i >= 0 && i < students.Count)
                {
                    return students[i];
                }
                else
                {
                    throw new ArgumentException("Index out of range");
                }
            }
        }

        public Student this[string id]
        {
            get
            {
                Student student = students.FirstOrDefault(s => s.Id == id);
                if(student != null)
                {
                    return student;
                }
                else
                {
                    throw new ArgumentException("Student cannot be null");
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach(Student s in students)
            {
                yield return s;
            }
        }
    }


    





 
}