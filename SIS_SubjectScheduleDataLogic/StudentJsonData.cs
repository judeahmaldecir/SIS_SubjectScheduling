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
    }
}