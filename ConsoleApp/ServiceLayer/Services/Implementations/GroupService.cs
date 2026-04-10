using DomainLayer.Entities;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Interfaces;

namespace ServiceLayer.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private GroupRepository groupRepository;
        private int count = 1;

        public GroupService()
        {
            groupRepository = new GroupRepository();
        }
        public CourseGroup Create(CourseGroup courseGroup)
        {
            courseGroup.Id = count;
            groupRepository.Create(courseGroup);
            count++;
            return courseGroup;
        }

        public void Delete(int id)
        {
            CourseGroup group = GetById(id);

        }
        public List<CourseGroup> GetAll()
        {
            return groupRepository.GetAll();
        }

        public List<CourseGroup> GetAllByRoom(int room)
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetAllByTeacher(string teacher)
        {
            return groupRepository.GetAllByTeacher(m => m.Teacher.ToLower().Trim() == teacher.ToLower().Trim());
        }

        public CourseGroup GetById(int id)
        {
            CourseGroup group = groupRepository.Get(l => l.Id == id);
            if (group is null) return null;
            return group;
        }

        public CourseGroup Update(int id, CourseGroup courseGroup)
        {
            throw new NotImplementedException();
        }
    }
}
