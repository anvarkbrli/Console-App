using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IStudentService
    {
        Student CreateStudent(int groupId, Student student);
        Student UpdateStudent(int id, Student student);
        void DeleteStudent(int id);
        List<Student> SearchStudent(string name, string surname);
        Student GetById(int id);
        List<Student> GetAllStudentsByAge(int age);
        List<Student> GetAllStudentsByGroupId(int id);
    }
}
