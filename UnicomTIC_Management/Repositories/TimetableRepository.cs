using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;

namespace UnicomTIC_Management.Repositories
{
    internal class TimetableRepository : ITimetableRepository
    {
        public int AddTimetable(TimeTable timetable)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO Timetables 
                    (CourseID, SubjectID, LecturerID, RoomID, SlotID, MainGroupID, SubGroupID, DayOfWeek, AcademicYear, Semester)
                    VALUES 
                    (@CourseID, @SubjectID, @LecturerID, @RoomID, @SlotID, @MainGroupID, @SubGroupID, @DayOfWeek, @AcademicYear, @Semester);
                    SELECT last_insert_rowid();";

                cmd.Parameters.AddWithValue("@CourseID", timetable.CourseID);
                cmd.Parameters.AddWithValue("@SubjectID", timetable.SubjectID);
                cmd.Parameters.AddWithValue("@LecturerID", timetable.LecturerID);
                cmd.Parameters.AddWithValue("@RoomID", timetable.RoomID);
                cmd.Parameters.AddWithValue("@SlotID", timetable.SlotID);
                cmd.Parameters.AddWithValue("@MainGroupID", timetable.MainGroupID);
                cmd.Parameters.AddWithValue("@SubGroupID", timetable.SubGroupID);
                cmd.Parameters.AddWithValue("@DayOfWeek", timetable.DayOfWeek);
                cmd.Parameters.AddWithValue("@AcademicYear", timetable.AcademicYear);
                cmd.Parameters.AddWithValue("@Semester", timetable.Semester);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void UpdateTimetable(TimeTable timetable)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE Timetables SET
                        CourseID = @CourseID,
                        SubjectID = @SubjectID,
                        LecturerID = @LecturerID,
                        RoomID = @RoomID,
                        SlotID = @SlotID,
                        MainGroupID = @MainGroupID,
                        SubGroupID = @SubGroupID,
                        DayOfWeek = @DayOfWeek,
                        AcademicYear = @AcademicYear,
                        Semester = @Semester
                    WHERE TimetableID = @TimetableID";

                cmd.Parameters.AddWithValue("@TimetableID", timetable.TimetableID);
                cmd.Parameters.AddWithValue("@CourseID", timetable.CourseID);
                cmd.Parameters.AddWithValue("@SubjectID", timetable.SubjectID);
                cmd.Parameters.AddWithValue("@LecturerID", timetable.LecturerID);
                cmd.Parameters.AddWithValue("@RoomID", timetable.RoomID);
                cmd.Parameters.AddWithValue("@SlotID", timetable.SlotID);
                cmd.Parameters.AddWithValue("@MainGroupID", timetable.MainGroupID);
                cmd.Parameters.AddWithValue("@SubGroupID", timetable.SubGroupID);
                cmd.Parameters.AddWithValue("@DayOfWeek", timetable.DayOfWeek);
                cmd.Parameters.AddWithValue("@AcademicYear", timetable.AcademicYear);
                cmd.Parameters.AddWithValue("@Semester", timetable.Semester);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTimetable(int timetableId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Timetables WHERE TimetableID = @TimetableID";
                cmd.Parameters.AddWithValue("@TimetableID", timetableId);
                cmd.ExecuteNonQuery();
            }
        }

