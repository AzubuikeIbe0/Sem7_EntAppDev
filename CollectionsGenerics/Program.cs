using System;
using System.Collections;
using System.ComponentModel.Design;

namespace CollectionsGenerics
{

    public enum Gender { Male, Female, Haemophrodite};
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
            return $"ID: {Id}, Name: {Name}, Gender: {Gender}";
        }

    }

    public class StudentClass : IEnumerable
    {
        public string CRN { get; set; }
        public string Lecturer { get; set; }
        private List <Student> students;

        public StudentClass(string crn, string lecturer)
        {
            this.CRN = crn;
            this.Lecturer = lecturer;
            students = new List<Student>();
        }


        public void addStudent(Student student)
        {

            if(students.Exists(s => s.Id ==student.Id))
            {
                throw new ArgumentException("Student with same ID " + student.Id + " already exist");        
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
                if((i >= 0) && (i < students.Count))
                {
                    return students[i];
                }
                else
                {
                    throw new ArgumentException("Error: Student index out of range");
                }
            }
        }

        public Student this[String id]
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
                    throw new ArgumentException("Error: No matching student found");
                }
            }
        }



        public IEnumerator GetEnumerator()
        {
            foreach(Student student in students)
            {
                yield return student;
            }
        }
    }



}