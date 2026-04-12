using DomainLayer.Entities;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Interfaces;

namespace ServiceLayer.Services.Implementations
{ }

    public class StudentService : IStudentService
    {
        private StudentRepository studentRepository;
        private int count = 1;
        public StudentService()
        {
            studentRepository = new StudentRepository();
        }
        public Student CreateStudent(int groupId, Student student)
        {
            student.Id = count;
            var groups = studentRepository.GetAll();

            while (groups.Any(g => g.Id == count))
            {
                count++;
            }
            student.Id = count;
            studentRepository.Create(student);
            return student;
        }
        public void DeleteStudent(int id)
        {
            Student student = GetById(id);
            studentRepository.Delete(student);
        }
        public List<Student> GetAllStudents()
        {
            return studentRepository.GetAll();
        }
        public List<Student> GetAllStudentsByAge(int age)
        {
            return studentRepository.GetAllStudentsByAge(age);
        }
        public List<Student> GetAllStudentsByGroupId(int id)
        {
             return studentRepository.GetAllStudentsByGroupId(id);
        }
        public Student GetById(int id)
        {
            Student student = studentRepository.Get(l => l.Id == id);
            if (student is null) return null;
            return student;
        }
        public List<Student> SearchStudent(string name, string surname)
        {
            return studentRepository.SearchStudents(name, surname);
        }
        public Student UpdateStudent(int id, Student student)
    {
        var existStudent = GetById(id);

        if (existStudent == null)
        {
            return null;
        }

        existStudent.Name = student.Name;
        existStudent.SurName = student.SurName;
        existStudent.Age = student.Age;
        existStudent.CourseGroup = student.CourseGroup;

        studentRepository.Update(existStudent);

        return existStudent;
    }
}

