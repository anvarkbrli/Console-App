using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Implementations
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student data)
        {
            try
            {
                if (data == null) throw new NotFoundException("Data not found");
                AppDBContext<Student>.datas.Add(data);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Student data)
        {
            AppDBContext<Student>.datas.Remove(data);
        }
        public Student Get(Predicate<Student> predicate)
        {
            return predicate != null ? AppDBContext<Student>.datas.Find(predicate) : null;
        }
        public List<Student> GetAll(Predicate<Student> predicate = null)
        {
            return predicate != null ? AppDBContext<Student>.datas.FindAll(predicate) : AppDBContext<Student>.datas;
        }

        public List<Student> GetAllStudentsByAge(int age)
        {
            return AppDBContext<Student>.datas.Where(s => s.Age == age).ToList();
        }

        public List<Student> GetAllStudentsByGroupId(int groupId)
        {
            return AppDBContext<Student>.datas.Where(s => s.CourseGroup != null && s.CourseGroup.Id == groupId).ToList();
        }

        public void Update(Student data)
        {
            var existStudent = AppDBContext<Student>.datas.Find(g => g.Id == data.Id);

            if (existStudent == null)
            {
                throw new NotFoundException("Student not found");
            }

            existStudent.Name = data.Name;
            existStudent.SurName = data.SurName;
            existStudent.Age = data.Age;
            existStudent.CourseGroup = data.CourseGroup;
        }
        public List<Student> SearchStudents(string name, string surname)
        {
            return AppDBContext<Student>.datas.Where(s => (string.IsNullOrWhiteSpace(name) || s.Name.ToLower().Contains(name.ToLower())) && (string.IsNullOrWhiteSpace(surname) || s.SurName.ToLower().Contains(surname.ToLower()))).ToList();
            {
            }
        }
    }
}
