//Hanapin lahat ng scheduling for PUP BINAN Programs (IF KAYA)
// - each years and their schedule and naka SET na siya
// - if may 2 section per year I think need pa isama un? 
// - Kung kaya per sem??
// - per program is naka if else.


namespace SIS_SubjectScheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string program; //BSIT or DIT (could be lahat ng program)
            string year_level_section;
            int sem;

            Console.WriteLine("--------------< Student Class Schedule >--------------");
            Console.WriteLine("Welcome IT student to the scheduling Page. This is where you can see your class schedule.");
            Console.WriteLine("======================================================");
            Console.WriteLine("SELECT A PROGRAM");
            Console.WriteLine("BSIT || DIT || BSCPE || DCPE " +
                "\nBSIE || BEED || BSHRM || BSSED");

            Console.WriteLine("======================================================");
            Console.Write("Enter your Program: ");
            program = Console.ReadLine().ToUpper();

            Console.Write("Enter your Year level and Section (e.g. 1-1, 1-2, 2-1 until 4-1): ");
            year_level_section = Console.ReadLine().ToUpper();

            Console.Write("Enter your Program: ");




            if (program == "BSIT")
            {
                if (year_level_section == "1-1")
                {
                    Console.WriteLine("**--------------< BSIT 1-1 CLASS SCHEDULE >--------------**");
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

                    // add conformation button, if the student's input is wrong then cancel (ask if this schedule is correct.)


                    else
                    {
                        Console.WriteLine("Invalid Program. Please try again.");
                    }

                }

            }

        }
    } 
}//last
