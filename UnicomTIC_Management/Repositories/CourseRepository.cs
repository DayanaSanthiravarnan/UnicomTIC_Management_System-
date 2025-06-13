using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Repositories.Interfaces;

namespace UnicomTIC_Management.Repositories
{
    internal class CourseRepository : ICourseRepository
    {
        public void AddCourse(Course course)
        {
            try
            {
                if (course == null)
                    throw new ArgumentNullException(nameof(course));

                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        INSERT INTO Courses (CourseName, Description)
                        VALUES (@CourseName, @Description)";
                    cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                    cmd.Parameters.AddWithValue("@Description", course.CourseDescription ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while adding course: " + ex.Message, ex);
            }
        }

        public void UpdateCourse(Course course)
        {
            try
            {
                if (course == null)
                    throw new ArgumentNullException(nameof(course));

                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        UPDATE Courses 
                        SET CourseName = @CourseName, Description = @Description
                        WHERE CourseID = @CourseID";
                    cmd.Parameters.AddWithValue("@CourseID", course.CourseID);
                    cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                    cmd.Parameters.AddWithValue("@Description", course.CourseDescription ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while updating course: " + ex.Message, ex);
            }
        }

        public void DeleteCourse(int courseId)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Courses WHERE CourseID = @CourseID";
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while deleting course: " + ex.Message, ex);
            }
        }

        public Course GetCourseById(int courseId)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT CourseID, CourseName, Description FROM Courses WHERE CourseID = @CourseID";
                    cmd.Parameters.AddWithValue("@CourseID", courseId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Course
                            {
                                CourseID = reader.GetInt32(0),
                                CourseName = reader.GetString(1),
                                CourseDescription = reader.IsDBNull(2) ? null : reader.GetString(2)
                            };
                        }
                        return null;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while retrieving course: " + ex.Message, ex);
            }
        }

        public List<Course> GetAllCourses()
        {
            var courses = new List<Course>();
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT CourseID, CourseName, Description FROM Courses";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            courses.Add(new Course
                            {
                                CourseID = reader.GetInt32(0),
                                CourseName = reader.GetString(1),
                                CourseDescription = reader.IsDBNull(2) ? null : reader.GetString(2)
                            });
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while retrieving courses: " + ex.Message, ex);
            }
            return courses;
        }
    }
}
