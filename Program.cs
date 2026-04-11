//for thE LAST MENU (MENU2) KAILANAG BABALIK SIYA SA MAIN METHOD.
// ADD MORE PROGRAM AND SCHEDULE ON THE LIST

using SIS_SubjectScheduleBusinesslogic;
using SIS_SubjectScheduleDataLogic;
using SIS_SubjectScheduleModels;
using System;
using System.Collections.Generic;
using static SIS_SubjectScheduleDataLogic.SIS_DataLogic;

namespace SIS_SubjectScheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*----------<< Student Scheduling >>----------*");

            Console.WriteLine(" ");
            Console.WriteLine("<< What would you like to do? >> ");
            Console.WriteLine("[1] Selecting Program & Section to See Schedules");
            Console.WriteLine("    - for students that are Enrolled and Haven't seen their schedules");
            Console.WriteLine("[2] Registration for new student ");
            Console.WriteLine("    - for students that are NOT Enrolled yet");
            Console.WriteLine("[3] See Saved schedule"); // may update here
            Console.WriteLine("==========================================");
            Console.Write("Enter Number: ");
            int numberStartingPage = int.Parse(Console.ReadLine());

            switch (numberStartingPage)
            {
                case 1:
                    Console.Write("Enter your Student number: ");
                    string studentNumber = Console.ReadLine().ToUpper();
                    Console.Write("Enter your Password: ");
                    string studentPassword = Console.ReadLine();

                    if (!SIS_BusinessLogic.Login(studentNumber, studentPassword))
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Invalid Student Number or Password.");
                        Console.WriteLine("==========================================");
                        Console.Write("Do you want to register? (y/n): ");
                        string choice = Console.ReadLine();

                        if (choice.ToLower() == "y")
                        {
                            SIS_BusinessLogic.Register(studentNumber, studentPassword);
                            Console.WriteLine("Registration successful! You can now log in.");
                        }
                    }


                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("Login Successful :3");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");



                        StudentMenu();
                    }
                    break;

                case 2:
                    Console.WriteLine(" ");
                    Console.WriteLine("---<< registration for new student >>---");
                    Console.WriteLine(" ");
                    Console.Write("Enter your Student number: ");
                    studentNumber = Console.ReadLine().ToUpper();
                    Console.Write("Enter your Password: ");
                    studentPassword = Console.ReadLine();
                    SIS_BusinessLogic.Register(studentNumber, studentPassword);
                    Console.WriteLine("Registration successful! You can now log in.");

                    break;

                case 3:
                    Console.WriteLine(" save Sched");
                    break;
            }

        }// main last

        //-------------------------------------------------------------------------------------------------------------------------------------------------

        static void StudentMenu()
        {
            //try if pwede gawin na switch to ex. 1 - BSIT, 2 - BSIE, 3 - BSCPE

            Console.WriteLine("Welcome student to the scheduling Page. " +
                "\nThis is where you can access your class schedule.");
            Console.WriteLine("==========================================");
            Console.WriteLine("*----------<<SELECT A PROGRAM>>----------*");
            Console.WriteLine("BSIT || DIT || ");
            Console.WriteLine("==========================================");
            Console.Write("Enter Program: ");
            string program = Console.ReadLine().ToUpper();


            switch (program)
            {
                case "BSIT":
                    Console.Write("Enter Section (1-1, 2-1, 3-1, 4-1): ");
                    string section = Console.ReadLine();

                    SIS_BusinessLogic.ScheduleBSIT(section);

                    ActionsmenuSchedule();
                    break;

                case "DIT":
                    Console.Write("Enter Section (1-1, 2-1, 3-1): ");
                    section = Console.ReadLine();

                    SIS_BusinessLogic.ScheduleBSIT(section);
                    break;

                default:
                    Console.WriteLine("Sorry program is not on the list try again");
                    break;
            }

        }

        static void ActionsmenuSchedule()
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("------<<What would you like to do?>>------");
            Console.WriteLine("[1] See Subject Dicription");
            Console.WriteLine("[2] See Subject Professors");
            Console.WriteLine("[3] Save Schedule");
            Console.WriteLine("[4] Exit and Don't Save"); // if namali sila ng enter they can go back to the main menu
            Console.WriteLine("==========================================");
            Console.Write("Enter Number: ");
            int numberChoiceScheduleActions = int.Parse(Console.ReadLine());

            switch (numberChoiceScheduleActions)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:
                    Console.WriteLine(" ");
                    Console.WriteLine("Exiting...............");
                    Console.WriteLine(" ");
                    break;
                default:
                    Console.WriteLine("Sorry number is not on the list try again");
                    break;
            }

        }
    }
    
}//last 



