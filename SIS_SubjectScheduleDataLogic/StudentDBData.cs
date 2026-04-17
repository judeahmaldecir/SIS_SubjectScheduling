using Microsoft.Data.SqlClient;
using SIS_SubjectScheduleModels;
// using Newtonsoft.Json;
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
        private static StudentDBData dbData = new StudentDBData();

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
            var selectStatement = "SELECT StudentNumber, StudentPassword, Program, Section " +
                          "FROM Students WHERE StudentNumber = @StudentNumber";
            using (SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection))
            {
                selectCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);

                sqlConnection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();

                Student? student = null;
                if (reader.Read())
                {
                    student = new Student
                    {
                        StudentNumber = reader["StudentNumber"].ToString(),
                        StudentPassword = reader["StudentPassword"].ToString(),
                        Program = reader["Program"] == DBNull.Value ? null : reader["Program"].ToString(),
                        Section = reader["Section"] == DBNull.Value ? null : reader["Section"].ToString()
                    };
                }

                sqlConnection.Close();
                return student;
            }
        }

        // ------------------------------------------- Updating/Changes!!!
        public void UpdateProgramAndSection(string studentNumber, string program, string section)
        {
            var updateStatement = @"
            UPDATE Students
            SET PastProgram = CASE 
                                 WHEN Program = @Program AND Section = @Section THEN NULL 
                                 ELSE Program 
                              END,
                PastSection = CASE 
                                 WHEN Program = @Program AND Section = @Section THEN NULL 
                                 ELSE Section 
                              END,
                Program = @Program,
                Section = @Section
            WHERE StudentNumber = @StudentNumber";

            using (SqlConnection conn = new SqlConnection(sqlConnection.ConnectionString))
            using (SqlCommand updateCommand = new SqlCommand(updateStatement, conn))
            {
                updateCommand.Parameters.AddWithValue("@Program", program ?? (object)DBNull.Value);
                updateCommand.Parameters.AddWithValue("@Section", section ?? (object)DBNull.Value);
                updateCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);

                conn.Open();
                updateCommand.ExecuteNonQuery();
            }
        }

        public void UpdatePassword(Student student)
        {
            var updateStatement = "UPDATE students " +
                "SET StudentPassword = @StudentPassword " +
                "WHERE StudentNumber = @StudentNumber";

            using (SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection))
            {
                updateCommand.Parameters.AddWithValue("@StudentPassword", student.StudentPassword);
                updateCommand.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);

                sqlConnection.Open();
                updateCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }


        }

        // ------------------------------------------- Retriving!!!
        public Student? RetrievePastProgramSection(Student student)
        {
            var selectStatement = "SELECT PastProgram, PastSection FROM Students WHERE StudentNumber = @StudentNumber";

            using (SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection))
            {
                selectCommand.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);

                sqlConnection.Open();
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Student
                        {
                            StudentNumber = student.StudentNumber,
                            PastProgram = reader["PastProgram"]?.ToString(),
                            PastSection = reader["PastSection"]?.ToString()
                        };
                    }
                }
                sqlConnection.Close();
            }
            return null;
        }

        // ------------------------------------------- Deleting!!!
        public void DeleteProgramSection(Student student)
        {
            var deleteStatement = "" +
                "UPDATE students SET Program = NULL, " +
                "Section = NULL WHERE StudentNumber = @StudentNumber";

            using (SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection))
            {
                deleteCommand.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);

                sqlConnection.Open();
                deleteCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

    }
}
