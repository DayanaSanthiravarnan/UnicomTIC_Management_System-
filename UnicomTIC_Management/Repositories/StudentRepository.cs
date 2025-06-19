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
    internal class StudentRepository : IStudentRepository
    {
        public void AddStudent(Student student)
        {
            try
            {
                if (student == null)
                    throw new ArgumentNullException(nameof(student));

                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        INSERT INTO Students (Name, NIC, Address, ContactNo, Email, DateOfBirth, Gender, EnrollmentDate, CourseID, UserID, MainGroupID, SubGroupID, CreatedAt, UpdatedAt)
                        VALUES (@Name, @NIC, @Address, @ContactNo, @Email, @DateOfBirth, @Gender, @EnrollmentDate, @CourseID, @UserID, @MainGroupID, @SubGroupID, @CreatedAt, @UpdatedAt)";

                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@NIC", student.NIC);
                    cmd.Parameters.AddWithValue("@Address", student.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ContactNo", student.ContactNo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", student.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", student.Gender ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);
                    cmd.Parameters.AddWithValue("@CourseID", student.CourseID);
                    cmd.Parameters.AddWithValue("@UserID", student.UserID);
                    cmd.Parameters.AddWithValue("@MainGroupID", student.MainGroupID);
                    cmd.Parameters.AddWithValue("@SubGroupID", student.SubGroupID);
                    cmd.Parameters.AddWithValue("@CreatedAt", student.CreatedAt);
                    cmd.Parameters.AddWithValue("@UpdatedAt", student.UpdatedAt);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while adding student: " + ex.Message, ex);
            }
        }

        public void UpdateStudent(Student student)
        {
            try
            {
                if (student == null)
                    throw new ArgumentNullException(nameof(student));

                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        UPDATE Students 
                        SET Name = @Name, NIC = @NIC, Address = @Address, ContactNo = @ContactNo, Email = @Email, 
                            DateOfBirth = @DateOfBirth, Gender = @Gender, EnrollmentDate = @EnrollmentDate, 
                            CourseID = @CourseID, UserID = @UserID, MainGroupID = @MainGroupID, SubGroupID = @SubGroupID, UpdatedAt = @UpdatedAt
                        WHERE StudentID = @StudentID";

                    cmd.Parameters.AddWithValue("@StudentID", student.StudentID);
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@NIC", student.NIC);
                    cmd.Parameters.AddWithValue("@Address", student.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ContactNo", student.ContactNo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", student.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", student.Gender ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);
                    cmd.Parameters.AddWithValue("@CourseID", student.CourseID);
                    cmd.Parameters.AddWithValue("@UserID", student.UserID);
                    cmd.Parameters.AddWithValue("@MainGroupID", student.MainGroupID);
                    cmd.Parameters.AddWithValue("@SubGroupID", student.SubGroupID);
                    cmd.Parameters.AddWithValue("@UpdatedAt", student.UpdatedAt);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while updating student: " + ex.Message, ex);
            }
        }

        public void DeleteStudent(int studentId)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Students WHERE StudentID = @StudentID";
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while deleting student: " + ex.Message, ex);
            }
        }

        public Student GetStudentById(int studentId)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Students WHERE StudentID = @StudentID";
                    cmd.Parameters.AddWithValue("@StudentID", studentId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Student
                            {
                                StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                NIC = reader.GetString(reader.GetOrdinal("NIC")),
                                Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                                ContactNo = reader.IsDBNull(reader.GetOrdinal("ContactNo")) ? null : reader.GetString(reader.GetOrdinal("ContactNo")),
                                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                Gender = reader.IsDBNull(reader.GetOrdinal("Gender")) ? null : reader.GetString(reader.GetOrdinal("Gender")),
                                EnrollmentDate = reader.GetDateTime(reader.GetOrdinal("EnrollmentDate")),
                                CourseID = reader.GetInt32(reader.GetOrdinal("CourseID")),
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                MainGroupID = reader.GetInt32(reader.GetOrdinal("MainGroupID")),
                                SubGroupID = reader.GetInt32(reader.GetOrdinal("SubGroupID")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                                UpdatedAt = reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
                            };
                        }
                        return null;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while retrieving student: " + ex.Message, ex);
            }
        }

        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Students";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                NIC = reader.GetString(reader.GetOrdinal("NIC")),
                                Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                                ContactNo = reader.IsDBNull(reader.GetOrdinal("ContactNo")) ? null : reader.GetString(reader.GetOrdinal("ContactNo")),
                                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                Gender = reader.IsDBNull(reader.GetOrdinal("Gender")) ? null : reader.GetString(reader.GetOrdinal("Gender")),
                                EnrollmentDate = reader.GetDateTime(reader.GetOrdinal("EnrollmentDate")),
                                CourseID = reader.GetInt32(reader.GetOrdinal("CourseID")),
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                MainGroupID = reader.GetInt32(reader.GetOrdinal("MainGroupID")),
                                SubGroupID = reader.GetInt32(reader.GetOrdinal("SubGroupID")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                                UpdatedAt = reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
                            });
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while retrieving students: " + ex.Message, ex);
            }
            return students;
        }
    }
}
