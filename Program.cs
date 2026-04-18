// ADD MORE PROGRAM AND SCHEDULE ON THE LIST

using SIS_SubjectScheduleBusinesslogic;
using SIS_SubjectScheduleDataLogic;
using SIS_SubjectScheduleModels;
using System;
using System.Collections.Generic;
using System.Threading.Channels;
using static SIS_SubjectScheduleDataLogic.SIS_DataLogic;
using static System.Collections.Specialized.BitVector32;

namespace SIS_SubjectScheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            mainmenu();

        }// main last

        static void mainmenu()
        {
            // ------------------------------------------- Main Menu!!!
            Console.WriteLine("*----------<< Student Scheduling >>----------*");

            Console.WriteLine(" ");
            Console.WriteLine("<< What would you like to do? >> ");
            Console.WriteLine("[1] Selecting Program & Section to See Schedules");
            Console.WriteLine("    - for students that are Enrolled and Haven't seen their schedules");
            Console.WriteLine("[2] Registration for new student ");
            Console.WriteLine("    - for students that are NOT Enrolled yet");
            Console.WriteLine("[3] See Saved schedule"); // may update: 1. changed section, 2.change program, 3. OR CHANGE BOTH 
            Console.WriteLine("==========================================");
            Console.Write("Enter a Number: ");
            int numberStartingPage = int.Parse(Console.ReadLine());

            switch (numberStartingPage)
            {
                case 1:
                    Console.WriteLine(" ");
                    Console.WriteLine("---<< Selecting a Schedule >>---");
                    Console.WriteLine(" ");
                    Console.Write("Enter your Student number: ");
                    string studentNumber = Console.ReadLine().ToUpper();
                    Console.Write("Enter your Password: ");
                    string studentPassword = Console.ReadLine();


                    var student = SIS_BusinessLogic.LoginAndGetStudent(studentNumber, studentPassword);

                    if (student == null)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Invalid Student Number or Password.");
                        Console.WriteLine("==========================================");
                        Console.Write("Do you want to register? (y/n): ");
                        string choice = Console.ReadLine();

                        if (choice.ToLower() == "y")
                        {
                            bool registerSuccess = SIS_BusinessLogic.Register(studentNumber, studentPassword);

                            if (!registerSuccess)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine(" ");
                                Console.WriteLine("This student number already exists!");
                                Console.WriteLine("Please log in using [number 1] " +
                                    "\n or if you have aleady a Program & Schedule [number 2] choice instead of registering again.");
                                Console.WriteLine(" ");
                                Console.WriteLine(" ");
                                mainmenu();
                            }
                            else
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine(" ");
                                Console.WriteLine("Registration successful! You can now log in SELECT [number 1] again to add PROGRAM & SECTION).");
                                Console.WriteLine(" ");
                                Console.WriteLine(" ");

                                //Console.WriteLine("""


                                //                  Registration successful! You can now log in SELECT [number 1] again to add PROGRAM & SECTION)


                                //                  """);
                                mainmenu();
                            }
                        }
                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(student.Program) && !string.IsNullOrEmpty(student.Section))
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");
                            Console.WriteLine("You already have a program and section!");
                            Console.WriteLine("Please use Choice [3] to view or update your schedule :3");
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");
                            mainmenu();
                        }
                        else
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");
                            Console.WriteLine("Login Successful :3");
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");
                            StudentMenu(studentNumber);

                        }
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

                    var existingStudent = SIS_BusinessLogic.GetStudentByNumber(studentNumber);

                    bool success = SIS_BusinessLogic.Register(studentNumber, studentPassword);

                    if (!success)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("This student number already exists!");
                        Console.WriteLine("Please enter Choice [number 3] to check your schedule or if you want any changes");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        mainmenu();
                    }
                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("Registration successful! You can now log in SELECT [number 1] again to add PROGRAM & SECTION).");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        mainmenu();
                    }
                    break;

                case 3:
                    Console.WriteLine(" ");
                    Console.WriteLine("---<< Welcome back! >>---");
                    Console.WriteLine(" ");
                    Console.Write("Enter Student Number: ");
                    studentNumber = Console.ReadLine().ToUpper();
                    Console.Write("Enter Password: ");
                    studentPassword = Console.ReadLine();

                    student = SIS_BusinessLogic.LoginAndGetStudent(studentNumber, studentPassword);

                    if (student == null)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("You don't have any Account yet, please register first SELECT Choice [number 2] - Register");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        mainmenu();
                    }
                    else
                    {

                        if (string.IsNullOrEmpty(student.Program) || string.IsNullOrEmpty(student.Section))
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");
                            Console.WriteLine("You have not selected a program/section yet.");
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");
                            mainmenu();

                            StudentMenu(studentNumber);
                        }
                        else
                        {
                            SIS_BusinessLogic.ShowSchedule(student);

                            Console.WriteLine("==========================================");
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();

                            ActionsmenuSchedule(student);
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Sorry number is not on the list, Please try again :<");
                    break;

            }
        }

        // ------------------------------------------- Student Program and Section selection!!!

        static void StudentMenu(string studentNumber)
        {

            Console.WriteLine("Welcome student to the scheduling Page. " +
                "\nThis is where you can access your class schedule.");
            Console.WriteLine("==========================================");
            Console.WriteLine("*----------<<SELECT A PROGRAM>>----------*");
            Console.WriteLine("BSIT || DIT || ");
            Console.WriteLine("==========================================");
            Console.Write("Enter Program: ");
            string program = Console.ReadLine().ToUpper();
            Console.Write("Enter Section: ");
            string section = Console.ReadLine().ToUpper();

            var student = SIS_BusinessLogic.LoginAndGetStudent(studentNumber, "");
            if (student != null)
            {
                if (SIS_BusinessLogic.IsValidProgram(program) && SIS_BusinessLogic.IsValidSection(section))
                {
                    student.Program = program;
                    student.Section = section;

                    SIS_BusinessLogic.UpdateProgramAndSection(student);
                    SIS_BusinessLogic.ShowSchedule(student);

                    Console.WriteLine("==========================================");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();

                    ActionsmenuSchedule(student);
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine("Invalid program or section, It is not on the list :<");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                }
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("Student not found. Please log in first, SELECT choice [number 2] :<");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }
        }



        // ------------------------------------------- other fetures WAT To DOOO Menu!!!
        static void ActionsmenuSchedule(Student student)
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("------<<What would you like to do?>>------");
            Console.WriteLine("[1] See Subject Dicriptions and Professor");
            Console.WriteLine("[2] Student Account Management (Updating, Deletion, & Retriving)");
            Console.WriteLine("[3] wrong schedule, I want to change My Program & Section");
            Console.WriteLine("[4] Save Schedule");
            Console.WriteLine("==========================================");
            Console.Write("Enter a Number: ");
            int numberChoiceScheduleActions = int.Parse(Console.ReadLine());

            switch (numberChoiceScheduleActions)
            {
                case 1:
                    SIS_BusinessLogic.ShowSubjectDescription(student);
                    break;

                case 2:
                    StudentAccountManagement(student);
                    break;

                case 3:
                    UpdateSchedule(student);
                    break;

                case 4:
                    Console.WriteLine(" ");
                    Console.WriteLine("Saved Schedule" +
                        "\n Exiting...............");
                    Console.WriteLine(" ");
                    break;

                default:
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine("Sorry number is not on the list try again :<");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    break;
            }

        }

        // ------------------------------------------- Student Account Management MeNU!!!
        static void StudentAccountManagement(Student student)
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("------<< Student Account Management >>------");
            Console.WriteLine("[1] Change Password");
            Console.WriteLine("[2] Deletion of Schedule (section & program)");
            Console.WriteLine("[3] Retrieving of past section & program");
            Console.WriteLine("[4] Back");
            Console.WriteLine("==========================================");
            Console.Write("Enter a Number: ");
            int numberAccManageChoice = int.Parse(Console.ReadLine());

            switch (numberAccManageChoice)
            {
                case 1:
                    Console.WriteLine("==========================================");
                    Console.Write("Enter new Password: ");
                    string newPassword = Console.ReadLine();

                    student.StudentPassword = newPassword;
                    SIS_BusinessLogic.UpdatePassword(student);
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.Write("New Password Saved!");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    break;

                case 2:
                    if (string.IsNullOrEmpty(student.Program) || string.IsNullOrEmpty(student.Section))
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("You haven't selected a program & section yet. :<");
                        StudentMenu(student.StudentNumber);
                    }
                    else
                    {
                        Console.WriteLine("==========================================");
                        Console.Write("Do you really want to DELETE your Section & Program? (Y/N): ");
                        string deleteAns = Console.ReadLine()?.Trim().ToUpper();

                        if (deleteAns == "Y")
                        {
                            student.Program = null;
                            student.Section = null;
                            SIS_BusinessLogic.DeleteProgramandSection(student);

                            Console.WriteLine(" ");
                            Console.WriteLine(" ");
                            Console.WriteLine("Section & Program deleted successfully!");
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");
                        }
                        else if (deleteAns == "N")
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");
                            Console.WriteLine("Deletion cancelled :<");
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");

                            StudentAccountManagement(student);
                        }
                        else
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");
                            Console.WriteLine("Invalid input. Please enter Y or N. :<");
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");

                            StudentAccountManagement(student);
                        }

                       
                    }
                      break;

                case 3:
                    Console.WriteLine("==========================================");
                    Console.Write("Do you really want to RETRIEVE your Section & Program? (Y/N): ");
                    string retrieveAns = Console.ReadLine()?.Trim().ToUpper();

                    if (retrieveAns == "Y")
                    {
                        var past = SIS_BusinessLogic.RetrieveProgramandSection(student.StudentNumber);

                        if (past != null && (!string.IsNullOrEmpty(past.PastProgram) || !string.IsNullOrEmpty(past.PastSection)))
                        {
                            student.Program = past.PastProgram;
                            student.Section = past.PastSection;

                            SIS_BusinessLogic.UpdateProgramAndSection(student);

                            Console.WriteLine(" ");
                            Console.WriteLine("Past Program & Section retrieved successfully!");
                            Console.WriteLine($"Program: {student.Program}, Section: {student.Section}");
                            Console.WriteLine(" ");

                            SIS_BusinessLogic.ShowSchedule(student);
                        }
                        else
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("No past program/section found :<");
                            Console.WriteLine(" ");
                            StudentAccountManagement(student);
                        }

                    }

                    else if (retrieveAns == "N")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("Retrieving cancelled. :<");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");

                        StudentAccountManagement(student);
                    }

                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("Invalid input. Please enter Y or N. :<");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        StudentAccountManagement(student);
                    }
                    break;

                case 4:
                    ActionsmenuSchedule(student);
                    break;

                default:
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine("Sorry number is not on the list try again :<");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    break;
            }

        }

        // ------------------------------------------- Updating MeNU!!!

        static void UpdateSchedule(Student student)
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("------<< UPDATING >>------");
            Console.WriteLine("[1] Change Program");
            Console.WriteLine("[2] Change Section");
            Console.WriteLine("[3] Change Program & Section");
            Console.WriteLine("==========================================");
            Console.Write("Enter Number: ");
            int updateChoice = int.Parse(Console.ReadLine());
            switch (updateChoice)
            {
                case 1:
                    Console.WriteLine("==========================================");
                    Console.Write("Enter new Program: ");
                    string newProgram = Console.ReadLine()?.Trim().ToUpper();


                    if (SIS_BusinessLogic.IsValidProgram(newProgram))
                    {
                        student.Program = newProgram;
                        SIS_BusinessLogic.UpdateProgramAndSection(student);
                    }
                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("Invalid program. Update cancelled :< ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                    }

                    break;
                case 2:
                    Console.WriteLine("==========================================");
                    Console.Write("Enter new Section: ");
                    string newSection = Console.ReadLine()?.Trim().ToUpper();

                    student.Section = newSection;

                    if (SIS_BusinessLogic.IsValidSection(newSection))
                    {
                        student.Section = newSection;
                        SIS_BusinessLogic.UpdateProgramAndSection(student);
                    }
                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("Invalid Section. Update cancelled :<");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                    }

                    break;

                case 3:
                    Console.WriteLine("==========================================");
                    Console.Write("Enter new Program: ");
                    newProgram = Console.ReadLine().ToUpper();
                    Console.Write("Enter new Section: ");
                    newSection = Console.ReadLine()?.Trim().ToUpper();

                    if (SIS_BusinessLogic.IsValidProgram(newProgram) && SIS_BusinessLogic.IsValidSection(newSection))
                    {
                        student.Program = newProgram;
                        student.Section = newSection;
                        SIS_BusinessLogic.UpdateProgramAndSection(student);
                    }
                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("Invalid program or section. Update cancelled :<");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                    }
                    break;


                default:
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine("Invalid choice. No changes has made :<");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    return;
            }
            SIS_BusinessLogic.ShowSchedule(student);

        }
    }
}//last 
