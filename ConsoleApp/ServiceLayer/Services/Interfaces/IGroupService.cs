using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IGroupService
    {
        CourseGroup CreateGroup( CourseGroup courseGroup);
        CourseGroup UpdateGroup(int id,  CourseGroup courseGroup);
        void DeleteGroup(int id);
        List<CourseGroup> SearchGroup(string groupName);
        CourseGroup GetById(int id);
        List<CourseGroup> GetAllGroupsByTeacher(string teacher);
        List<CourseGroup> GetAllGroupsByRoom(int room);

    }
}
