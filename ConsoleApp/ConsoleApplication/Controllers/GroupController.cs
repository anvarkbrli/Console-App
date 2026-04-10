using ConsoleApplication.Helpers;
using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Implementations;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Controllers
{
    public class GroupController
    {
        GroupService groupService = new();

        public void Create()
        {
        groupNo: Helper.PrintColor(ConsoleColor.Blue, "Enter Group Name:");
            string groupName = Console.ReadLine();
            if (string.IsNullOrEmpty(groupName))
            {
                Helper.PrintColor(ConsoleColor.Red, "Error! Enter a value!");
                goto groupNo;

            }
        teahcerName: Helper.PrintColor(ConsoleColor.Blue, "Enter Teacher Name:");
            string teacherName = Console.ReadLine();
            if (string.IsNullOrEmpty(teacherName))
            {
                Helper.PrintColor(ConsoleColor.Red, "Error! Enter a value!");
                goto teahcerName;
            }
            bool isNumeric = true;
            foreach(char c in teacherName)
            {
                if (char.IsDigit(c))
                {
                    isNumeric = false;
                    break;
                }
            }
            if(!isNumeric)
            {
                Helper.PrintColor(ConsoleColor.Red, "Please enter a correct teacher name!");
                goto teahcerName;


            }
            RoomNumber: Helper.PrintColor(ConsoleColor.Blue, "Enter Room Number:");
            string groupRoomNumber = Console.ReadLine();

            int roomNumber;
            bool isRoomNumber = int.TryParse(groupRoomNumber, out roomNumber);
            if (isRoomNumber)
            {
                CourseGroup group = new CourseGroup { Name = groupName, Teacher = teacherName, Room = roomNumber };
                var result = groupService.Create(group);
                Helper.PrintColor(ConsoleColor.Green, $"Group ID: {group.Id}, Group Name: {group.Name}, Teacher name: {group.Teacher}, Room number: {group.Room}");

            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Enter a valid type");
                goto RoomNumber;
            }
        }
        public void GetAll() 
        {
            List<CourseGroup> groups = groupService.GetAll();
            if (groups.Count > 0)
            {
                foreach (var item in groups)
                {
                    Helper.PrintColor(ConsoleColor.Green, $"Group ID: {item.Id}, Group Name: {item.Name}, Teacher name: {item.Teacher}, Room number: {item.Room}");

                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Please add groups");
            }
        }
            
            
        public void Update() 
        {

        }
        public void Delete() 
        {
            GroupId: Helper.PrintColor(ConsoleColor.Blue, "Enter id to delete item:");
            int id;
            string groupId = Console.ReadLine();
            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId)
            {
                CourseGroup group = groupService.GetById(id);
                if (group != null)
                {
                    groupService.Delete(id);
                    Helper.PrintColor(ConsoleColor.Green, $"Group {group.Name} has been deleted!");

                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "Group not found!!");
                    goto GroupId;
                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Enter correct group id type!!");
                goto GroupId;
            }
        }
        public void GetById() 
        {
            GroupId: Helper.PrintColor(ConsoleColor.Blue, "Add Group Id");
            string libraryId = Console.ReadLine();
            int id;
            bool isLibraryId = int.TryParse(libraryId, out id);
            if (isLibraryId)
            {
                CourseGroup group = groupService.GetById(id);
                if (group != null)
                {
                    Helper.PrintColor(ConsoleColor.Green, $"Group ID: {group.Id}, Group Name: {group.Name}, Teacher name: {group.Teacher}, Room number: {group.Room}");
                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Green, "Group not found!");
                    goto GroupId;

                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Enter correct library Id type");
                goto GroupId;
            }
        }
        public void GetAllByTeacher() 
        {
            Helper.PrintColor(ConsoleColor.Blue, "Enter Teacher name:");
            string teacher = Console.ReadLine();

        }
        public void GetAllByRoom() { }
    }
}
