using School_ADO.Models.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace School_ADO.Models.Repositories
{
    public class ClassRepository
    {
        private readonly string _connectionString;

        public ClassRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<Class> GetAllClasses()
        {
            List<Class> classes = new List<Class>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetAllClasses", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            classes.Add(new Class
                            {
                                ClassID = Convert.ToInt32(reader["ClassID"]),
                                ClassName = reader["ClassName"].ToString(),
                                TeacherID = Convert.ToInt32(reader["TeacherID"]),
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                TeacherName = $"{reader["TeacherFirstName"]} {reader["TeacherLastName"]}",
                                StudentName = $"{reader["StudentFirstName"]} {reader["StudentLastName"]}"
                            });
                        }
                    }
                }
            }
            return classes;
        }

        public Class GetClassById(int classId)
        {
            Class classItem = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetClassById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            classItem = new Class
                            {
                                ClassID = Convert.ToInt32(reader["ClassID"]),
                                ClassName = reader["ClassName"].ToString(),
                                TeacherID = Convert.ToInt32(reader["TeacherID"]),
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                TeacherName = $"{reader["TeacherFirstName"]} {reader["TeacherLastName"]}",
                                StudentName = $"{reader["StudentFirstName"]} {reader["StudentLastName"]}"
                            };
                        }
                    }
                }
            }
            return classItem;
        }

        public void InsertClass(Class classItem)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("InsertClass", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClassName", classItem.ClassName);
                    cmd.Parameters.AddWithValue("@TeacherID", classItem.TeacherID);
                    cmd.Parameters.AddWithValue("@StudentID", classItem.StudentID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateClass(Class classItem)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UpdateClass", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClassID", classItem.ClassID);
                    cmd.Parameters.AddWithValue("@ClassName", classItem.ClassName);
                    cmd.Parameters.AddWithValue("@TeacherID", classItem.TeacherID);
                    cmd.Parameters.AddWithValue("@StudentID", classItem.StudentID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteClass(int classId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DeleteClass", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}