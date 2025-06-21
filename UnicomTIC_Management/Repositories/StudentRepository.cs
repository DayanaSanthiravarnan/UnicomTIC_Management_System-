using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Repositories.Interfaces;

namespace UnicomTIC_Management.Repositories
{
    internal class StudentRepository : IStudentRepository
    {
        public int CreateStudent(Student student)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO Students (UserID, Name, NIC, Email, ContactNo, Gender, Address, DateOfBirth, EnrollmentDate, CourseID)
                    VALUES (@UserID, @Name, @NIC, @Email, @ContactNo, @Gender, @Address, @DateOfBirth, @EnrollmentDate, @CourseID);
                    SELECT last_insert_rowid();";

                cmd.Parameters.AddWithValue("@UserID", student.UserID);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@NIC", student.NIC);
                cmd.Parameters.AddWithValue("@Email", student.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ContactNo", student.ContactNo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", student.Gender ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", student.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);
                cmd.Parameters.AddWithValue("@CourseID", student.CourseID);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE Students
                    SET Name = @Name, NIC = @NIC, Email = @Email, ContactNo = @ContactNo, Gender = @Gender, Address = @Address, DateOfBirth = @DateOfBirth, EnrollmentDate = @EnrollmentDate, CourseID = @CourseID
                    WHERE StudentID = @StudentID";

                cmd.Parameters.AddWithValue("@StudentID", student.StudentID);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@NIC", student.NIC);
                cmd.Parameters.AddWithValue("@Email", student.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ContactNo", student.ContactNo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", student.Gender ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", student.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);
                cmd.Parameters.AddWithValue("@CourseID", student.CourseID);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int studentId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Students WHERE StudentID = @StudentID";
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                cmd.ExecuteNonQuery();
            }
        }

        public Student GetStudentById(int studentId)
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
                            UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            NIC = reader.GetString(reader.GetOrdinal("NIC")),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                            ContactNo = reader.IsDBNull(reader.GetOrdinal("ContactNo")) ? null : reader.GetString(reader.GetOrdinal("ContactNo")),
                            Gender = reader.IsDBNull(reader.GetOrdinal("Gender")) ? null : reader.GetString(reader.GetOrdinal("Gender")),
                            Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                            DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                            EnrollmentDate = reader.GetDateTime(reader.GetOrdinal("EnrollmentDate")),
                            CourseID = reader.GetInt32(reader.GetOrdinal("CourseID"))
                        };
                    }
                }
            }
            return null;
        }

        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();
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
                            UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            NIC = reader.GetString(reader.GetOrdinal("NIC")),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                            ContactNo = reader.IsDBNull(reader.GetOrdinal("ContactNo")) ? null : reader.GetString(reader.GetOrdinal("ContactNo")),
                            Gender = reader.IsDBNull(reader.GetOrdinal("Gender")) ? null : reader.GetString(reader.GetOrdinal("Gender")),
                            Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                            DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                            EnrollmentDate = reader.GetDateTime(reader.GetOrdinal("EnrollmentDate")),
                            CourseID = reader.GetInt32(reader.GetOrdinal("CourseID"))
                        });
                    }
                }
            }
            return students;
        }
    }
}
