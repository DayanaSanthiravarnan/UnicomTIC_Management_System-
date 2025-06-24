using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Repositories.Interfaces;

namespace UnicomTIC_Management.Repositories
{
    internal class AttendanceRepository : IAttendanceRepository
    {
        public void AddAttendance(Attendance attendance)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO Attendance (StudentID, SubjectID, Date, TimeSlot, Status)
                    VALUES (@StudentID, @SubjectID, @Date, @TimeSlot, @Status)";
                cmd.Parameters.AddWithValue("@StudentID", attendance.StudentID);
                cmd.Parameters.AddWithValue("@SubjectID", attendance.SubjectID);
                cmd.Parameters.AddWithValue("@Date", attendance.Date);
                cmd.Parameters.AddWithValue("@TimeSlot", attendance.TimeSlot);
                cmd.Parameters.AddWithValue("@Status", attendance.Status);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateAttendance(Attendance attendance)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE Attendance 
                    SET StudentID = @StudentID,
                        SubjectID = @SubjectID,
                        Date = @Date,
                        TimeSlot = @TimeSlot,
                        Status = @Status
                    WHERE AttendanceID = @AttendanceID";
                cmd.Parameters.AddWithValue("@StudentID", attendance.StudentID);
                cmd.Parameters.AddWithValue("@SubjectID", attendance.SubjectID);
                cmd.Parameters.AddWithValue("@Date", attendance.Date);
                cmd.Parameters.AddWithValue("@TimeSlot", attendance.TimeSlot);
                cmd.Parameters.AddWithValue("@Status", attendance.Status);
                cmd.Parameters.AddWithValue("@AttendanceID", attendance.AttendanceID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAttendance(int id)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Attendance WHERE AttendanceID = @AttendanceID";
                cmd.Parameters.AddWithValue("@AttendanceID", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Attendance> GetAllAttendances()
        {
            var list = new List<Attendance>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT 
                        a.AttendanceID,
                        a.StudentID,
                        s.Name AS StudentName,
                        a.SubjectID,
                        sub.SubjectName AS SubjectName,
                        a.Date,
                        a.TimeSlot,
                        a.Status
                    FROM Attendance a
                    LEFT JOIN Students s ON a.StudentID = s.StudentID
                    LEFT JOIN Subjects sub ON a.SubjectID = sub.SubjectID
                    ORDER BY a.Date DESC";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Attendance
                        {
                            AttendanceID = reader.GetInt32(0),
                            StudentID = reader.GetInt32(1),
                            StudentName = reader.IsDBNull(2) ? null : reader.GetString(2),
                            SubjectID = reader.GetInt32(3),
                            SubjectName = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Date = reader.GetString(5),
                            TimeSlot = reader.IsDBNull(6) ? null : reader.GetString(6),
                            Status = reader.GetString(7)
                        });
                    }
                }
            }
            return list;
        }

        public Attendance GetAttendanceById(int id)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT 
                        a.AttendanceID,
                        a.StudentID,
                        s.Name AS StudentName,
                        a.SubjectID,
                        sub.SubjectName AS SubjectName,
                        a.Date,
                        a.TimeSlot,
                        a.Status
                    FROM Attendance a
                    LEFT JOIN Students s ON a.StudentID = s.StudentID
                    LEFT JOIN Subjects sub ON a.SubjectID = sub.SubjectID
                    WHERE a.AttendanceID = @AttendanceID";
                cmd.Parameters.AddWithValue("@AttendanceID", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Attendance
                        {
                            AttendanceID = reader.GetInt32(0),
                            StudentID = reader.GetInt32(1),
                            StudentName = reader.IsDBNull(2) ? null : reader.GetString(2),
                            SubjectID = reader.GetInt32(3),
                            SubjectName = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Date = reader.GetString(5),
                            TimeSlot = reader.IsDBNull(6) ? null : reader.GetString(6),
                            Status = reader.GetString(7)
                        };
                    }
                }
            }
            return null;
        }

        public bool IsAttendanceMarked(int studentId, string date)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT COUNT(*) FROM Attendance 
                    WHERE StudentID = @StudentID  AND Date = @Date";
                cmd.Parameters.AddWithValue("@StudentID", studentId);
               
                cmd.Parameters.AddWithValue("@Date", date);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}

