using ConsoleApplication.Helpers;
using DomainLayer.Entities;
using ServiceLayer.Services.Implementations;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        StudentName: Helper.PrintColor(ConsoleColor.Blue, "Enter Student Name:");
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

        StudentSurname: Helper.PrintColor(ConsoleColor.Blue, "Enter Student Surname:");
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

        StudentAge: Helper.PrintColor(ConsoleColor.Blue, "Enter Student Age:");
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
        public void GetById()
        {
        studentsId:
            Helper.PrintColor(ConsoleColor.Blue, "Enter Student Id");
            string studentId = Console.ReadLine();

            int ID;
            bool isStudentId = int.TryParse(studentId, out ID);

            if (isStudentId)
            {
                Student student = studentService.GetById(ID);

                if (student != null)
                {
                    Helper.PrintColor(ConsoleColor.Green,
                        $"Student ID: {student.Id}, Student Name: {student.Name}, Surname: {student.SurName}, Age: {student.Age}, Group: {student.CourseGroup.Name}");
                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "Student not found!");
                    goto studentsId;
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Enter correct Student Id type");
                goto studentsId;
            }
        }
        public void Update()
        {
        StudentId: Helper.PrintColor(ConsoleColor.Blue, "Enter Student Id");
            string studentId = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(studentId))
            {
                Helper.PrintColor(ConsoleColor.Red, "Update operation canceled");
                goto StudentId;
            }

            int id;
            bool isStudentId = int.TryParse(studentId, out id);

            if (!isStudentId)
            {
                Helper.PrintColor(ConsoleColor.Red, "Enter correct Student Id");
                goto StudentId;
            }

            var findStudent = studentService.GetById(id);

            if (findStudent == null)
            {
                Helper.PrintColor(ConsoleColor.Red, "Student doesn't exist");
                goto StudentId;
            }

        StudentName: Helper.PrintColor(ConsoleColor.Blue, $"Current name: {findStudent.Name}. Enter new student name:");
            string newStudentName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newStudentName))
            {
                newStudentName = findStudent.Name;
            }

            if (newStudentName.Any(char.IsDigit))
            {
                Helper.PrintColor(ConsoleColor.Red, "Student name cannot contain numbers");
                goto StudentName;
            }
            if (string.Equals(newStudentName, findStudent.Name, StringComparison.OrdinalIgnoreCase))
            {
                Helper.PrintColor(ConsoleColor.Red, "This name is the same. Enter a different name.");
                goto StudentName;
            }

        StudentSurname: Helper.PrintColor(ConsoleColor.Blue, $"Current surname: {findStudent.SurName}. Enter new student surname:");
            string newStudentSurname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newStudentSurname))
            {
                newStudentSurname = findStudent.SurName;
            }

            if (newStudentSurname.Any(char.IsDigit))
            {
                Helper.PrintColor(ConsoleColor.Red, "Student surname cannot contain numbers");
                goto StudentSurname;
            }
            if(string.Equals(newStudentSurname, findStudent.SurName, StringComparison.OrdinalIgnoreCase))
            {
                Helper.PrintColor(ConsoleColor.Red, "This surname is the same. Enter a different surname.");
                goto StudentSurname;
            }
           

        StudentAge: Helper.PrintColor(ConsoleColor.Blue, $"Current age: {findStudent.Age}. Enter new student age:");
            string newStudentAge = Console.ReadLine();

            int age = findStudent.Age;

            if (!string.IsNullOrWhiteSpace(newStudentAge))
            {
                bool isAge = int.TryParse(newStudentAge, out age);

                if (!isAge)
                {
                    Helper.PrintColor(ConsoleColor.Red, "Enter correct age type");
                    goto StudentAge;
                }

                if (age <= 0)
                {
                    Helper.PrintColor(ConsoleColor.Red, "Age must be greater than 0");
                    goto StudentAge;
                }

                if (age == findStudent.Age)
                {
                    Helper.PrintColor(ConsoleColor.Red, "This age is the same. Enter a different age.");
                    goto StudentAge;
                }
            }

        GroupId: Helper.PrintColor(ConsoleColor.Blue, $"Current group: {findStudent.CourseGroup.Name}. Enter new group Id:");
            string newGroupId = Console.ReadLine();

            CourseGroup group = findStudent.CourseGroup;

            if (!string.IsNullOrWhiteSpace(newGroupId))
            {
                int groupId;
                bool isGroupId = int.TryParse(newGroupId, out groupId);

                if (!isGroupId)
                {
                    Helper.PrintColor(ConsoleColor.Red, "Enter correct Group Id type");
                    goto GroupId;
                }

                if (findStudent.CourseGroup != null && findStudent.CourseGroup.Id == groupId)
                {
                    Helper.PrintColor(ConsoleColor.Red, "Student is already in this group. Enter different Group Id");
                    goto GroupId;
                }

                var findGroup = groupService.GetById(groupId);

                if (findGroup == null)
                {
                    Helper.PrintColor(ConsoleColor.Red, "Group not found");
                    goto GroupId;
                }
                if(findGroup.Id == findStudent.CourseGroup.Id)
                {
                    Helper.PrintColor(ConsoleColor.Red, "This group is the same. Enter a different age.");
                    goto GroupId;
                }

                group = findGroup;
            }

            Student student = new Student { Name = newStudentName, SurName = newStudentSurname, Age = age, CourseGroup = group };

            var updatedStudent = studentService.UpdateStudent(id, student);

            if (updatedStudent == null)
            {
                Helper.PrintColor(ConsoleColor.Red, "Student is not updated, please try again");
                goto StudentId;
            }

            Helper.PrintColor(ConsoleColor.Green,
                $"Student updated succesfully! ID: {updatedStudent.Id}, Name: {updatedStudent.Name}, Surname: {updatedStudent.SurName}, Age: {updatedStudent.Age}, Group: {updatedStudent.CourseGroup.Name}");
        }
        public void Delete()
        {
        StudentId: Helper.PrintColor(ConsoleColor.Blue, "Enter id to delete student:");
            int id;
            string studentId = Console.ReadLine();
            bool isStudentId = int.TryParse(studentId, out id);

            if (isStudentId)
            {
                Student student = studentService.GetById(id);
                if (student != null)
                {
                    studentService.DeleteStudent(id);
                    Helper.PrintColor(ConsoleColor.Green, $"Student {student.Name} has been deleted!");

                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "Student not found!!");
                    goto StudentId;
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Enter correct student id type!!");
                goto StudentId;
            }
        }
        public void GetAll()
        {
            List<Student> students = studentService.GetAllStudents();
            if (students.Count > 0)
            {
                foreach (var s in students)
                {
                    Helper.PrintColor(ConsoleColor.Green, $"Student ID: {s.Id}, Name: {s.Name}, Surname: {s.SurName}, Age: {s.Age}, Student Group: {s.CourseGroup.Name}");

                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Group is empty, please add students");
            }
        }
        public void GetAllStudentsByAge()
        {
        StudentAge: Helper.PrintColor(ConsoleColor.Blue, "Enter student age:");
            string studentAge = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(studentAge))
            {
                Helper.PrintColor(ConsoleColor.Red, "Please enter student age");
                goto StudentAge;
            }

            int age;
            bool isStudentAge = int.TryParse(studentAge, out age);

            if (!isStudentAge)
            {
                Helper.PrintColor(ConsoleColor.Red, "Enter correct age type");
                goto StudentAge;
            }

            if (age <= 0)
            {
                Helper.PrintColor(ConsoleColor.Red, "Age of the student cannot equal to zero or be lesser!");
                goto StudentAge;
            }

            List<Student> students = studentService.GetAllStudentsByAge(age);

            if (students.Count > 0)
            {
                foreach (var s in students)
                {
                    Helper.PrintColor(ConsoleColor.Green, $"Student ID: {s.Id}, Name: {s.Name}, Surname: {s.SurName}, Age: {s.Age}, Student Group: {s.CourseGroup.Name}");
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Student does not exist");
                goto StudentAge;
            }
        }
        public void GetAllStudentsByGroupId()
        {
        GroupId:
            Helper.PrintColor(ConsoleColor.Blue, "Enter group ID:");
            string newGroupId = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newGroupId))
            {
                Helper.PrintColor(ConsoleColor.Red, "Please enter group ID");
                goto GroupId;
            }

            int id;
            bool isGroupId = int.TryParse(newGroupId, out id);

            if (!isGroupId)
            {
                Helper.PrintColor(ConsoleColor.Red, "Enter correct Group Id type");
                goto GroupId;
            }

            if (id <= 0)
            {
                Helper.PrintColor(ConsoleColor.Red, "Group Id cannot be zero or less");
                goto GroupId;
            }

            List<Student> students = studentService.GetAllStudentsByGroupId(id);

            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    Helper.PrintColor(ConsoleColor.Green,
                        $"Student ID: {student.Id}, Name: {student.Name}, Surname: {student.SurName}, Age: {student.Age}, Student Group: {student.CourseGroup.Name}");
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "No student found for this group");
                goto GroupId;
            }
        }
        public void SearchStudent()
        {
        SearchStudent:
            Helper.PrintColor(ConsoleColor.Blue, "Enter student name (or press Enter to skip):");
            string name = Console.ReadLine();

            Helper.PrintColor(ConsoleColor.Blue, "Enter student surname (or press Enter to skip):");
            string surname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(surname))
            {
                Helper.PrintColor(ConsoleColor.Red, "At least one field must be filled!");
                goto SearchStudent;
            }

            // Rəqəm yoxlanışı
            if (!string.IsNullOrWhiteSpace(name) && name.Any(char.IsDigit))
            {
                Helper.PrintColor(ConsoleColor.Red, "Name cannot contain numbers!");
                goto SearchStudent;
            }

            if (!string.IsNullOrWhiteSpace(surname) && surname.Any(char.IsDigit))
            {
                Helper.PrintColor(ConsoleColor.Red, "Surname cannot contain numbers!");
                goto SearchStudent;
            }

            var students = studentService.SearchStudent(name, surname);

            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    Helper.PrintColor(ConsoleColor.Green,
                        $"Student ID: {student.Id}, Name: {student.Name}, Surname: {student.SurName}, Age: {student.Age}, Student Group: {student.CourseGroup.Name}");
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "No matching students found!");
            }
        }
    }
}






