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
using System.Text.RegularExpressions;
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
        teachName: Helper.PrintColor(ConsoleColor.Blue, "Enter Teacher Name:");
            string teacherName = Console.ReadLine();
            if (string.IsNullOrEmpty(teacherName))
            {
                Helper.PrintColor(ConsoleColor.Red, "Error! Enter a value!");
                goto teachName;
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
                goto teachName;


            }
            RoomNumber: Helper.PrintColor(ConsoleColor.Blue, "Enter Room Number:");
            string groupRoomNumber = Console.ReadLine();

            int roomNumber;
            bool isRoomNumber = int.TryParse(groupRoomNumber, out roomNumber);
            if (isRoomNumber)
            {
                CourseGroup group = new CourseGroup { Name = groupName, Teacher = teacherName, Room = roomNumber };
                var result = groupService.CreateGroup(group);
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
            GroupId: Helper.PrintColor(ConsoleColor.Blue, "Add Group Id");
            string gorupId = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(gorupId))
            {
                Helper.PrintColor(ConsoleColor.Red, "Update operation canceled");
                goto GroupId;
            }

            int id;
            bool isGroupId = int.TryParse(gorupId, out id);
            if (isGroupId)
            {
                var findGroup = groupService.GetById(id);
                if (findGroup != null)
                {
                    Helper.PrintColor(ConsoleColor.Blue, $"Current name: {findGroup.Name}. Enter new group name:");
                    string newGroupName = Console.ReadLine();

                    Helper.PrintColor(ConsoleColor.Blue, $"Current Teacher name: {findGroup.Teacher}. Enter new Teacher name:");
                    string newTeacherName = Console.ReadLine();

                    RoomNumber:  Helper.PrintColor(ConsoleColor.Blue, $"Current Room number: {findGroup.Room}. Enter new room number:");
                    string newRoomNumber = Console.ReadLine();

                    int roomNumber = findGroup.Room;

                    if (!string.IsNullOrWhiteSpace(newRoomNumber))
                    {
                        bool isRoomNumber = int.TryParse(newRoomNumber, out roomNumber);

                        if (!isRoomNumber)
                        {
                            Helper.PrintColor(ConsoleColor.Red, "Enter correct type");
                            goto RoomNumber;
                        }

                        if (string.IsNullOrWhiteSpace(newGroupName))
                        {
                            newGroupName = findGroup.Name;
                        }
                        CourseGroup group = new CourseGroup { Name = newGroupName, Teacher = newTeacherName, Room = roomNumber };
                        var updatedGroup = groupService.UpdateGroup(id, group);

                        if (updatedGroup is null)
                        {
                            Helper.PrintColor(ConsoleColor.Red, "Group is not updated, Please try again");
                            goto GroupId;
                        }
                        else
                        {
                            Helper.PrintColor(ConsoleColor.Green, $"Group ID: {updatedGroup.Id}, Group Name: {updatedGroup.Name}, Teacher name: {updatedGroup.Teacher}, Room number: {updatedGroup.Room}");

                        }

                    }

                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "Group doesn't exist");
                    goto GroupId;
                }

            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Enter correct Id");
                goto GroupId;
            }
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
                    groupService.DeleteGroup(id);
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
        public void Search() 
        {
            searchName: Helper.PrintColor(ConsoleColor.Blue, "Enter Name for search: ");
            string searchName = Console.ReadLine();

            List<CourseGroup> groups = groupService.SearchGroup(searchName);
            if (groups.Count > 0)
            {
                foreach (var item in groups)
                {
                    Helper.PrintColor(ConsoleColor.Green, $"Group ID: {item.Id}, Group Name: {item.Name}, Teacher name: {item.Teacher}, Room number: {item.Room}");

                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Enter correct search name");
                goto searchName;
            }


        }
        public void GetById() 
        {
            GroupId: Helper.PrintColor(ConsoleColor.Blue, "Enter Group Id");
            string groupId = Console.ReadLine();
            int id;
            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId)
            {
                CourseGroup group = groupService.GetById(id);
                if (group != null)
                {
                    Helper.PrintColor(ConsoleColor.Green, $"Group ID: {group.Id}, Group Name: {group.Name}, Teacher name: {group.Teacher}, Room number: {group.Room}");
                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "Group not found!");
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
            groupTeacher: Helper.PrintColor(ConsoleColor.Blue, "Enter Teacher name:");
            string teacher = Console.ReadLine();
            var group = groupService.GetAllGroupsByTeacher(teacher);
            if (group.Count > 0)
            {
                foreach ( var item in group)
                {
                    Helper.PrintColor(ConsoleColor.Green, $"Group ID: {item.Id}, Group Name: {item.Name}, Teacher name: {item.Teacher}, Room number: {item.Room}");

                }
            }
            else
            {
                Helper.PrintColor(ConsoleColor.Red, "Enter correct teacher name");
                goto groupTeacher;
            }

        }
        public void GetAllByRoom() 
        {
            GroupRoom: Helper.PrintColor(ConsoleColor.Blue, "Enter Room Number");
            string room = Console.ReadLine();
            int groupRoom;
            bool isGroupRoom = int.TryParse(room, out groupRoom);

            while (isGroupRoom)
            {
                var group = groupService.GetAllGroupsByRoom(groupRoom);
                if(group.Count > 0) 
                {

                    foreach (var item in group)
                    {
                        Helper.PrintColor(ConsoleColor.Green, $"Group ID: {item.Id}, Group Name: {item.Name}, Teacher name: {item.Teacher}, Room number: {item.Room}");
                    }
                    isGroupRoom = false;
                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "Enter correct room number");
                    goto GroupRoom;
                }
            }
        }
    }
}
