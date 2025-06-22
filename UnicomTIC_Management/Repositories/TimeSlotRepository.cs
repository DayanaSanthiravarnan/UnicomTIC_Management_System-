using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Repositories.Interfaces;

namespace UnicomTIC_Management.Repositories
{
    internal class TimeSlotRepository : ITimeSlotRepository
    {
        public void AddTimeSlot(TimeSlot timeSlot)
        {
            try
            {
                if (timeSlot == null)
                    throw new ArgumentNullException(nameof(timeSlot));

                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        INSERT INTO TimeSlots (StartTime, EndTime)
                        VALUES (@StartTime, @EndTime)";
                    cmd.Parameters.AddWithValue("@StartTime", timeSlot.StartTime);
                    cmd.Parameters.AddWithValue("@EndTime", timeSlot.EndTime);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while adding time slot: " + ex.Message, ex);
            }
        }

        public void UpdateTimeSlot(TimeSlot timeSlot)
        {
            try
            {
                if (timeSlot == null)
                    throw new ArgumentNullException(nameof(timeSlot));

                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        UPDATE TimeSlots 
                        SET StartTime = @StartTime, EndTime = @EndTime
                        WHERE SlotID = @SlotID";
                    cmd.Parameters.AddWithValue("@SlotID", timeSlot.SlotID);
                    cmd.Parameters.AddWithValue("@StartTime", timeSlot.StartTime);
                    cmd.Parameters.AddWithValue("@EndTime", timeSlot.EndTime);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while updating time slot: " + ex.Message, ex);
            }
        }

        public void DeleteTimeSlot(int slotId)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM TimeSlots WHERE SlotID = @SlotID";
                    cmd.Parameters.AddWithValue("@SlotID", slotId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while deleting time slot: " + ex.Message, ex);
            }
        }

        public TimeSlot GetTimeSlotById(int slotId)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT SlotID, StartTime, EndTime FROM TimeSlots WHERE SlotID = @SlotID";
                    cmd.Parameters.AddWithValue("@SlotID", slotId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new TimeSlot
                            {
                                SlotID = reader.GetInt32(0),
                                StartTime = reader.GetString(1),
                                EndTime = reader.GetString(2)
                            };
                        }
                        return null;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while retrieving time slot: " + ex.Message, ex);
            }
        }

        public List<TimeSlot> GetAllTimeSlots()
        {
            var slots = new List<TimeSlot>();
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT SlotID, StartTime, EndTime FROM TimeSlots";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            slots.Add(new TimeSlot
                            {
                                SlotID = reader.GetInt32(0),
                                StartTime = reader.GetString(1),
                                EndTime = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while retrieving time slots: " + ex.Message, ex);
            }
            return slots;
        }
        public int AddSlot(TimeSlot slot)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
            INSERT INTO TimeSlots (StartTime, EndTime)
            VALUES (@StartTime, @EndTime);
            SELECT last_insert_rowid();";

                cmd.Parameters.AddWithValue("@StartTime", slot.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", slot.EndTime);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

    }
}
