using ConsoleApplication.Controllers;
using ConsoleApplication.Helpers;

namespace ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GroupController groupController = new();

            Helper.PrintColor(ConsoleColor.Blue, "Select an option for group operations:");
            SelectOption: Helper.PrintColor(ConsoleColor.Yellow, "1 - Create group, 2 - Get all groups, 3 - Update group, 4 - Delete, 5 - Get by Id, 6 - Get by Teacher, 7 - Get by Room number");

            while (true)
            {
                string selectOption = Console.ReadLine();
                int selectNumber;
                bool isSelectOption = int.TryParse(selectOption, out selectNumber);

                if (isSelectOption)
                {
                    switch (selectNumber)
                    {
                        case 1:
                            groupController.Create();
                            goto SelectOption;
                        case 2:
                            groupController.GetAll();
                            goto SelectOption;
                        case 3:
                            groupController.Update();
                            goto SelectOption;
                        case 4:
                            groupController.Delete();
                            goto SelectOption;
                        case 5:
                            groupController.GetById();
                            goto SelectOption;
                        case 6:
                            groupController.GetAllByTeacher();
                            goto SelectOption;
                        case 7:
                            groupController.GetAllByRoom();
                            goto SelectOption;
                    }
                }
                else
                {
                    Helper.PrintColor(ConsoleColor.Red, "Enter a correct option type");
                    goto SelectOption;

                }

            } 
        }
    }
}
