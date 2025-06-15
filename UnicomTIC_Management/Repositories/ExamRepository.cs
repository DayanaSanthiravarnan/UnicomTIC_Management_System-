using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Repositories.Interfaces;

namespace UnicomTIC_Management.Repositories
{
    internal class ExamRepository : IExamRepository
    {
        public void AddExam(Exam exam)
        {
            try
            {
                if (exam == null)
                    throw new ArgumentNullException(nameof(exam));

                using (var conn = Dbconfig.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Exams (ExamName, SubjectID, ExamDate, ExamType, MaxMarks)
                        VALUES (@ExamName, @SubjectID, @ExamDate, @ExamType, @MaxMarks)";
                    cmd.Parameters.AddWithValue("@ExamName", exam.ExamsName);
                    cmd.Parameters.AddWithValue("@SubjectID", exam.SubjectID);
                    cmd.Parameters.AddWithValue("@ExamDate", exam.ExamDate);
                    cmd.Parameters.AddWithValue("@ExamType", exam.ExamType);
                    cmd.Parameters.AddWithValue("@MaxMarks", exam.MaxMarks);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while adding exam: " + ex.Message, ex);
            }
        }

        public void UpdateExam(Exam exam)
        {
            try
            {
                if (exam == null)
                    throw new ArgumentNullException(nameof(exam));

                using (var conn = Dbconfig.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Exams
                        SET ExamName = @ExamName, SubjectID = @SubjectID, ExamDate = @ExamDate, ExamType = @ExamType, MaxMarks = @MaxMarks
                        WHERE ExamID = @ExamID";
                    cmd.Parameters.AddWithValue("@ExamID", exam.ExamsID);
                    cmd.Parameters.AddWithValue("@ExamName", exam.ExamsName);
                    cmd.Parameters.AddWithValue("@SubjectID", exam.SubjectID);
                    cmd.Parameters.AddWithValue("@ExamDate", exam.ExamDate);
                    cmd.Parameters.AddWithValue("@ExamType", exam.ExamType);
                    cmd.Parameters.AddWithValue("@MaxMarks", exam.MaxMarks);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while updating exam: " + ex.Message, ex);
            }
        }

        public void DeleteExam(int examId)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Exams WHERE ExamID = @ExamID";
                    cmd.Parameters.AddWithValue("@ExamID", examId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while deleting exam: " + ex.Message, ex);
            }
        }

        public Exam GetExamById(int examId)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT e.ExamID, e.ExamName, e.SubjectID, s.SubjectName, e.ExamDate, e.ExamType, e.MaxMarks
                        FROM Exams e
                        LEFT JOIN Subjects s ON e.SubjectID = s.SubjectID
                        WHERE e.ExamID = @ExamID";
                    cmd.Parameters.AddWithValue("@ExamID", examId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Exam
                            {
                                ExamsID = reader.GetInt32(0),
                                ExamsName = reader.GetString(1),
                                SubjectID = reader.GetInt32(2),
                                SubjectName = reader.IsDBNull(3) ? null : reader.GetString(3),
                                ExamDate = reader.GetString(4),
                                ExamType = reader.GetString(5),
                                MaxMarks = reader.GetInt32(6)
                            };
                        }
                    }
                    return null;
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while retrieving exam: " + ex.Message, ex);
            }
        }

        public List<Exam> GetAllExams()
        {
            var exams = new List<Exam>();
            try
            {
                using (var conn = Dbconfig.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT e.ExamID, e.ExamName, e.SubjectID, s.SubjectName, e.ExamDate, e.ExamType, e.MaxMarks
                        FROM Exams e
                        LEFT JOIN Subjects s ON e.SubjectID = s.SubjectID";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exams.Add(new Exam
                            {
                                ExamsID = reader.GetInt32(0),
                                ExamsName = reader.GetString(1),
                                SubjectID = reader.GetInt32(2),
                                SubjectName = reader.IsDBNull(3) ? null : reader.GetString(3),
                                ExamDate = reader.GetString(4),
                                ExamType = reader.GetString(5),
                                MaxMarks = reader.GetInt32(6)
                            });
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while retrieving exams: " + ex.Message, ex);
            }
            return exams;
        }
    }
}
