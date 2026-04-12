using ConsoleApplication.Controllers;
using ConsoleApplication.Helpers;

namespace ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GroupController groupController = new();
            StudentController studentController = new();

            Helper.PrintColor(ConsoleColor.Blue, "Select an option for group operations:");
        SelectOption: Helper.PrintColor(ConsoleColor.Yellow,"1 - Create group\n" +
                      "2 - Get all groups\n" +
                      "3 - Update group\n" +
                      "4 - Delete group\n" +
                      "5 - Get group by Id\n" +
                      "6 - Get group by Teacher\n" +
                      "7 - Get group by Room number\n" +
                      "8 - Search group by name\n" +
                      "9 - Create student\n" +
                     "10 - Update student\n" +
                     "11 - Get student by ID\n" +
                     "12 - Delete student\n" +
                     "13 - Get student by Age\n" +
                     "14 - Get student by Group ID\n" +
                     "15 - Search student by name or surname");

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
                        case 8:
                            groupController.Search();
                            goto SelectOption;
                        case 9:
                            studentController.Create();
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
