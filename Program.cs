//for thE LAST MENU (MENU2) KAILANAG BABALIK SIYA SA MAIN METHOD.
// ADD MORE PROGRAM AND SCHEDULE ON THE LIST


using System.Reflection.PortableExecutable;
using static System.Collections.Specialized.BitVector32;

namespace SIS_SubjectScheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string program; //BSIT or DIT (could be lahat ng program)
            string section;
            int menu;

            Console.WriteLine("--------------< Student Class Schedule >--------------");
            Console.WriteLine("Welcome student to the scheduling Page. This is where you can see your class schedule.");
            Console.WriteLine("======================================================");
            Console.WriteLine("SELECT A PROGRAM");
            Console.WriteLine("BSIT || DIT || BSCPE || DCPE " +
                "\nBSIE || BEED || BSHRM || BSSED");

            Console.WriteLine("======================================================");
            Console.Write("Enter your Program: ");
            program = Console.ReadLine().ToUpper();

            switch (program)
            {
                case "BSIT":
                    Console.Write("Enter your Year level and Section (1-1, 2-1, 3-1,4-1): ");
                    section = Console.ReadLine();
                    SubjectScheduling(program,section);
                    break;

                default:
                    Console.WriteLine(" ");
                    Console.Write("School Do not offer a Program like that. Please enter a program that is on the list");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    break;

            }


            
           }

        //scheduling for the section
        static void SubjectScheduling(string program, string section)
        {
            if (program == "BSIT" && section == "1-1")
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("-------< BSIT 1-1 CLASS SCHEDULE >-------");
                Console.WriteLine("MONDAY:");
                Console.WriteLine("10:30AM - 12:30PM  | INTRODUCTION TO COMPUTING");
                Console.WriteLine("10:30AM - 12:30PM  | INTRODUCTION TO COMPUTING LAB");
                Console.WriteLine("01:00PM - 04:00PM  | CWTS 1");
                Console.WriteLine("======================================================");

                Console.WriteLine("TUESDAY:");
                Console.WriteLine("12:00PM - 02:30PM  | PATHFIT 1");
                Console.WriteLine("03:30PM - 06:00PM  | COMPUTER PROGRAMMING 1");
                Console.WriteLine("06:00PM - 08:00PM  | COMPUTER PROGRAMMING 1 LAB");
                Console.WriteLine("======================================================");

                Console.WriteLine("SATURDAY:");
                Console.WriteLine("07:30AM - 10:30AM  | PURPOSIVE COMMUNICATION");
                Console.WriteLine("10:30AM - 01:30PM  | PRINCIPLE OF ACCOUNTING");
                Console.WriteLine("02:00PM - 05:00PM  | MATH IN THE MODERN WORLD");
                Console.WriteLine("05:00PM - 08:00PM  | FILIPINOLOHIYA AT PAMBANSANG KAUNLARAN");
                Console.WriteLine("======================================================");

                menuActions(program,section);



            }

            else if (program == "BSIT" && section == "1-2")
            {

            }

            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("No Schedule found in this section, Please enter a valid section.");
                Console.WriteLine(" ");
            }
        }

        //menu bar dasjdgaigs
        static void menuActions(string program, string section)
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("What would you like to do? Enter the number");
            Console.WriteLine("1 - View Subject description & professors");
            Console.WriteLine("2 - Save schedule & exit");
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Enter choice: ");
            if (int.TryParse(Console.ReadLine(), out int menu))
            {
                switch (menu)
                {
                    case 1:
                        subjectDescription(program, section);
                        break;

                    case 2:
                        saveandexit();
                        break;
                    case 3: 

                    default:
                        Console.WriteLine("Invalid choice, please try again");
                        menuActions(program, section);
                        break;
                }

            }

            else
            {
                Console.WriteLine("Invalid input. Please enter a number");
                menuActions(program, section);
            }

        }//

        //Description of the subject and professors
        static void subjectDescription(string program,string section)
        {
            if (program == "BSIT" && section == "1-1")
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("MONDAY:");
                Console.WriteLine("1. INTRODUCTION TO COMPUTING" +
                    "\n > You will introduce in Hardware, software and Netwoking" +
                    "\n Professor: Mr. Kim Daniel");
                Console.WriteLine("1. CWTS 1" +
                    "\n >Civic Walfare Training and Service 1. Usually you'll do sevices such as cleaning, and seminars" +
                    "\n Professor: Mr. Gabriel De Juan");
                Console.WriteLine("======================================================");

                Console.WriteLine("TUESDAY:");
                Console.WriteLine("1. PATHFIT 1" +
                    "\n > You will do the Physical Fitness test, cheerdance and Zumba" +
                    "\n Professor: Ms. Riane Reina");
                Console.WriteLine("2. COMPUTER PROGRAMMING 1" +
                    "\n > You will be using the Java Language and learn the basic and fundamentals." +
                    "\n Professor: Ms. Lina Trinidad");
                Console.WriteLine("======================================================");

                Console.WriteLine("SATURDAY:");
                Console.WriteLine("1. PURPOSIVE COMMUNICATION" +
                    "\n > You will learn the different kinds of communications and Roleplay" +
                    "\n Professor: Mrs. Yumi Reyes");
                Console.WriteLine("2. PRINCIPLE OF ACCOUNTING" +
                    "\n > You will be learning the basics of how to do a ledger" +
                    "\n Professor: Mr. Ihan Unia");
                Console.WriteLine("3. MATH IN THE MODERN WORLD" +
                    "\n > Basics of Math in 21st Century. Math in nature and etc." +
                    "\n Professor: Mrs. Stella Anne");
                Console.WriteLine("4. FILIPINOLOHIYA AT PAMBANSANG KAUNLARAN" +
                    "\n > You will learn the history of words and you'll be translating a programming langguage into filipino." +
                    "\n Professor: Mr. Yunho Island");
                Console.WriteLine("======================================================");
                

                //menu for the 2nd time
                menu2(program, section);

            }
        }//

        static void menu2(string program, string section)
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("What would you like to do? Enter the number");
            Console.WriteLine("1 - Wrong Schedule.");
            Console.WriteLine("2 - Save schedule & exit.");
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Enter choice: ");
            if (int.TryParse(Console.ReadLine(), out int menu))
            {
                switch (menu)
                {
                    case 1:
                        // main menu po sana itu uulit
                        break;

                    case 2:
                        saveandexit();
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again");
                        menuActions(program, section);
                        break;
                }

            }

            else
            {
                Console.WriteLine("Invalid input. Please enter a number");
                menuActions(program, section);
            }

        }//

        static void saveandexit()
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Saved! Good luck this Sem! :3");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }//


    }
}//last
