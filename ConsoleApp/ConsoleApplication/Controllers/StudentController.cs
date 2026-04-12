using ConsoleApplication.Helpers;
using DomainLayer.Entities;
using ServiceLayer.Services.Implementations;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Controllers
{
    public class StudentController
    {
        StudentService studentService = new();
        GroupService groupService = new();
        public void Create()
        {
        GroupId: Helper.PrintColor(ConsoleColor.Blue, "Enter Group ID");
            string groupId = Console.ReadLine();
            int groupID;
            bool isGroupId = int.TryParse(groupId, out groupID);
            var findGroup = groupService.GetById(groupID);
            if (findGroup is null)
            {
                Helper.PrintColor(ConsoleColor.Red, "Group not found!");
                goto GroupId;
            }

        StudentName:Helper.PrintColor(ConsoleColor.Blue, "Enter Student Name:");
            string studentName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(studentName))
            {
                Helper.PrintColor(ConsoleColor.Red, "Student name cannot be empty");
                goto StudentName;
            }

            if (studentName.Any(char.IsDigit))
            {
                Helper.PrintColor(ConsoleColor.Red, "Student name cannot contain numbers");
                goto StudentName;
            }

        StudentSurname:Helper.PrintColor(ConsoleColor.Blue, "Enter Student Surname:");
            string studentSurname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(studentSurname))
            {
                Helper.PrintColor(ConsoleColor.Red, "Student surname cannot be empty");
                goto StudentSurname;
            }

            if (studentSurname.Any(char.IsDigit))
            {
                Helper.PrintColor(ConsoleColor.Red, "Student surname cannot contain numbers");
                goto StudentSurname;
            }

        StudentAge:Helper.PrintColor(ConsoleColor.Blue, "Enter Student Age:");
            string studentAge = Console.ReadLine();

            int age;
            bool isStudentAge = int.TryParse(studentAge, out age);

            if (isStudentAge)
            {
                Student student = new Student { Name = studentName, SurName = studentSurname, Age = age, CourseGroup = findGroup };
                var createResult = studentService.CreateStudent(groupID, student);
                Helper.PrintColor(ConsoleColor.Green, $"Student ID: {student.Id}, Student Name: {student.Name}, Surname: {student.SurName}, Age: {student.Age}, Group: {student.CourseGroup.Name} ");
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Enter correct age");
                goto StudentAge;
            }



            
        }
        public void GetById(int id)
        {
        studentsId: Helper.PrintColor(ConsoleColor.Blue, "Enter Student Id");
            string studentId = Console.ReadLine();
            int ID;
            bool isStudentId = int.TryParse(studentId, out ID);
            if (isStudentId)
            {
                Student student = studentService.GetById(id);
                if (student != null)
                {
                    Helper.PrintColor(ConsoleColor.Green, $"Student ID: {student.Id}, Student Name: {student.Name}, Surname: {student.SurName}, Age: {student.Age}, Group: {student.CourseGroup.Name} ");

                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "Group not found!");
                    goto studentsId;

                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Enter correct library Id type");
                goto studentsId;
            }
        }


    }
}

