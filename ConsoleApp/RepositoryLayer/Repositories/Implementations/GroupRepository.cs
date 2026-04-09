using DomainLayer.Entities;
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
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetAllByRoom(Predicate<CourseGroup> predicate)
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetAllByTeacher(Predicate<CourseGroup> predicate)
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetById(Predicate<CourseGroup> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(CourseGroup data)
        {
            throw new NotImplementedException();
        }
    }
}
