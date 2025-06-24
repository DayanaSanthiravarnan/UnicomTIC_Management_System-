using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;

namespace UnicomTIC_Management.Repositories
{
    internal class MentorRepository : IMentorRepository
    {
        public int CreateMentor(Mentor mentor)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                INSERT INTO Mentors (Name, NIC, DepartmentID, UserID, Phone, Email)
                VALUES (@Name, @NIC, @DepartmentID, @UserID, @Phone, @Email);
                SELECT last_insert_rowid();";

                cmd.Parameters.AddWithValue("@Name", mentor.Name);
                cmd.Parameters.AddWithValue("@NIC", mentor.NIC);
                cmd.Parameters.AddWithValue("@DepartmentID", mentor.DepartmentID);
                cmd.Parameters.AddWithValue("@UserID", mentor.UserID);
                cmd.Parameters.AddWithValue("@Phone", mentor.Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", mentor.Email ?? (object)DBNull.Value);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void UpdateMentor(Mentor mentor)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                UPDATE Mentors
                SET Name = @Name, NIC = @NIC, DepartmentID = @DepartmentID,
                    UserID = @UserID, Phone = @Phone, Email = @Email,
                    UpdatedAt = CURRENT_TIMESTAMP
                WHERE MentorID = @MentorID";

                cmd.Parameters.AddWithValue("@MentorID", mentor.MentorID);
                cmd.Parameters.AddWithValue("@Name", mentor.Name);
                cmd.Parameters.AddWithValue("@NIC", mentor.NIC);
                cmd.Parameters.AddWithValue("@DepartmentID", mentor.DepartmentID);
                cmd.Parameters.AddWithValue("@UserID", mentor.UserID);
                cmd.Parameters.AddWithValue("@Phone", mentor.Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", mentor.Email ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteMentor(int mentorId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Mentors WHERE MentorID = @MentorID";
                cmd.Parameters.AddWithValue("@MentorID", mentorId);
                cmd.ExecuteNonQuery();
            }
        }

        public Mentor GetMentorById(int mentorId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Mentors WHERE MentorID = @MentorID";
                cmd.Parameters.AddWithValue("@MentorID", mentorId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Mentor
                        {
                            MentorID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            NIC = reader.GetString(2),
                            DepartmentID = reader.GetInt32(3),
                            UserID = reader.GetInt32(4),
                            Phone = reader.IsDBNull(5) ? null : reader.GetString(5),
                            Email = reader.IsDBNull(6) ? null : reader.GetString(6),
                            CreatedAt = reader.GetDateTime(7),
                            UpdatedAt = reader.GetDateTime(8)
                        };
                    }
                }
            }
            return null;
        }

        public List<Mentor> GetAllMentors()
        {
            var mentors = new List<Mentor>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Mentors";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mentors.Add(new Mentor
                        {
                            MentorID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            NIC = reader.GetString(2),
                            DepartmentID = reader.GetInt32(3),
                            UserID = reader.GetInt32(4),
                            Phone = reader.IsDBNull(5) ? null : reader.GetString(5),
                            Email = reader.IsDBNull(6) ? null : reader.GetString(6),
                            CreatedAt = reader.GetDateTime(7),
                            UpdatedAt = reader.GetDateTime(8)
                        });
                    }
                }
            }
            return mentors;
        }
        public MentorDTO GetMentorByUserId(int userId)
        {
            using (var connection = Dbconfig.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"
            SELECT m.MentorID, m.Name, m.NIC, m.Phone, m.Email, m.DepartmentID, m.UserID, m.CreatedAt, m.UpdatedAt,
                   d.Name AS DepartmentName
            FROM Mentors m
            LEFT JOIN Departments d ON m.DepartmentID = d.DepartmentID
            WHERE m.UserID = @UserID";
                cmd.Parameters.AddWithValue("@UserID", userId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new MentorDTO
                        {
                            MentorID = Convert.ToInt32(reader["MentorID"]),
                            Name = reader["Name"].ToString(),
                            NIC = reader["NIC"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Email"].ToString(),
                            DepartmentID = reader["DepartmentID"] as int? ?? 0,
                            DepartmentName = reader["DepartmentName"]?.ToString(),
                            UserID = Convert.ToInt32(reader["UserID"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                        };
                    }
                }
            }

            return null;
        }
    }

}
