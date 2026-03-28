using Microsoft.Data.SqlClient;
using SIS_SubjectScheduleModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SIS_SubjectScheduleDataLogic
{
    public class StudentDBData
    {
        private string connectionString =
            "Data Source=localhost\\SQLEXPRESS; Initial Catalog=SIS_SubjectScheduling; Integrated Security=True; TrustServerCertificate=True";

        private SqlConnection sqlConnection;

        public StudentDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
            AddSeeds();
        }
        
        public void AddSeeds()
        {
            var existing = GetStudents();

            if (existing.Count == 0)
            {
                Student student1 = new Student { StudentNumber = "2024-00021-BN-0", StudentPassword = "leehan21" };
                Student student2 = new Student { StudentNumber = "2025-00014-BN-0", StudentPassword = "judeah" };

                Add(student1);  
                Add(student2);

            }
        }


        public void Add(Student student)
        {
            var insertStatement = "INSERT INTO Students (StudentNumber, StudentPassword) VALUES (@StudentNumber, @StudentPassword)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
            insertCommand.Parameters.AddWithValue("@StudentPassword", student.StudentPassword);

            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Student> GetStudents()
        {
            var students = new List<Student>();
            var selectStatement = "SELECT StudentNumber, StudentPassword FROM Students";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Student student = new Student
                {
                    StudentNumber = reader["StudentNumber"].ToString(),
                    StudentPassword = reader["StudentPassword"].ToString()
                };

                students.Add(student);
            }

            sqlConnection.Close();
            return students;
        }

        public Student? GetByStudentNumber(string studentNumber)
        {
            var selectStatement = "SELECT StudentNumber, StudentPassword FROM Students WHERE StudentNumber = @StudentNumber";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            Student? student = null;
            if (reader.Read())
            {
                student = new Student
                {
                    StudentNumber = reader["StudentNumber"].ToString(),
                    StudentPassword = reader["StudentPassword"].ToString()
                };
            }

            sqlConnection.Close();
            return student;
        }
            //-----------------------------------------------------------------

        public void Update(Student student)
        {
            var updateStatement = "UPDATE Students SET StudentPassword = @StudentPassword WHERE StudentNumber = @StudentNumber";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@StudentPassword", student.StudentPassword);
            updateCommand.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);

            sqlConnection.Open();
            updateCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void Delete(string studentNumber)
        {
            var deleteStatement = "DELETE FROM Students WHERE StudentNumber = @StudentNumber";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

            deleteCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);

            sqlConnection.Open();
            deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public bool StudentExists(string studentNumber)
        {
            var selectStatement = "SELECT StudentNumber FROM Students WHERE StudentNumber = @StudentNumber";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            bool exists = reader.Read();

            sqlConnection.Close();
            return exists;
        }

    }

}
