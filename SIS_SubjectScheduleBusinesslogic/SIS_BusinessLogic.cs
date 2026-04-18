using SIS_SubjectScheduleDataLogic;
using SIS_SubjectScheduleModels;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Transactions;
using System.Xml.Linq;

namespace SIS_SubjectScheduleBusinesslogic
{
    public class SIS_BusinessLogic
    {
        private static StudentDBData dbData = new StudentDBData();
        private static StudentJsonData data = new StudentJsonData();

        // ------------------------------------------- Log-insssssss!!! 
        public static bool Login(string studentNumber, string studentPassword)
        {
            var student = dbData.GetByStudentNumber(studentNumber); 
            if (student == null)
            {
                student = data.GetByNumber(studentNumber); 
            }

            return student != null && student.StudentPassword == studentPassword;
        }

        public static bool Register(string studentNumber, string studentPassword) // ------------------------------------------- Registerrrrrrr!!! 
        {
            var student = data.GetByNumber(studentNumber);
            var dbStudent = dbData.GetByStudentNumber(studentNumber);

            if (student != null || dbStudent != null)
            {
                return false; 
            }

            var newStudent = new Student
            {
                StudentNumber = studentNumber.ToUpper(),
                StudentPassword = studentPassword,
                Program = null,
                Section = null
            };

        
            data.Add(newStudent);
            var allStudents = data.GetStudents();
            data.SaveAll(allStudents);

            dbData.Add(newStudent);

            return true; 
        }

        public static Student? LoginAndGetStudent(string studentNumber, string studentPassword)
        {
            var student = dbData.GetByStudentNumber(studentNumber);

            if (student == null)
            {
                student = data.GetByNumber(studentNumber);
            }

            if (student != null && (string.IsNullOrEmpty(studentPassword) || student.StudentPassword == studentPassword))
            {
                return student;
            }

            return null;
        }

        // ------------------------------------------- validations!!!

        public static Student? GetStudentByNumber(string studentNumber)
        {

            var student = dbData.GetByStudentNumber(studentNumber);

            if (student == null)
            {
                student = data.GetByNumber(studentNumber);
            }

            return student;
        }

        public static bool IsValidProgram(string program)
        {
            var validPrograms = new List<string> { "BSIT", "DIT"};
            return validPrograms.Contains(program);
        }

        public static bool IsValidSection(string section)
        {
            var validSections = new List<string> { "1-1", "2-1", "3-1", "4-1" };
            return validSections.Contains(section);
        }


        // ------------------------------------------- Updating/Changes!!!
        public static void UpdateProgramAndSection(Student student)
        {
            dbData.UpdateProgramAndSection(student.StudentNumber, student.Program, student.Section);
        }

        public static void UpdatePassword(Student student)
        {
            dbData.UpdatePassword(student);
        }

        // ------------------------------------------- Deleting Program and Section!!!
        public static void DeleteProgramandSection(Student student)
        {
            dbData.DeleteProgramSection(student);
        }

        // ------------------------------------------- Retrieving Program and Section!!!
        public static Student? RetrieveProgramandSection(string studentNumber)
        {
            var student = new Student { StudentNumber = studentNumber };
            return dbData.RetrievePastProgramSection(student);
        }

        // ------------------------------------------- Showing Schedules T.T !!!

        public static void ShowSchedule(Student student)
        {
            data.ShowSchedule(student);
            }

        // ------------------------------------------- Showing Subject Description T.T !!!
        public static void ShowSubjectDescription(Student student)
        {
            data.ShowSubjectDescription(student);
        }


    }
}//last
        