using SIS_SubjectScheduleDataLogic;
using SIS_SubjectScheduleModels;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Transactions;

namespace SIS_SubjectScheduleBusinesslogic
{
    public class SIS_BusinessLogic
    {
        private static StudentJsonData data = new StudentJsonData();

        public static bool Login(string studentNumber, string studentPassword)
        {
            var student = data.GetByNumber(studentNumber);
            return student != null && student.StudentPassword == studentPassword;
        }

        public static void Register(string studentNumber, string studentPassword)
        {
            var student = data.GetByNumber(studentNumber);
            if (student == null)
            {
                data.Add(new Student { StudentNumber = studentNumber.ToUpper(), StudentPassword = studentPassword });
            }
        }

        //BSIT
        public static void ScheduleBSIT(string section)
        {
           if (section == "1-1")
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
            }

            else
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("Sorry Section is not on the list try again");
            }
        }

        //-----------------------------------------------------------------------------------------------------------

        public static void ShowBSITMenu(string section)
        {
            Console.WriteLine("------<<What would you like to do?>>------");
            Console.WriteLine("1 | See Subject Description");
            Console.WriteLine("2 | See Subject Professors");
            Console.WriteLine("3 | Save Schedule");
            Console.WriteLine("4 | Exit and Don't Save");
            Console.WriteLine("==========================================");
            Console.Write("Enter Number: ");
            int numberChoice = int.Parse(Console.ReadLine());

            switch (numberChoice)
            {
                // add mga methods 
                case 1:
                    //ShowSubjectDescription(section);
                    break;
                case 2:
                    //ShowSubjectProfessors(section);
                    break;
                case 3:
                    //SaveSchedule(section);
                    break;
                case 4:
                    Console.WriteLine("Exiting");
                    break;
                default:
                    Console.WriteLine("Sorry number is not on the list, try again :<");
                    break;
            }
        }
    }
}//last
        