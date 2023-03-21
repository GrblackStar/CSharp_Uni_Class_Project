using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal class StudentData
    {
        public static List<Student> TestStudents { get; private set; }

        public StudentData()
        {
            TestStudents = new List<Student>();
            AddStudent(newStudent);
            /*
                StudentData data = new StudentData();
                Student student = new Student();
                student.name = "John";
                student.surname = "John";
                // set other properties
                data.AddStudent(student);
            */
        }


        // Create a new student object for the example
        Student newStudent = new Student
        {
            name = "John",
            surname = "John",
            familyname = "John",
            faculty = "Faculty of Computer Science",
            specialty = "Computer Science",
            qualificationDegree = "Bachelor",
            statusOfStudying = "Enrolled",
            facultyNumber = "12345",
            course = 2,
            potok = 10,
            group = 43
        };
       
        public void AddStudent(Student student)
        {
            TestStudents.Add(student);
        }

    }
}
