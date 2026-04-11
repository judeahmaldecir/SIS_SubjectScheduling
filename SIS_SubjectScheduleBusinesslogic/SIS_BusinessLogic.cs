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

        //for DATABASE
        //private static StudentDBData data = new StudentDBData();


        //public static bool Login(string studentNumber, string studentPassword)
        //{
        //    var student = data.GetByStudentNumber(studentNumber);
        //    return student != null && student.StudentPassword == studentPassword;
        //}

        //public static void Register(string studentNumber, string studentPassword)
        //{
        //    var student = data.GetByStudentNumber(studentNumber);
        //    if (student == null)
        //    {
        //        data.Add(new Student { StudentNumber = studentNumber.ToUpper(), StudentPassword = studentPassword });
        //    }
        //}

        //BSIT
        public static void ScheduleBSIT(string section)
        {
           if (section == "1-1")
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("-------< BSIT 1-1 | ‘1st Sem’ CLASS SCHEDULE >-------");
                Console.WriteLine(" ");
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

                Console.WriteLine(" ");
                Console.WriteLine("********************************************************************************* ");
                Console.WriteLine(" ");


                Console.WriteLine("-------< BSIT 1-1 | ‘2nd  Sem’ CLASS SCHEDULE >-------");
                Console.WriteLine(" ");
                Console.WriteLine("MONDAY:");
                Console.WriteLine("07:30AM - 12:30PM  | COMPUTER PROGRAMMING 2");
                Console.WriteLine("02:00PM - 05:00PM  | DISCRETE STRUCTURES 1");
                Console.WriteLine("05:00PM - 08:00PM  | READING IN PHILIPPINE HISTORY");
                Console.WriteLine("======================================================");

                Console.WriteLine("WEDNESDAY:");
                Console.WriteLine("08:00AM - 10:00AM  | PATHFIT 2 ");
                Console.WriteLine("10:30AM - 01:30PM  | PEOPLE & EARTH’S ECOSYSTEM");
                Console.WriteLine("01:30PM - 05:30PM  | CWTS 2");
                Console.WriteLine("======================================================");

                Console.WriteLine("SATURDAY:");
                Console.WriteLine("07:30AM - 10:30AM  | POLITICS, GOVERNANCE & CITIZENSHIP");
                Console.WriteLine("10:30AM - 01:30PM  | PAGSASALIN SA KONTEXTONG FILIPINO");
                Console.WriteLine("======================================================");
            }

            else if (section == "2-1")
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("-------< BSIT 2-1 | ‘1st Sem’ CLASS SCHEDULE >-------");
                Console.WriteLine(" ");
                Console.WriteLine("MONDAY:");
                Console.WriteLine("07:30AM - 10:30AM  | PROGRAMMING 3");
                Console.WriteLine("12:00PM - 02:00PM  | PATHFIT 3");
                Console.WriteLine("04:00PM - 09:30PM  | DATA STRUCTURES AND ALGORITHMS");
                Console.WriteLine("==========================================================");

                Console.WriteLine("WEDNESDAY:");
                Console.WriteLine("8:00AM - 1:00PM  | DATA COMMUNICATIONS & NETWORKING");
                Console.WriteLine("02:30PM - 06:00PM  | OPERATING SYSTEM");
                Console.WriteLine("==========================================================");

                Console.WriteLine("SATURDAY:");
                Console.WriteLine("07:30AM - 10:30AM  | READING VISUAL ARTS");
                Console.WriteLine("10:30AM - 01:30PM  | FREE ELECTIVE 1");
                Console.WriteLine("02:00PM - 05:00PM  | UNDERSTANDING SELF");
                Console.WriteLine("==========================================================");

                Console.WriteLine(" ");
                Console.WriteLine("***************************************************************************************");
                Console.WriteLine(" ");

                Console.WriteLine("-------< BSIT 2-1 | ‘2nd Sem’ CLASS SCHEDULE >-------");
                Console.WriteLine(" ");
                Console.WriteLine("MONDAY:");
                Console.WriteLine("10:30AM - 01:30AM  | HUMAN COMPUTER INTERACTION");
                Console.WriteLine("02:00PM - 07:00PM  | NETWORK ADMINISTRATION");
                Console.WriteLine("==========================================================");

                Console.WriteLine("TUESDAY:");
                Console.WriteLine("2:00PM - 4:00PM  | PATHFIT 4");
                Console.WriteLine("04:00PM - 09:00PM  | INFORMATION MANAGEMENT");
                Console.WriteLine("==========================================================");

                Console.WriteLine("FRIDAY:");
                Console.WriteLine("11:00AM - 1:00PM  | FREE ELECTIVE 2");
                Console.WriteLine("==========================================================");


                Console.WriteLine("SATURDAY:");
                Console.WriteLine("07:30AM - 12:30PM  | OBJECT ORIENTED PROGRAMMING");
                Console.WriteLine("02:00PM - 07:00PM  | INTEGRATIVE PROGRAMMING & TECHNOLOGIES");
                Console.WriteLine("==========================================================");

            }

           else if (section == "3-1")
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");

                Console.WriteLine("-------< BSIT 3-1 | ‘1st Sem’ CLASS SCHEDULE >-------");
                Console.WriteLine(" ");
                Console.WriteLine("MONDAY:");
                Console.WriteLine("07:30AM - 10:30AM  | FUNDAMENTALS OF RESEARCH");
                Console.WriteLine("12:00PM - 02:00PM  | WEB DEVELOPMENT");
                Console.WriteLine("==========================================================");

                Console.WriteLine("WEDNESDAY:");
                Console.WriteLine("8:00AM - 12:00PM  | DATA ADMINISTRATION");
                Console.WriteLine("02:30PM - 06:00PM  | ART APPRECIATION");
                Console.WriteLine("==========================================================");

                Console.WriteLine("SATURDAY:");
                Console.WriteLine("07:30AM - 10:30AM  | SYSTEM INTEGRATION & ARCHITECHTURE 1");
                Console.WriteLine("02:00PM - 05:30PM  | MULTIMEDIA");
                Console.WriteLine("==========================================================");

                Console.WriteLine(" ");
                Console.WriteLine("***************************************************************************************");
                Console.WriteLine(" ");

                Console.WriteLine("-------< BSIT 3-1 | ‘2nd Sem’ CLASS SCHEDULE >-------");
                Console.WriteLine(" ");
                Console.WriteLine("TUESDAY:");
                Console.WriteLine("10:30AM - 01:30AM  | APPLICATIONS DEVELOPMENT & EMERGING TECHNOLOGY");
                Console.WriteLine("02:00PM - 07:00PM  | THE CONTEMPORARY WORLD");
                Console.WriteLine("==========================================================");

                Console.WriteLine("WEDNESDAY:");
                Console.WriteLine("2:00PM - 4:00PM  | ETHICS");
                Console.WriteLine("04:00PM - 09:00PM  | PRINCIPLES OF ORGANIZATION & MANAGEMENT");
                Console.WriteLine("==========================================================");

                Console.WriteLine("FRIDAY:");
                Console.WriteLine("07:30AM - 12:30PM  | CAPSTONE PROJECT 1");
                Console.WriteLine("11:00AM - 1:00PM  | INFORMATION ASSURANCE & SECURITY 1");
                Console.WriteLine("==========================================================");


                Console.WriteLine("------------------ SUMMER:");
                Console.WriteLine("9:00AM - 1:00PM  | IT ELECTIVE 3");
                Console.WriteLine("==========================================================");
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


    }
}//last
        