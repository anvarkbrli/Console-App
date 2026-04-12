using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Helpers
{
    public class Helper
    {
        public static void PrintColor(ConsoleColor color, string output)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(output);
            Console.ResetColor();   

        }
        public static void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                 COURSE MANAGEMENT SYSTEM                     ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                         GROUP MENU                           ║");
            Console.WriteLine("║  1  - Create Group                                           ║");
            Console.WriteLine("║  2  - Get All Groups                                         ║");
            Console.WriteLine("║  3  - Update Group                                           ║");
            Console.WriteLine("║  4  - Delete Group                                           ║");
            Console.WriteLine("║  5  - Get Group By Id                                        ║");
            Console.WriteLine("║  6  - Get Groups By Teacher                                  ║");
            Console.WriteLine("║  7  - Get Groups By Room Number                              ║");
            Console.WriteLine("║  8  - Search Group By Name                                   ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                        STUDENT MENU                          ║");
            Console.WriteLine("║  9  - Create Student                                         ║");
            Console.WriteLine("║ 10  - Get All Students                                       ║");
            Console.WriteLine("║ 11  - Update Student                                         ║");
            Console.WriteLine("║ 12  - Delete Student                                         ║");
            Console.WriteLine("║ 13  - Get Student By Id                                      ║");
            Console.WriteLine("║ 14  - Get Students By Age                                    ║");
            Console.WriteLine("║ 15  - Get Students By Group Id                               ║");
            Console.WriteLine("║ 16  - Search Student By Name or Surname                      ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║  0  - Exit                                                   ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Select an option: ");
            Console.ResetColor();
        }


    }
}
