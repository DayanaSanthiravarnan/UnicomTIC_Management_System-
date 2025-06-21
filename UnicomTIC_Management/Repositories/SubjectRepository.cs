using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;

namespace UnicomTIC_Management.Repositories
{
    internal class SubjectRepository : ISubjectRepository
    {
        public void AddSubject(Subject subject)
        {
            try
            {
                if (subject == null)
                    throw new ArgumentNullException(nameof(subject));
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        INSERT INTO Subjects (SubjectName, CourseID)
                        VALUES (@SubjectName, @CourseID)";
                    cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                    cmd.Parameters.AddWithValue("@CourseID", subject.CourseID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while adding subject: " + ex.Message, ex);
            }
        }

        public void UpdateSubject(Subject subject)
        {
            try
            {
                if (subject == null)
                    throw new ArgumentNullException(nameof(subject));
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        UPDATE Subjects
                        SET SubjectName = @SubjectName, CourseID = @CourseID
                        WHERE SubjectID = @SubjectID";
                    cmd.Parameters.AddWithValue("@SubjectID", subject.SubjectID);
                    cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                    cmd.Parameters.AddWithValue("@CourseID", subject.CourseID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while updating subject: " + ex.Message, ex);
            }
        }

        public void DeleteSubject(int subjectId)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Subjects WHERE SubjectID = @SubjectID";
                    cmd.Parameters.AddWithValue("@SubjectID", subjectId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while deleting subject: " + ex.Message, ex);
            }
        }

        public Subject GetSubjectById(int subjectId)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        SELECT s.SubjectID, s.SubjectName, s.CourseID, c.CourseName
                        FROM Subjects s
                        JOIN Courses c ON s.CourseID = c.CourseID
                        WHERE s.SubjectID = @SubjectID";
                    cmd.Parameters.AddWithValue("@SubjectID", subjectId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Subject
                            {
                                SubjectID = reader.GetInt32(0),
                                SubjectName = reader.GetString(1),
                                CourseID = reader.GetInt32(2),
                                CourseName = reader.GetString(3)
                            };
                        }
                        return null;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while retrieving subject: " + ex.Message, ex);
            }
        }

        public List<Subject> GetAllSubjects()
        {
            var subjects = new List<Subject>();
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        SELECT s.SubjectID, s.SubjectName, s.CourseID, c.CourseName
                        FROM Subjects s
                        LEFT JOIN Courses c ON s.CourseID = c.CourseID";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(new Subject
                            {
                                SubjectID = reader.GetInt32(0),
                                SubjectName = reader.GetString(1),
                                CourseID = reader.GetInt32(2),
                                CourseName = reader.GetString(3)
                            });
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while retrieving subjects: " + ex.Message, ex);
            }
            return subjects;
        }
        public List<Subject> GetSubjectsByCourseId(int courseId)
        {
            var subjects = new List<Subject>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
            SELECT s.SubjectID, s.SubjectName, s.CourseID, c.CourseName
            FROM Subjects s
            LEFT JOIN Courses c ON s.CourseID = c.CourseID
            WHERE s.CourseID = @CourseID";
                cmd.Parameters.AddWithValue("@CourseID", courseId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjects.Add(new Subject
                        {
                            SubjectID = reader.GetInt32(0),
                            SubjectName = reader.GetString(1),
                            CourseID = reader.GetInt32(2),
                            CourseName = reader.GetString(3)
                        });
                    }
                }
            }
            return subjects;
        }
        public int CreateSubject(Subject subject)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Subjects (CourseID, SubjectName) 
                            VALUES (@CourseID, @SubjectName);
                            SELECT last_insert_rowid();";
                cmd.Parameters.AddWithValue("@CourseID", subject.CourseID);
                
                cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
