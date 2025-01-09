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
    public class TeacherRepository
    {
        private readonly string _connectionString;

        public TeacherRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetAllTeachers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teachers.Add(new Teacher
                            {
                                TeacherID = Convert.ToInt32(reader["TeacherID"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Subject = reader["Subject"].ToString()
                            });
                        }
                    }
                }
            }
            return teachers;
        }

        public Teacher GetTeacherById(int teacherId)
        {
            Teacher teacher = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetTeacherById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            teacher = new Teacher
                            {
                                TeacherID = Convert.ToInt32(reader["TeacherID"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Subject = reader["Subject"].ToString()
                            };
                        }
                    }
                }
            }
            return teacher;
        }

        public void InsertTeacher(Teacher teacher)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("InsertTeacher", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", teacher.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", teacher.LastName);
                    cmd.Parameters.AddWithValue("@Subject", teacher.Subject);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTeacher(Teacher teacher)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UpdateTeacher", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeacherID", teacher.TeacherID);
                    cmd.Parameters.AddWithValue("@FirstName", teacher.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", teacher.LastName);
                    cmd.Parameters.AddWithValue("@Subject", teacher.Subject);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTeacher(int teacherId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DeleteTeacher", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}