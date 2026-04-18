using SIS_SubjectScheduleModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace SIS_SubjectScheduleDataLogic
{
    public class StudentJsonData
 
    {
        private List<Student> students = new List<Student>();
        private string _jsonFileName;

        public StudentJsonData()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/students.json";
            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (students.Count <= 0)
            {
       
                students.Add(new Student { StudentNumber = "2024-00021-BN-0", StudentPassword = "leehan21" });
                students.Add(new Student { StudentNumber = "2025-00014-BN-0", StudentPassword = "judeah" });
                SaveDataToJsonFile();
            }
        }

        private void SaveDataToJsonFile()
        {
            string jsonString = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_jsonFileName, jsonString);
        }

        private void RetrieveDataFromJsonFile()
        {
            if (!File.Exists(_jsonFileName)) return;

            string jsonString = File.ReadAllText(_jsonFileName);
            var loaded = JsonSerializer.Deserialize<List<Student>>(jsonString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            students = loaded?.Where(s => s != null).ToList() ?? new List<Student>();
        }

   
        public void Add(Student student)
        {
            RetrieveDataFromJsonFile();
            students.Add(student);
            SaveDataToJsonFile();
        }

        public List<Student> GetStudents()
        {
            RetrieveDataFromJsonFile();
            return students;
        }

        public Student? GetByNumber(string studentNumber)
        {
            RetrieveDataFromJsonFile();
            return students.FirstOrDefault(x => x.StudentNumber.ToUpper() == studentNumber.ToUpper());
        }

        public void SaveAll(List<Student> studentsFromDb)
        {
            string jsonString = JsonSerializer.Serialize(studentsFromDb, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_jsonFileName, jsonString);
        }

        // ------------------------------------------- Showing Schedules T.T !!!

        public void ShowSchedule(Student student)
        {
            if (string.IsNullOrEmpty(student.Program) || string.IsNullOrEmpty(student.Section))
            {
                Console.WriteLine("You are registered but have not selected a program/section yet.");
                return;
            }

            switch (student.Program)
            {
                //----------------------------------------- BSIT!!!
                case "BSIT":
                    if (student.Section == "1-1")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("-------< BSIT 1-1 | ‘1st Sem’ CLASS SCHEDULE >-------");
                        Console.WriteLine(" ");
                        Console.WriteLine("MONDAY:");
                        Console.WriteLine("7:30AM - 12:30AM  | INTRODUCTION TO COMPUTING");
                        Console.WriteLine("01:00PM - 04:00PM  | CWTS 1");
                        Console.WriteLine("======================================================");

                        Console.WriteLine("TUESDAY:");
                        Console.WriteLine("12:00PM - 02:30PM  | PATHFIT 1");
                        Console.WriteLine("03:30PM - 06:00PM  | COMPUTER PROGRAMMING 1");
                        Console.WriteLine("06:00PM - 08:00PM  | COMPUTER PROGRAMMING 1 (LAB)");
                        Console.WriteLine("======================================================");

                        Console.WriteLine("SATURDAY:");
                        Console.WriteLine("07:30AM - 10:30AM  | PURPOSIVE COMMUNICATION");
                        Console.WriteLine("10:30AM - 01:30PM  | PRINCIPLE OF ACCOUNTING");
                        Console.WriteLine("02:00PM - 05:00PM  | MATH IN THE MODERN WORLD");
                        Console.WriteLine("05:00PM - 08:00PM  | FILIPINOLOHIYA AT PAMBANSANG KAUNLARAN");
                        Console.WriteLine("======================================================");


                        Console.WriteLine(" ");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine("**********************************************************");
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

                    else if (student.Section == "2-1")
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
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine("**********************************************************");
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

                    else if (student.Section == "3-1")
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
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine("**********************************************************");
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

                    else if (student.Section == "4-1")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");

                        Console.WriteLine("-------< BSIT 4-1 | ‘1st Sem’ CLASS SCHEDULE >-------");
                        Console.WriteLine(" ");
                        Console.WriteLine("MONDAY:");
                        Console.WriteLine("09:30AM - 02:30PM  | SOCIAL & PROFSSIONAL ISSUES IN COMPUTING");
                        Console.WriteLine("03:00PM - 06:00PM  | IT ELECTIVE 4");
                        Console.WriteLine("==========================================================");

                        Console.WriteLine("THURSDAY:");
                        Console.WriteLine("07:30AM - 12:30PM  | INFORMATION ASSURANCE & SECURITY 2");
                        Console.WriteLine("02:00PM - 07:00PM  | SCIENCE, TECHNOLOGY & SOCIETY/AGHAM");
                        Console.WriteLine("==========================================================");


                        Console.WriteLine("SATURDAY:");
                        Console.WriteLine("08:30AM - 01:30AM  | SYSTEMS ADMINISTRATION & MAINTENANCE");
                        Console.WriteLine("02:00PM - 05:30PM  | CAPSTONE PROJECT 2");
                        Console.WriteLine("==========================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine(" ");

                        Console.WriteLine("-------< BSIT 4-1 | ‘2nd Sem’ CLASS SCHEDULE >-------");
                        Console.WriteLine(" ");
                        Console.WriteLine("MONDAY:");
                        Console.WriteLine("11:30AM - 04:00PM  | TECHNOPRENURSHIP”");
                        Console.WriteLine("==========================================================");
                        Console.WriteLine(" PRACTRICUM (500 Hours)");
                        Console.WriteLine("==========================================================");

                    }

                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("That section in BSIT does not exist :<");
                    }

                    break;

                //----------------------------------------- DIT Schedules!!!
                case "DIT":

                    if (student.Section == "1-1")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("-------< DIT 1-1 | ‘1st Sem’ CLASS SCHEDULE >-------");
                        Console.WriteLine(" ");
                        Console.WriteLine("MONDAY:");
                        Console.WriteLine("12:00PM - 02:30PM  | PATHFIT 1");
                        Console.WriteLine("03:30PM - 08:00PM  | COMPUTER PROGRAMMING 1");
                        Console.WriteLine("======================================================");

                        Console.WriteLine("WEDNESDAY:");
                        Console.WriteLine("08:30AM - 12:30AM  | INTRODUCTION TO COMPUTING");
                        Console.WriteLine("01:00PM - 04:00PM  | CWTS 1");
                        Console.WriteLine("======================================================");


                        Console.WriteLine("SATURDAY:");
                        Console.WriteLine("07:30AM - 10:30AM  | PURPOSIVE COMMUNICATION");
                        Console.WriteLine("02:00PM - 05:00PM  | MATH IN THE MODERN WORLD");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine(" ");


                        Console.WriteLine("-------< DIT 1-1 | ‘2nd  Sem’ CLASS SCHEDULE >-------");
                        Console.WriteLine(" ");
                        Console.WriteLine("MONDAY:");
                        Console.WriteLine("07:30AM - 9:30AM  | COMPUTER PROGRAMMING 2");
                        Console.WriteLine("======================================================");

                        Console.WriteLine("WEDNESDAY:");
                        Console.WriteLine("08:00AM - 10:00AM  | PATHFIT 2 ");
                        Console.WriteLine("01:30PM - 05:30PM  | CWTS 2");
                        Console.WriteLine("======================================================");

                        Console.WriteLine("THURSDAY");
                        Console.WriteLine("02:00PM - 05:00PM  | DISCRETE STRUCTURES 1");
                        Console.WriteLine("======================================================");

                    }

                    else if (student.Section == "2-1")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("-------< DIT 2-1 | ‘1st Sem’ CLASS SCHEDULE >-------");
                        Console.WriteLine(" ");
                        Console.WriteLine("MONDAY:");
                        Console.WriteLine("07:30AM - 10:30AM  | PROGRAMMING 3");
                        Console.WriteLine("1:00PM - 05:00PM  | DATA STRUCTURES AND ALGORITHMS");
                        Console.WriteLine("==========================================================");

                        Console.WriteLine("WEDNESDAY:");
                        Console.WriteLine("07:30AM - 11:00AM  | OPERATING SYSTEM");
                        Console.WriteLine("1:00PM - 4:00PM  | DATA COMMUNICATIONS & NETWORKING");
                        Console.WriteLine("5:00PM - 7:00PM  | PATHFIT 3");
                        Console.WriteLine("==========================================================");

                        Console.WriteLine("SATURDAY:");
                        Console.WriteLine("07:30PM - 12:30PM  | INTEGRATIVE PROGRAMMING & TECHNOLOGIES");
                        Console.WriteLine("2:00PM - 7:30PM  | OBJECT ORIENTED PROGRAMMING");
                        Console.WriteLine("==========================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine(" ");

                        Console.WriteLine("-------< DIT 2-1 | ‘2nd Sem’ CLASS SCHEDULE >-------");
                        Console.WriteLine(" ");
                        Console.WriteLine("MONDAY:");
                        Console.WriteLine("12:00PM - 02:00PM  | WEB DEVELOPMENT");
                        Console.WriteLine("02:30PM - 04:30PM  | HUMAN COMPUTER INTERACTION");
                        Console.WriteLine("==========================================================");

                        Console.WriteLine("TUESDAY:");
                        Console.WriteLine("08:00AM - 1:00PM  | INFORMATION MANAGEMENT");
                        Console.WriteLine("2:00PM - 4:00PM  | PATHFIT 4");
                        Console.WriteLine("==========================================================");

                        Console.WriteLine("SATURDAY:");
                        Console.WriteLine("09:30AM - 2:00PM  | MULTIMEDIA");
                        Console.WriteLine("02:30PM - 07:00PM  | NETWORK ADMINISTRATION");
                        Console.WriteLine("==========================================================");

                    }

                    else if (student.Section == "3-1")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("-------< DIT 3-1 | ‘1st Sem’ CLASS SCHEDULE >-------");
                        Console.WriteLine(" ");
                        Console.WriteLine("TUESDAY:");
                        Console.WriteLine("07:30AM - 10:30AM  | FUNDAMENTALS OF RESEARCH");
                        Console.WriteLine("01:00PM - 05:00PM  | CAPSTONE PROJECT 1");
                        Console.WriteLine("==========================================================");

                        Console.WriteLine("THURSDAY:");
                        Console.WriteLine("08:30PM - 01:00PM  | NETWORK ADMINISTRATION");
                        Console.WriteLine("02:00AM - 6:00PM  | INFORMATION ASSURANCE & SECURITY 1");
                        Console.WriteLine("==========================================================");

                        Console.WriteLine("SATURDAY:");
                        Console.WriteLine("08:30AM - 12:00PM  | MULTIMEDIA");
                        Console.WriteLine("==========================================================");



                        Console.WriteLine(" ");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine(" ");

                        Console.WriteLine("-------< DIT 3-1 | ‘2nd Sem’ CLASS SCHEDULE >-------");
                        Console.WriteLine(" ");
                        Console.WriteLine("WEDNESDAY:");
                        Console.WriteLine("07:30AM - 10:30AM  | SYSTEM INTEGRATION & ARCHITECHTURE 1");
                        Console.WriteLine("02:30PM - 07:30PM  | APPLICATIONS DEVELOPMENT & EMERGING TECHNOLOGY");
                        Console.WriteLine("==========================================================");

                        Console.WriteLine("THURSDAY:");
                        Console.WriteLine("12:00PM - 05:00PM  | CAPSTONE PROJECT 2");
                        Console.WriteLine("==========================================================");
                        Console.WriteLine("TECHNOPRENURSHIP");
                        Console.WriteLine("==========================================================");
                    }

                    else
                    {
                        Console.WriteLine("That section in DIT does not exist :<");
                    }

                    break;

                //DEFAULT
                default:
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine("Sorry Program is not on the list try again :<");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    break;


            }

        }

        public void ShowSubjectDescription(Student student)
        {
            switch (student.Program)
            {
                //----------------------------------------- BSIT Subj Desc!!!
                case "BSIT":
                    if (student.Section == "1-1")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("-------< BSIT 1-1 | ‘1st Sem’ SUBJECT DESCRIPTION >-------");

                        Console.WriteLine(" ");
                        Console.WriteLine("> INTRODUCTION TO COMPUTING");
                        Console.WriteLine(" - Introduces hardware to software computer components");
                        Console.WriteLine(" - including HTMLS, Part of computers, and basics of Networking");
                        Console.WriteLine("Professor: Ms. Stella Yuzon");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> COMPUTER PROGRAMMING 1");
                        Console.WriteLine(" - Introduces the fundamentals of programming using Java");
                        Console.WriteLine(" - Covers syntax, control structures, and basic problem-solving");
                        Console.WriteLine("Professor: Mr. Kevin Ramirez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> CWTS 1");
                        Console.WriteLine(" - Focuses on civic welfare training and community service");
                        Console.WriteLine(" - Students engage in activities that promote social responsibility like volunteering and community projects");
                        Console.WriteLine("Professor: Mr. Ramon Dela Cruz");
                        Console.WriteLine("======================================================");



                        Console.WriteLine("> PATHFIT 1");
                        Console.WriteLine(" - Emphasizes physical fitness and healthy lifestyle practices");
                        Console.WriteLine(" - Includes basic exercises and wellness awareness");
                        Console.WriteLine(" - Physical Fitnest Test, & Zumba");
                        Console.WriteLine("Professor: Ms. Angela Santos");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> PURPOSIVE COMMUNICATION");
                        Console.WriteLine(" - Develops effective communication skills in English and Filipino");
                        Console.WriteLine(" - Covers writing, speaking, and multimedia communication");
                        Console.WriteLine("Professor: Dr. Maria Villanueva");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> PRINCIPLE OF ACCOUNTING");
                        Console.WriteLine(" - Introduces basic accounting concepts and financial statements");
                        Console.WriteLine(" - Focuses on recording, classifying, and summarizing transactions");
                        Console.WriteLine("Professor: Mr. William Tan");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> MATH IN THE MODERN WORLD");
                        Console.WriteLine(" - Explores practical applications of mathematics in daily life");
                        Console.WriteLine(" - Topics include logic, patterns, probability, and statistics");
                        Console.WriteLine("Professor: Ms. Clarisse Mendoza");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> FILIPINOLOHIYA AT PAMBANSANG KAUNLARAN");
                        Console.WriteLine(" - Examines Filipino identity, language, and culture");
                        Console.WriteLine(" - Connects national development with sociocultural studies");
                        Console.WriteLine("Professor: Dr. Ernesto Reyes");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine(" ");

                        Console.WriteLine("-------< BSIT 1-1 | ‘2nd Sem’ SUBJECT DESCRIPTION >-------");

                        Console.WriteLine(" ");
                        Console.WriteLine("> COMPUTER PROGRAMMING 2");
                        Console.WriteLine(" - Focuses on java basic GUI/Graphic User Interface using Java swing and Java Frame");
                        Console.WriteLine("Professor: Ms. Jani Aquino");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> DISCRETE STRUCTURES 1");
                        Console.WriteLine(" - Covers logic, set theory, functions, and relations");
                        Console.WriteLine(" - Provides mathematical foundation for computer science");
                        Console.WriteLine("Professor: Mr. Adrian Bautista");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> READING IN PHILIPPINE HISTORY");
                        Console.WriteLine(" - Analyzes primary sources to understand Philippine history");
                        Console.WriteLine(" - Encourages critical thinking about historical narratives");
                        Console.WriteLine("Professor: Dr. Liza Ramos");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> PATHFIT 2");
                        Console.WriteLine(" - Continues physical fitness training with advanced routines");
                        Console.WriteLine(" - Focuses on endurance, strength, and team activities");
                        Console.WriteLine(" - introduce Gymnastics and Cheerleading");
                        Console.WriteLine("Professor: Ms. Angela Santos");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> PEOPLE & EARTH’S ECOSYSTEM");
                        Console.WriteLine(" - Studies ecological systems and human-environment interaction");
                        Console.WriteLine(" - Promotes environmental awareness and sustainability");
                        Console.WriteLine("Professor: Mr. Carlo Fernandez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> CWTS 2");
                        Console.WriteLine(" - Continuation of civic welfare training");
                        Console.WriteLine(" - Students implement community-based projects and outreach");
                        Console.WriteLine("Professor: Mr. Ramon Dela Cruz");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> POLITICS, GOVERNANCE & CITIZENSHIP");
                        Console.WriteLine(" - Discusses political systems, governance, and civic duties");
                        Console.WriteLine(" - Encourages active participation in democratic processes");
                        Console.WriteLine("Professor: Dr. Jose Richards");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> PAGSASALIN SA KONTEXTONG FILIPINO");
                        Console.WriteLine(" - Focuses on translation theory and practice in Filipino");
                        Console.WriteLine(" - Applies translation in literature, media, and technical texts");
                        Console.WriteLine("Professor: Ms. Regina Cruz");
                        Console.WriteLine("======================================================");
                    }

                    else if (student.Section == "2-1")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("-------< BSIT 2-1 | ‘1st Sem’ SUBJECT DESCRIPTION >-------");

                        Console.WriteLine(" ");
                        Console.WriteLine("> PROGRAMMING 3");
                        Console.WriteLine(" - Advanced programming concepts with C++");
                        Console.WriteLine(" - Focuses on object-oriented design and debugging techniques");
                        Console.WriteLine("Professor: Mr. Kevin Ramirez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> PATHFIT 3");
                        Console.WriteLine(" - Focuses on table tennis as a lifelong fitness activity");
                        Console.WriteLine(" - Covers singles and doubles play, rules, and techniques");
                        Console.WriteLine("Professor: Ms. Angela Santos");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> DATA STRUCTURES AND ALGORITHMS");
                        Console.WriteLine(" - Covers arrays, linked lists, stacks, queues, and trees using C++");
                        Console.WriteLine(" - Emphasizes algorithm efficiency and problem-solving");
                        Console.WriteLine("Professor: Mr. Adrian Bautista");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> DATA COMMUNICATIONS & NETWORKING");
                        Console.WriteLine(" - Introduces network models, protocols, and data transmission");
                        Console.WriteLine(" - Focuses on LAN, WAN, and internet technologies");
                        Console.WriteLine("Professor: Mr. Carlo Fernandez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> OPERATING SYSTEM");
                        Console.WriteLine(" - Explores OS concepts including processes, memory, and file systems");
                        Console.WriteLine(" - Covers Linux and Windows fundamentals");
                        Console.WriteLine("Professor: Ms. Clarisse Mendoza");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> READING VISUAL ARTS");
                        Console.WriteLine(" - Examines art forms and visual culture");
                        Console.WriteLine(" - Encourages appreciation and critical analysis of artworks");
                        Console.WriteLine("Professor: Dr. Liza Ramos");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> FREE ELECTIVE 1");
                        Console.WriteLine(" - Focuses on office ethics and professional behavior");
                        Console.WriteLine(" - Emphasizes personality development, workplace conduct, and physical ethics");
                        Console.WriteLine("Professor: Dr. Maria Villanueva");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> UNDERSTANDING THE SELF");
                        Console.WriteLine(" - Focuses on self-awareness, identity, and personal growth");
                        Console.WriteLine(" - Encourages reflection and interpersonal skills development");
                        Console.WriteLine("Professor: Ms. Regina Cruz");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine(" ");

                        Console.WriteLine("-------< BSIT 2-1 | ‘2nd Sem’ SUBJECT DESCRIPTION >-------");

                        Console.WriteLine(" ");
                        Console.WriteLine("> HUMAN COMPUTER INTERACTION");
                        Console.WriteLine(" - Studies design principles for user interfaces");
                        Console.WriteLine(" - Focuses on usability, accessibility, and user experience");
                        Console.WriteLine("Professor: Mr. Joseph Tan");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> NETWORK ADMINISTRATION");
                        Console.WriteLine(" - Covers configuration and management of computer networks");
                        Console.WriteLine(" - Includes security, troubleshooting, and server administration");
                        Console.WriteLine("Professor: Mr. Carlo Fernandez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> PATHFIT 4");
                        Console.WriteLine(" - Enhances physical fitness through advanced sports activity, VOLLEYBALL");
                        Console.WriteLine(" - Focuses on teamwork, endurance, and performance");
                        Console.WriteLine("Professor: Ms. Angela Santos");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> INFORMATION MANAGEMENT");
                        Console.WriteLine(" - Introduces database systems and information organization");
                        Console.WriteLine(" - Covers SQL, data modeling, and information security");
                        Console.WriteLine("Professor: Ms. Stella Yuzon");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> FREE ELECTIVE 2");
                        Console.WriteLine(" - Provides opportunity to learn a new foreign language");
                        Console.WriteLine(" - Content varies depending on the language chosen");
                        Console.WriteLine("Professor: Assigned foreign teacher");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> OBJECT ORIENTED PROGRAMMING");
                        Console.WriteLine(" - Focuses on OOP principles such as encapsulation and inheritance");
                        Console.WriteLine(" - Uses Java/C# for practical application");
                        Console.WriteLine("Professor: Mr. Kevin Ramirez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> INTEGRATIVE PROGRAMMING & TECHNOLOGIES");
                        Console.WriteLine(" - Combines multiple programming languages and tools");
                        Console.WriteLine(" - Focuses on integration of web, desktop, and database systems");
                        Console.WriteLine("Professor: Ms. Clarisse Mendoza");
                        Console.WriteLine("======================================================");

                    }

                    else if (student.Section == "3-1")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("-------< BSIT 3-1 | ‘1st Sem’ SUBJECT DESCRIPTION >-------");

                        Console.WriteLine(" ");
                        Console.WriteLine("> FUNDAMENTALS OF RESEARCH");
                        Console.WriteLine(" - Introduces research methods and academic writing");
                        Console.WriteLine(" - Focuses on problem formulation, data collection, and analysis");
                        Console.WriteLine("Professor: Mr. Gabriel Dela Cruz");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> WEB DEVELOPMENT");
                        Console.WriteLine(" - Covers front-end and back-end web technologies");
                        Console.WriteLine(" - Includes HTML, CSS, JavaScript, and PHP basics");
                        Console.WriteLine("Professor: Ms. Ina Enilla");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> DATA ADMINISTRATION");
                        Console.WriteLine(" - Focuses on database management and administration tasks");
                        Console.WriteLine(" - Covers SQL optimization, backup, and security");
                        Console.WriteLine("Professor: Mr. Joseph Tan");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> ART APPRECIATION");
                        Console.WriteLine(" - Explores visual arts and cultural heritage");
                        Console.WriteLine(" - Encourages critical analysis and creative expression");
                        Console.WriteLine("Professor: Dr. Liza Ramos");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> SYSTEM INTEGRATION & ARCHITECTURE 1");
                        Console.WriteLine(" - Introduces system design and integration concepts");
                        Console.WriteLine(" - Focuses on architecture frameworks and IT solutions");
                        Console.WriteLine("Professor: Mr. Adrian Bautista");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> MULTIMEDIA");
                        Console.WriteLine(" - Covers digital media creation and editing tools");
                        Console.WriteLine(" - Includes graphics, audio, video, and animation techniques");
                        Console.WriteLine("Professor: Ms. Regina Cruz");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine(" ");

                        Console.WriteLine("-------< BSIT 3-1 | ‘2nd Sem’ SUBJECT DESCRIPTION >-------");

                        Console.WriteLine(" ");
                        Console.WriteLine("> APPLICATIONS DEVELOPMENT & EMERGING TECHNOLOGY");
                        Console.WriteLine(" - Focuses on mobile and cloud-based applications");
                        Console.WriteLine(" - Explores emerging IT trends and innovations");
                        Console.WriteLine("Professor: Ms. Pheobe Quezon");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> THE CONTEMPORARY WORLD");
                        Console.WriteLine(" - Examines global issues and modern societal challenges");
                        Console.WriteLine(" - Encourages critical thinking on culture, politics, and economy");
                        Console.WriteLine("Professor: Dr. Ernesto Reyes");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> ETHICS");
                        Console.WriteLine(" - Discusses moral principles and professional conduct");
                        Console.WriteLine(" - Emphasizes workplace ethics and personality development");
                        Console.WriteLine("Professor: Dr. Maria Villanueva");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> PRINCIPLES OF ORGANIZATION & MANAGEMENT");
                        Console.WriteLine(" - Introduces organizational structures and management theories");
                        Console.WriteLine(" - Focuses on leadership, planning, and decision-making");
                        Console.WriteLine("Professor: Mr. Kevin Ramirez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> CAPSTONE PROJECT 1");
                        Console.WriteLine(" - Prepares students for research-based IT projects");
                        Console.WriteLine(" - Focuses on proposal writing and project planning");
                        Console.WriteLine("Professor: Mr. Adrian Bautista");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> INFORMATION ASSURANCE & SECURITY 1");
                        Console.WriteLine(" - Introduces cybersecurity principles and risk management");
                        Console.WriteLine(" - Covers encryption, authentication, and network defense");
                        Console.WriteLine("Professor: Mr. Carlo Fernandez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> IT ELECTIVE 3");
                        Console.WriteLine(" - Specialized elective focusing on advanced IT topics");
                        Console.WriteLine(" - Content depending on elective chosen by the Campus");
                        Console.WriteLine("Professor: Assigned per elective");
                        Console.WriteLine("======================================================");

                    }

                    else if (student.Section == "4-1")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("-------< BSIT 4-1 | ‘1st Sem’ SUBJECT DESCRIPTION >-------");

                        Console.WriteLine(" ");
                        Console.WriteLine("> SOCIAL & PROFESSIONAL ISSUES IN COMPUTING");
                        Console.WriteLine(" - Discusses ethical, legal, and social issues in IT practice");
                        Console.WriteLine(" - Emphasizes professionalism, responsibility, and global impact of computing");
                        Console.WriteLine("Professor: Dr. Maria Villanueva");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> IT ELECTIVE 4");
                        Console.WriteLine(" - Specialized elective focusing on advanced IT topics");
                        Console.WriteLine(" - Content depending on elective chosen by the Campus");
                        Console.WriteLine("Professor: Assigned per elective");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> INFORMATION ASSURANCE & SECURITY 2");
                        Console.WriteLine(" - Advanced study of cybersecurity and information protection");
                        Console.WriteLine(" - Covers intrusion detection, cryptography, and secure system design");
                        Console.WriteLine("Professor: Mr. Carlo Fernandez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> SCIENCE, TECHNOLOGY & SOCIETY / AGHAM");
                        Console.WriteLine(" - Explores the relationship of science and technology with society");
                        Console.WriteLine(" - Encourages critical reflection on innovation and social change");
                        Console.WriteLine("Professor: Dr. Ernesto Reyes");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> SYSTEMS ADMINISTRATION & MAINTENANCE");
                        Console.WriteLine(" - Focuses on managing and maintaining IT systems and servers");
                        Console.WriteLine(" - Includes troubleshooting, updates, and performance monitoring");
                        Console.WriteLine("Professor: Mr. Joseph Tan");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> CAPSTONE PROJECT 2");
                        Console.WriteLine(" - Continuation of Capstone Project 1 with implementation phase");
                        Console.WriteLine(" - Students develop, test, and present their IT solutions");
                        Console.WriteLine("Professor: Mr. Adrian Bautista");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine(" ");

                        Console.WriteLine("-------< BSIT 4-1 | ‘2nd Sem’ SUBJECT DESCRIPTION >-------");

                        Console.WriteLine(" ");
                        Console.WriteLine("> TECHNOPRENEURSHIP");
                        Console.WriteLine(" - Introduces entrepreneurship concepts in the IT field");
                        Console.WriteLine(" - Focuses on innovation, business planning, and startup development");
                        Console.WriteLine("Professor: Ms. Clarisse Mendoza");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> PRACTICUM (500 Hours)");
                        Console.WriteLine(" - Provides hands-on industry experience through internship");
                        Console.WriteLine(" - Students apply IT knowledge in real-world professional settings");
                        Console.WriteLine("Professor: Industry Supervisor / Practicum Coordinator");
                        Console.WriteLine("======================================================");
                    }
                    break;


                //----------------------------------------- DIT Subj Desc!!!
                case "DIT":
                    if (student.Section == "1-1")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("-------< DIT 1-1 | ‘1st Sem’ SUBJECT DESCRIPTION >-------");

                        Console.WriteLine(" ");
                        Console.WriteLine("> PATHFIT 1");
                        Console.WriteLine(" - Emphasizes physical fitness and healthy lifestyle practices");
                        Console.WriteLine(" - Includes basic exercises and wellness awareness");
                        Console.WriteLine(" - Physical Fitnest Test, & Zumba");
                        Console.WriteLine("Professor: Mr. Paolo Gutierrez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> COMPUTER PROGRAMMING 1");
                        Console.WriteLine(" - Introduces the fundamentals of programming using Java");
                        Console.WriteLine(" - Covers syntax, control structures, and basic problem-solving");
                        Console.WriteLine("Professor: Ms. Hannah Cruz");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> INTRODUCTION TO COMPUTING");
                        Console.WriteLine(" - Students will learn from hardware to software computer components");
                        Console.WriteLine(" - Including HTML basics, computer parts, and networking fundamentals");
                        Console.WriteLine("Professor: Mr. Luis Navarro");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> CWTS 1");
                        Console.WriteLine(" - Focuses on civic welfare training and community service");
                        Console.WriteLine(" - Students engage in activities that promote social responsibility like volunteering and community projects");
                        Console.WriteLine("Professor: Ms. Audrey Ann Deserva");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> PURPOSIVE COMMUNICATION");
                        Console.WriteLine(" - Develops effective communication skills in English and Filipino");
                        Console.WriteLine(" - Covers writing, speaking, and multimedia communication");
                        Console.WriteLine("Professor: Mr. Miguel Santos");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> MATH IN THE MODERN WORLD");
                        Console.WriteLine(" - Explores practical applications of mathematics in daily life");
                        Console.WriteLine(" - Topics include logic, patterns, probability, and statistics");
                        Console.WriteLine("Professor: Ms. Andrea Lopez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine(" ");

                        Console.WriteLine("-------< DIT 1-1 | ‘2nd Sem’ SUBJECT DESCRIPTION >-------");

                        Console.WriteLine(" ");
                        Console.WriteLine("> COMPUTER PROGRAMMING 2");
                        Console.WriteLine(" - Focuses on advanced programming concepts using C#");
                        Console.WriteLine(" - Includes object-oriented programming and data structures");
                        Console.WriteLine("Professor: Mr. Rafael Torres");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> PATHFIT 2");
                        Console.WriteLine(" - Continues physical fitness training with advanced routines");
                        Console.WriteLine(" - Focuses on endurance, strength, and team activities");
                        Console.WriteLine("Professor: Ms. Bianca Ramos");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> CWTS 2");
                        Console.WriteLine(" - Continuation of civic welfare training");
                        Console.WriteLine(" - Students implement community-based projects and outreach");
                        Console.WriteLine("Professor: Mr. Carlo Jimenez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> DISCRETE STRUCTURES 1");
                        Console.WriteLine(" - Covers logic, set theory, functions, and relations");
                        Console.WriteLine(" - Provides mathematical foundation for computer science");
                        Console.WriteLine("Professor: Mr. Yuno Delgado");
                        Console.WriteLine("======================================================");

                    }

                    else if (student.Section == "2-1")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("-------< DIT 2-1 | ‘1st Sem’ SUBJECT DESCRIPTION >-------");

                        Console.WriteLine(" ");
                        Console.WriteLine("> PROGRAMMING 3");
                        Console.WriteLine(" - Advanced programming concepts with Java and C++");
                        Console.WriteLine(" - Focuses on object-oriented design and debugging techniques");
                        Console.WriteLine("Professor: Mr. Daniel Cruz");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> DATA STRUCTURES AND ALGORITHMS");
                        Console.WriteLine(" - Covers arrays, linked lists, stacks, queues, and trees");
                        Console.WriteLine(" - Emphasizes algorithm efficiency and problem-solving");
                        Console.WriteLine("Professor: Ms. Patricia Gomez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> OPERATING SYSTEM");
                        Console.WriteLine(" - Explores OS concepts including processes, memory, and file systems");
                        Console.WriteLine(" - Covers Linux and Windows fundamentals");
                        Console.WriteLine("Professor: Mr. Victor Santiago");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> PATHFIT 3");
                        Console.WriteLine(" - Focuses on table tennis as a lifelong fitness activity");
                        Console.WriteLine(" - Covers singles and doubles play, rules, and techniques");
                        Console.WriteLine("Professor: Ms. Carla Hernandez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> INTEGRATIVE PROGRAMMING & TECHNOLOGIES");
                        Console.WriteLine(" - Combines multiple programming languages and tools");
                        Console.WriteLine(" - Focuses on integration of web, desktop, and database systems");
                        Console.WriteLine("Professor: Mr. Jerome Villanueva");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> OBJECT ORIENTED PROGRAMMING");
                        Console.WriteLine(" - Focuses on OOP principles such as encapsulation and inheritance");
                        Console.WriteLine(" - Uses Java/C# for practical application");
                        Console.WriteLine("Professor: Ms. Angela Ramirez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine(" ");

                        Console.WriteLine("-------< DIT 2-1 | ‘2nd Sem’ SUBJECT DESCRIPTION >-------");

                        Console.WriteLine(" ");
                        Console.WriteLine("> WEB DEVELOPMENT");
                        Console.WriteLine(" - Covers front-end and back-end web technologies");
                        Console.WriteLine(" - Includes HTML, CSS, JavaScript, and PHP basics");
                        Console.WriteLine("Professor: Mr. Roberto Cruz");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> HUMAN COMPUTER INTERACTION");
                        Console.WriteLine(" - Studies design principles for user interfaces");
                        Console.WriteLine(" - Focuses on usability, accessibility, and user experience");
                        Console.WriteLine("Professor: Ms. Teresa Morales");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> INFORMATION MANAGEMENT");
                        Console.WriteLine(" - Introduces database systems and information organization");
                        Console.WriteLine(" - Covers SQL, data modeling, and information security");
                        Console.WriteLine("Professor: Mr. Gabriel Santos");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> PATHFIT 4");
                        Console.WriteLine(" - Enhances physical fitness through advanced sports activitie, VOLLEYBALL");
                        Console.WriteLine(" - Focuses on teamwork, endurance, and performance");
                        Console.WriteLine("Professor: Ms. Monica Reyes");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> DATA COMMUNICATIONS & NETWORKING");
                        Console.WriteLine(" - Introduces network models, protocols, and data transmission");
                        Console.WriteLine(" - Focuses on LAN, WAN, and internet technologies");
                        Console.WriteLine("Professor: Mr. Albert Mendoza");
                        Console.WriteLine("======================================================");

                    }

                    else if (student.Section == "3-1")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("-------< DIT 3-1 | ‘1st Sem’ SUBJECT DESCRIPTION >-------");

                        Console.WriteLine(" ");
                        Console.WriteLine("> FUNDAMENTALS OF RESEARCH");
                        Console.WriteLine(" - Introduces research methods and academic writing");
                        Console.WriteLine(" - Focuses on problem formulation, data collection, and analysis");
                        Console.WriteLine("Professor: Ms. Janine Morales");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> CAPSTONE PROJECT 1");
                        Console.WriteLine(" - Prepares students for research-based IT projects");
                        Console.WriteLine(" - Focuses on proposal writing and project planning");
                        Console.WriteLine("Professor: Mr. Paolo Santiago");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> NETWORK ADMINISTRATION");
                        Console.WriteLine(" - Covers configuration and management of computer networks");
                        Console.WriteLine(" - Includes security, troubleshooting, and server administration");
                        Console.WriteLine("Professor: Mr. Dennis Ramirez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> INFORMATION ASSURANCE & SECURITY 1");
                        Console.WriteLine(" - Introduces cybersecurity principles and risk management");
                        Console.WriteLine(" - Covers encryption, authentication, and network defense");
                        Console.WriteLine("Professor: Ms. Carla Gutierrez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> MULTIMEDIA");
                        Console.WriteLine(" - Covers digital media creation and editing tools");
                        Console.WriteLine(" - Includes graphics, audio, video, and animation techniques");
                        Console.WriteLine("Professor: Mr. Leo Fernandez");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine(" ");

                        Console.WriteLine("-------< DIT 3-1 | ‘2nd Sem’ SUBJECT DESCRIPTION >-------");

                        Console.WriteLine(" ");
                        Console.WriteLine("> SYSTEM INTEGRATION & ARCHITECTURE 1");
                        Console.WriteLine(" - Introduces system design and integration concepts");
                        Console.WriteLine(" - Focuses on architecture frameworks and IT solutions");
                        Console.WriteLine("Professor: Ms. Andrea Cruz");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> APPLICATIONS DEVELOPMENT & EMERGING TECHNOLOGY");
                        Console.WriteLine(" - Focuses on mobile and cloud-based applications");
                        Console.WriteLine(" - Explores emerging IT trends and innovations");
                        Console.WriteLine("Professor: Mr. Rafael Mendoza");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> CAPSTONE PROJECT 2");
                        Console.WriteLine(" - Continuation of Capstone Project 1 with implementation phase");
                        Console.WriteLine(" - Students develop, test, and present their IT solutions");
                        Console.WriteLine("Professor: Ms. Sofia Navarro");
                        Console.WriteLine("======================================================");

                        Console.WriteLine(" ");
                        Console.WriteLine("> TECHNOPRENEURSHIP");
                        Console.WriteLine(" - Introduces entrepreneurship concepts in the IT field");
                        Console.WriteLine(" - Focuses on innovation, business planning, and startup development");
                        Console.WriteLine("Professor: Mr. Miguel Torres");
                        Console.WriteLine("======================================================");

                    }
                    break;

                default:
                    Console.WriteLine("Invalid program or section. Please check your input and try again.");
                    break;

            }
        }

    }
}