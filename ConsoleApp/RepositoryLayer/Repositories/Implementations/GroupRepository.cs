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
    public class GroupRepository : IRepository<CourseGroup>
    {
        public void Create(CourseGroup data)
        {
            try
            {
                if (data == null) throw new NotFoundException("Data not found");
                AppDBContext<CourseGroup>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public CourseGroup Get(Predicate<CourseGroup> predicate)
        {
            return predicate != null ? AppDBContext<CourseGroup>.datas.Find(predicate) : null;
        }

        public void Delete(CourseGroup data)
        {
            AppDBContext<CourseGroup>.datas.Remove(data);
        }
        public List<CourseGroup> GetAll(Predicate<CourseGroup> predicate = null)
        {
            return predicate != null ? AppDBContext<CourseGroup>.datas.FindAll(predicate) : AppDBContext<CourseGroup>.datas;
        }
        public List<CourseGroup> GetAllGroupsByRoom(Predicate<CourseGroup> predicate)
        {
            return predicate != null ? AppDBContext<CourseGroup>.datas.FindAll(predicate) : new List<CourseGroup>();

        }


        public List<CourseGroup> GetAllGroupsByTeacher(Predicate<CourseGroup> predicate)
        {
            return predicate != null ? AppDBContext<CourseGroup>.datas.FindAll(predicate) : new List<CourseGroup>();

        }
        public void Update(CourseGroup data)
        {
            var existGroup = AppDBContext<CourseGroup>.datas.Find(g => g.Id == data.Id);

            if (existGroup == null)
            {
                throw new NotFoundException("Group not found");
            }

            existGroup.Name = data.Name;
            existGroup.Teacher = data.Teacher;
            existGroup.Room = data.Room;
        }

        public CourseGroup GetById(int id)
        {
            return AppDBContext<CourseGroup>.datas.FirstOrDefault(g => g.Id == id);
        }
    }
}
