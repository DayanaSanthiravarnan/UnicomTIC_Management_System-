using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Repositories.Interfaces;

namespace UnicomTIC_Management.Repositories
{
    internal class TopPerformerRepository : ITopPerformerRepository
    {
        public void AddTopPerformer(TopPerformer tp)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                INSERT INTO TopPerformers (StudentID, ExamID, MarksObtained, Grade, RecordedDate)
                VALUES (@StudentID, @ExamID, @MarksObtained, @Grade, @RecordedDate)";
                cmd.Parameters.AddWithValue("@StudentID", tp.StudentID);
                cmd.Parameters.AddWithValue("@ExamID", tp.ExamID);
                cmd.Parameters.AddWithValue("@MarksObtained", tp.MarksObtained);
                cmd.Parameters.AddWithValue("@Grade", tp.Grade);
                cmd.Parameters.AddWithValue("@RecordedDate", tp.RecordedDate);
                cmd.ExecuteNonQuery();
            }
        }

        public List<TopPerformer> GetTopPerformersByExam(int examId)
        {
            var list = new List<TopPerformer>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                SELECT tp.TopPerformerID, tp.StudentID, s.Name, 
                       tp.ExamID, e.ExamName, tp.MarksObtained, tp.Grade, tp.RecordedDate
                FROM TopPerformers tp
                JOIN Students s ON tp.StudentID = s.StudentID
                JOIN Exams e ON tp.ExamID = e.ExamID
                WHERE tp.ExamID = @ExamID
                ORDER BY tp.MarksObtained DESC";
                cmd.Parameters.AddWithValue("@ExamID", examId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TopPerformer
                        {
                            TopPerformerID = reader.GetInt32(0),
                            StudentID = reader.GetInt32(1),
                            StudentName = reader.GetString(2),
                            ExamID = reader.GetInt32(3),
                            ExamName = reader.GetString(4),
                            MarksObtained = reader.GetInt32(5),
                            Grade = reader.GetString(6),
                            RecordedDate = reader.GetString(7)
                        });
                    }
                }
            }
            return list;
        }
    }

}
