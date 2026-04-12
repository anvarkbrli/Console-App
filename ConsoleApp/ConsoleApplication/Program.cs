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

            while(true)
    {
                Helper.ShowMenu();
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1": groupController.Create(); break;
                    case "2": groupController.GetAll(); break;
                    case "3": groupController.Update(); break;
                    case "4": groupController.Delete(); break;
                    case "5": groupController.GetById(); break;
                    case "6": groupController.GetAllByTeacher(); break;
                    case "7": groupController.GetAllByRoom(); break;
                    case "8": groupController.Search(); break;

                    case "9": studentController.Create(); break;
                    case "10": studentController.Update(); break;
                    case "11": studentController.GetById(); break;
                    case "12": studentController.Delete(); break;
                    case "13": studentController.GetAllStudentsByAge(); break;
                    case "14": studentController.GetAllStudentsByGroupId(); break;
                    case "15": studentController.SearchStudent(); break;

                    case "0":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Helper.PrintColor(ConsoleColor.Red, "Invalid option!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
