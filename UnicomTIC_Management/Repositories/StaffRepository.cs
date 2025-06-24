using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Repositories.Interfaces;

namespace UnicomTIC_Management.Repositories
{
    internal class StaffRepository : IStaffRepository
    {
        public int CreateStaff(Staff staff)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO Staff (Name, NIC, DepartmentID, ContactNo, Email, UserID)
                    VALUES (@Name, @NIC, @DepartmentID, @ContactNo, @Email, @UserID);
                    SELECT last_insert_rowid();";

                cmd.Parameters.AddWithValue("@Name", staff.Name);
                cmd.Parameters.AddWithValue("@NIC", staff.NIC);
                cmd.Parameters.AddWithValue("@DepartmentID", (object)staff.DepartmentID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ContactNo", staff.ContactNo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", staff.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@UserID", staff.UserID);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void UpdateStaff(Staff staff)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE Staff SET 
                        Name = @Name,
                        NIC = @NIC,
                        DepartmentID = @DepartmentID,
                        ContactNo = @ContactNo,
                        Email = @Email
                    WHERE StaffID = @StaffID";

                cmd.Parameters.AddWithValue("@StaffID", staff.StaffID);
                cmd.Parameters.AddWithValue("@Name", staff.Name);
                cmd.Parameters.AddWithValue("@NIC", staff.NIC);
                cmd.Parameters.AddWithValue("@DepartmentID", (object)staff.DepartmentID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ContactNo", staff.ContactNo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", staff.Email ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStaff(int staffId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Staff WHERE StaffID = @StaffID";
                cmd.Parameters.AddWithValue("@StaffID", staffId);
                cmd.ExecuteNonQuery();
            }
        }

        public Staff GetStaffById(int staffId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Staff WHERE StaffID = @StaffID";
                cmd.Parameters.AddWithValue("@StaffID", staffId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Staff
                        {
                            StaffID = reader.GetInt32(reader.GetOrdinal("StaffID")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            NIC = reader.GetString(reader.GetOrdinal("NIC")),
                            DepartmentID = reader.IsDBNull(reader.GetOrdinal("DepartmentID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DepartmentID")),
                            ContactNo = reader.IsDBNull(reader.GetOrdinal("ContactNo")) ? null : reader.GetString(reader.GetOrdinal("ContactNo")),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                            UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                            CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt"))),
                            UpdatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("UpdatedAt")))
                        };
                    }
                }
            }
            return null;
        }

        public List<Staff> GetAllStaff()
        {
            var staffs = new List<Staff>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Staff";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        staffs.Add(new Staff
                        {
                            StaffID = reader.GetInt32(reader.GetOrdinal("StaffID")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            NIC = reader.GetString(reader.GetOrdinal("NIC")),
                            DepartmentID = reader.IsDBNull(reader.GetOrdinal("DepartmentID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DepartmentID")),
                            ContactNo = reader.IsDBNull(reader.GetOrdinal("ContactNo")) ? null : reader.GetString(reader.GetOrdinal("ContactNo")),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                            UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                            CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("CreatedAt"))),
                            UpdatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("UpdatedAt")))
                        });
                    }
                }
            }
            return staffs;
        }
        public Staff GetStaffByUserId(int userId)
        {
            Staff staff = null;

            using (var connection = Dbconfig.GetConnection())
            {
                var cmd = connection.CreateCommand();

                // Change 'Staffs' to the actual table name in your DB, e.g. 'Staff'
                cmd.CommandText = @"
            SELECT s.StaffID, s.Name, s.NIC, s.DepartmentID, s.ContactNo, s.Email, s.UserID, s.CreatedAt, s.UpdatedAt, d.Name as DepartmentName
            FROM Staff s
            LEFT JOIN Departments d ON s.DepartmentID = d.DepartmentID
            WHERE s.UserID = @UserID";

                cmd.Parameters.AddWithValue("@UserID", userId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        staff = new Staff();
                        staff.StaffID = Convert.ToInt32(reader["StaffID"]);
                        staff.Name = reader["Name"].ToString();
                        staff.NIC = reader["NIC"].ToString();
                        staff.DepartmentID = reader["DepartmentID"] != DBNull.Value ? Convert.ToInt32(reader["DepartmentID"]) : (int?)null;
                        staff.ContactNo = reader["ContactNo"].ToString();
                        staff.Email = reader["Email"].ToString();
                        staff.UserID = Convert.ToInt32(reader["UserID"]);
                        staff.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                        staff.UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"]);
                        staff.DepartmentName = reader["DepartmentName"].ToString();
                    }
                }
            }

            return staff;
        }
    }
}


