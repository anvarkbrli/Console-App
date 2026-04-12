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
        public CourseGroup CreateGroup(CourseGroup courseGroup)
        {
            courseGroup.Id = count;
            var groups = groupRepository.GetAll();

            while (groups.Any(g => g.Id == count))
            {
                count++;
            }
            courseGroup.Id = count;
            groupRepository.Create(courseGroup);
            return courseGroup;

        }

        public void DeleteGroup(int id)
        {
            CourseGroup group = GetById(id);
            groupRepository.Delete(group);

        }
        public List<CourseGroup> SearchGroup(string groupnName) 
        {
            return groupRepository.GetAll(l=> l.Name.ToLower().Trim() == groupnName.ToLower().Trim());
        }
        public List<CourseGroup> GetAll()
        {
            return groupRepository.GetAll();
        }

        public List<CourseGroup> GetAllGroupsByRoom(int room)
        {
            if (room <= 0)
                throw new ArgumentException("Room number must be greater than 0.");

            return groupRepository.GetAllGroupsByRoom(m=> m.Room ==  room);
        }

        public List<CourseGroup> GetAllGroupsByTeacher(string teacher)
        {
            return groupRepository.GetAllGroupsByTeacher(m => m.Teacher.ToLower().Trim() == teacher.ToLower().Trim());
        }

        public CourseGroup GetById(int id)
        {
            CourseGroup group = groupRepository.Get(l => l.Id == id);
            if (group is null) return null;
            return group;
        }

        public CourseGroup UpdateGroup(int id, CourseGroup group)
        {
            var existGroup = groupRepository.GetById(id);

            if (existGroup == null)
            {
                return null;
            }

            existGroup.Name = group.Name;
            existGroup.Teacher = group.Teacher;
            existGroup.Room = group.Room;

            groupRepository.Update(existGroup);

            return existGroup;
        }
    }
}
