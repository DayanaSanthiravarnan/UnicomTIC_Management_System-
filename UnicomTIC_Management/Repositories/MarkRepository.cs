using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Repositories.Interfaces;

namespace UnicomTIC_Management.Repositories
{
    internal class MarksRepository : IMarksRepository
    {
        public void AddMark(Marks mark)
        {
            if (mark == null)
                throw new ArgumentNullException(nameof(mark));

            using (var conn = Dbconfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Marks (StudentID, SubjectID, ExamID, MarksObtained, Grade)
                    VALUES (@StudentID, @SubjectID, @ExamID, @MarksObtained, @Grade)";
                cmd.Parameters.AddWithValue("@StudentID", mark.StudentID);
                cmd.Parameters.AddWithValue("@SubjectID", mark.SubjectID);
                cmd.Parameters.AddWithValue("@ExamID", mark.ExamID);
                cmd.Parameters.AddWithValue("@MarksObtained", mark.MarksObtained);
                cmd.Parameters.AddWithValue("@Grade", mark.Grade);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateMark(Marks mark)
        {
            if (mark == null)
                throw new ArgumentNullException(nameof(mark));

            using (var conn = Dbconfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE Marks
                    SET StudentID = @StudentID,
                        SubjectID = @SubjectID,
                        ExamID = @ExamID,
                        MarksObtained = @MarksObtained,
                        Grade = @Grade
                    WHERE MarkID = @MarkID";
                cmd.Parameters.AddWithValue("@MarkID", mark.MarkID);
                cmd.Parameters.AddWithValue("@StudentID", mark.StudentID);
                cmd.Parameters.AddWithValue("@SubjectID", mark.SubjectID);
                cmd.Parameters.AddWithValue("@ExamID", mark.ExamID);
                cmd.Parameters.AddWithValue("@MarksObtained", mark.MarksObtained);
                cmd.Parameters.AddWithValue("@Grade", mark.Grade);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteMark(int markId)
        {
            using (var conn = Dbconfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Marks WHERE MarkID = @MarkID";
                cmd.Parameters.AddWithValue("@MarkID", markId);
                cmd.ExecuteNonQuery();
            }
        }

        public Marks GetMarkById(int markId)
        {
            using (var conn = Dbconfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT m.MarkID, m.StudentID, s.Name, 
                           m.SubjectID, subj.SubjectName,
                           m.ExamID, e.ExamName,
                           m.MarksObtained, m.Grade
                    FROM Marks m
                    LEFT JOIN Students s ON m.StudentID = s.StudentID
                    LEFT JOIN Subjects subj ON m.SubjectID = subj.SubjectID
                    LEFT JOIN Exams e ON m.ExamID = e.ExamID
                    WHERE m.MarkID = @MarkID";
                cmd.Parameters.AddWithValue("@MarkID", markId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Marks
                        {
                            MarkID = reader.GetInt32(0),
                            StudentID = reader.GetInt32(1),
                            StudentName = reader.IsDBNull(2) ? null : reader.GetString(2),
                            SubjectID = reader.GetInt32(3),
                            SubjectName = reader.IsDBNull(4) ? null : reader.GetString(4),
                            ExamID = reader.GetInt32(5),
                            ExamName = reader.IsDBNull(6) ? null : reader.GetString(6),
                            MarksObtained = reader.GetInt32(7),
                            Grade = reader.IsDBNull(8) ? null : reader.GetString(8)
                        };
                    }
                }
            }
            return null;
        }

        public List<Marks> GetAllMarks()
        {
            var marksList = new List<Marks>();
            using (var conn = Dbconfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT m.MarkID, m.StudentID, s.Name, 
                           m.SubjectID, subj.SubjectName,
                           m.ExamID, e.ExamName,
                           m.MarksObtained, m.Grade
                    FROM Marks m
                    LEFT JOIN Students s ON m.StudentID = s.StudentID
                    LEFT JOIN Subjects subj ON m.SubjectID = subj.SubjectID
                    LEFT JOIN Exams e ON m.ExamID = e.ExamID";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        marksList.Add(new Marks
                        {
                            MarkID = reader.GetInt32(0),
                            StudentID = reader.GetInt32(1),
                            StudentName = reader.IsDBNull(2) ? null : reader.GetString(2),
                            SubjectID = reader.GetInt32(3),
                            SubjectName = reader.IsDBNull(4) ? null : reader.GetString(4),
                            ExamID = reader.GetInt32(5),
                            ExamName = reader.IsDBNull(6) ? null : reader.GetString(6),
                            MarksObtained = reader.GetInt32(7),
                            Grade = reader.IsDBNull(8) ? null : reader.GetString(8)
                        });
                    }
                }
            }
            return marksList;
        }
    }
}
