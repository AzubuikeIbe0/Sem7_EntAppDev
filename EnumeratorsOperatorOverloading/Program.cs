using System;
using System.Collections;
using System.Collections.Generic;

namespace EnumeratorsOperatorOverloading
{
    public enum Gender { Male, Female }

    // A student
    public class Student
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public Gender Gender { get; set; }

        public Student(String id, String name, Gender gender)
        {
            this.Id = id;
            this.Name = name;
            this.Gender = gender;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Gender: {Gender}";
        }
    }

    // A student class
    public class StudentClass : IEnumerable<Student>
    {
        public String Crn { get; set; }
        public String Lecturer { get; set; }

        private List<Student> students = new List<Student>();

        public StudentClass(String crn, String lecturer)
        {
            this.Crn = crn;
            this.Lecturer = lecturer;
        }

        public void AddStudent(Student student)
        {
            if (students.Exists(s => s.Id == student.Id))
            {
                throw new ArgumentException("Error: Student " + student.Name + " is already in the class");
            }
            students.Add(student);
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return students.GetEnumerator();
        }

        // Explicit interface implementation for non-generic IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