        public TimeTable GetTimetableById(int timetableId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Timetables WHERE TimetableID = @TimetableID";
                cmd.Parameters.AddWithValue("@TimetableID", timetableId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TimeTable
                        {
                            TimetableID = reader.GetInt32(0),
                            CourseID = reader.GetInt32(1),
                            SubjectID = reader.GetInt32(2),
                            LecturerID = reader.GetInt32(3),
                            RoomID = reader.GetInt32(4),
                            SlotID = reader.GetInt32(5),
                            MainGroupID = reader.GetInt32(6),
                            SubGroupID = reader.GetInt32(7),
                            DayOfWeek = reader.GetString(8),
                            AcademicYear = reader.GetString(9),
                            Semester = reader.GetString(10)
                        };
                    }
                }
            }
            return null;
        }

        public List<TimeTable> GetAllTimetables()
        {
            var list = new List<TimeTable>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Timetables";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TimeTable
                        {
                            TimetableID = reader.GetInt32(0),
                            CourseID = reader.GetInt32(1),
                            SubjectID = reader.GetInt32(2),
                            LecturerID = reader.GetInt32(3),
                            RoomID = reader.GetInt32(4),
                            SlotID = reader.GetInt32(5),
                            MainGroupID = reader.GetInt32(6),
                            SubGroupID = reader.GetInt32(7),
                            DayOfWeek = reader.GetString(8),
                            AcademicYear = reader.GetString(9),
                            Semester = reader.GetString(10)
                        });
                    }
                }
            }
            return list;
        }

        public List<TimeTable> GetTimetablesByCourseId(int courseId)
        {
            var list = new List<TimeTable>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Timetables WHERE CourseID = @CourseID";
                cmd.Parameters.AddWithValue("@CourseID", courseId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TimeTable
                        {
                            TimetableID = reader.GetInt32(0),
                            CourseID = reader.GetInt32(1),
                            SubjectID = reader.GetInt32(2),
                            LecturerID = reader.GetInt32(3),
                            RoomID = reader.GetInt32(4),
                            SlotID = reader.GetInt32(5),
                            MainGroupID = reader.GetInt32(6),
                            SubGroupID = reader.GetInt32(7),
                            DayOfWeek = reader.GetString(8),
                            AcademicYear = reader.GetString(9),
                            Semester = reader.GetString(10)
                        });
                    }
                }
            }
            return list;
        }

        public List<TimeTable> GetTimetablesByMainGroupId(int mainGroupId)
        {
            var list = new List<TimeTable>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Timetables WHERE MainGroupID = @MainGroupID";
                cmd.Parameters.AddWithValue("@MainGroupID", mainGroupId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TimeTable
                        {
                            TimetableID = reader.GetInt32(0),
                            CourseID = reader.GetInt32(1),
                            SubjectID = reader.GetInt32(2),
                            LecturerID = reader.GetInt32(3),
                            RoomID = reader.GetInt32(4),
                            SlotID = reader.GetInt32(5),
                            MainGroupID = reader.GetInt32(6),
                            SubGroupID = reader.GetInt32(7),
                            DayOfWeek = reader.GetString(8),
                            AcademicYear = reader.GetString(9),
                            Semester = reader.GetString(10)
                        });
                    }
                }
            }
            return list;
        }

        public bool IsSlotOccupied(TimetableDTO dto, int? ignoreTimetableId = null)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT COUNT(*)
                    FROM Timetables
                    WHERE SlotID = @SlotID
                      AND DayOfWeek = @DayOfWeek
                      AND RoomID = @RoomID
                      AND LecturerID = @LecturerID
                      AND MainGroupID = @MainGroupID
                      AND SubGroupID = @SubGroupID"
                    + (ignoreTimetableId != null ? " AND TimetableID != @TimetableID" : "");

                cmd.Parameters.AddWithValue("@SlotID", dto.SlotID);
                cmd.Parameters.AddWithValue("@DayOfWeek", dto.DayOfWeek);
                cmd.Parameters.AddWithValue("@RoomID", dto.RoomID);
                cmd.Parameters.AddWithValue("@LecturerID", dto.LecturerID);
                cmd.Parameters.AddWithValue("@MainGroupID", dto.MainGroupID);
                cmd.Parameters.AddWithValue("@SubGroupID", dto.SubGroupID);

                if (ignoreTimetableId != null)
                    cmd.Parameters.AddWithValue("@TimetableID", ignoreTimetableId.Value);

                var count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        public List<TimetableDTO> GetTimetableByGroup(int mainGroupId, int? subGroupId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
            SELECT * FROM Timetables 
            WHERE MainGroupID = @MainGroupID
            OR (SubGroupID IS NOT NULL AND SubGroupID = @SubGroupID)";

                cmd.Parameters.AddWithValue("@MainGroupID", mainGroupId);
                cmd.Parameters.AddWithValue("@SubGroupID", subGroupId.HasValue ? (object)subGroupId.Value : DBNull.Value);

                var timetables = new List<TimetableDTO>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        timetables.Add(new TimetableDTO
                        {
                            // map timetable fields here
                        });
                    }
                }
                return timetables;
            }
        }
        public List<TimetableDTO> GetTimetableViewByGroup(int mainGroupId, int? subGroupId)
        {
            var list = new List<TimetableDTO>();

            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
            SELECT 
                c.CourseName,
                l.Name AS LecturerName,
                r.RoomName,
                t.Day,
                ts.StartTime,
                ts.EndTime,
                mg.GroupName AS MainGroupName,
                sg.GroupName AS SubGroupName
            FROM Timetables t
            JOIN Courses c ON t.CourseID = c.CourseID
            JOIN Lecturers l ON t.LecturerID = l.LecturerID
            JOIN Rooms r ON t.RoomID = r.RoomID
            JOIN TimeSlots ts ON t.TimeSlotID = ts.TimeSlotID
            JOIN MainGroups mg ON t.MainGroupID = mg.MainGroupID
            LEFT JOIN SubGroups sg ON t.SubGroupID = sg.SubGroupID
            WHERE t.MainGroupID = @MainGroupID
              AND (@SubGroupID IS NULL OR t.SubGroupID = @SubGroupID)";

                cmd.Parameters.AddWithValue("@MainGroupID", mainGroupId);
                cmd.Parameters.AddWithValue("@SubGroupID", (object)subGroupId ?? DBNull.Value);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TimetableDTO
                        {
                            CourseName = reader["CourseName"].ToString(),
                            LecturerName = reader["LecturerName"].ToString(),
                            RoomName = reader["RoomName"].ToString(),
                            DayOfWeek = reader["Day"].ToString(),
                            
                            MainGroupName = reader["MainGroupName"].ToString(),
                            SubGroupName = reader["SubGroupName"]?.ToString() ?? "N/A"
                        });
                    }
                }
            }

            return list;
        }


    }

}
