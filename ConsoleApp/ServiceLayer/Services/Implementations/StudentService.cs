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

        public List<Student> GetAllStudentsByAge(int age)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudentsByGroupId(int id)
        {
            throw new NotImplementedException();
        }

        public Student GetById(int id)
        {
            Student student = studentRepository.Get(l => l.Id == id);
            if (student is null) return null;
            return student;
        }

        public List<Student> SearchStudent(string name, string surname)
        {
            throw new NotImplementedException();
        }

        //public List<Student> SearchStudent(string name, string surname)
        //{
        //    //if (string.IsNullOrWhiteSpace())
        //    //{
        //    //    return new List<Student>();
        //    //}

        //    //return studentRepository.GetAll()
        //    //    .Where(s =>
        //    //        s.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
        //    //        s.Surname.Contains(searchText, StringComparison.OrdinalIgnoreCase))
        //    //    .ToList();

        //}

        public Student UpdateStudent(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }

