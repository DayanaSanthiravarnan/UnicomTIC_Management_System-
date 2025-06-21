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
    internal class SubGroupRepository : ISubGroupRepository
    {
        public void AddSubGroup(SubGroup subGroup)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO SubGroups (MainGroupID, SubGroupName, Description) VALUES (@MainGroupID, @SubGroupName, @Description)";
                cmd.Parameters.AddWithValue("@MainGroupID", subGroup.MainGroupID);
                cmd.Parameters.AddWithValue("@SubGroupName", subGroup.SubGroupName);
                cmd.Parameters.AddWithValue("@Description", subGroup.Description ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateSubGroup(SubGroup subGroup)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"UPDATE SubGroups SET MainGroupID = @MainGroupID, SubGroupName = @SubGroupName, Description = @Description WHERE SubGroupID = @SubGroupID";
                cmd.Parameters.AddWithValue("@SubGroupID", subGroup.SubGroupID);
                cmd.Parameters.AddWithValue("@MainGroupID", subGroup.MainGroupID);
                cmd.Parameters.AddWithValue("@SubGroupName", subGroup.SubGroupName);
                cmd.Parameters.AddWithValue("@Description", subGroup.Description ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSubGroup(int subGroupId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM SubGroups WHERE SubGroupID = @SubGroupID";
                cmd.Parameters.AddWithValue("@SubGroupID", subGroupId);
                cmd.ExecuteNonQuery();
            }
        }

        public SubGroup GetSubGroupById(int subGroupId)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT SubGroupID, MainGroupID, SubGroupName, Description FROM SubGroups WHERE SubGroupID = @SubGroupID";
                cmd.Parameters.AddWithValue("@SubGroupID", subGroupId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new SubGroup
                        {
                            SubGroupID = reader.GetInt32(0),
                            MainGroupID = reader.GetInt32(1),
                            SubGroupName = reader.GetString(2),
                            Description = reader.IsDBNull(3) ? null : reader.GetString(3)
                        };
                    }
                }
            }
            return null;
        }

        public List<SubGroup> GetAllSubGroups()
        {
            var list = new List<SubGroup>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT SubGroupID, MainGroupID, SubGroupName, Description FROM SubGroups";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SubGroup
                        {
                            SubGroupID = reader.GetInt32(0),
                            MainGroupID = reader.GetInt32(1),
                            SubGroupName = reader.GetString(2),
                            Description = reader.IsDBNull(3) ? null : reader.GetString(3)
                        });
                    }
                }
            }
            return list;
        }

        public List<SubGroup> GetSubGroupsByMainGroupId(int mainGroupId)
        {
            var list = new List<SubGroup>();
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT SubGroupID, MainGroupID, SubGroupName, Description FROM SubGroups WHERE MainGroupID = @MainGroupID";
                cmd.Parameters.AddWithValue("@MainGroupID", mainGroupId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SubGroup
                        {
                            SubGroupID = reader.GetInt32(0),
                            MainGroupID = reader.GetInt32(1),
                            SubGroupName = reader.GetString(2),
                            Description = reader.IsDBNull(3) ? null : reader.GetString(3)
                        });
                    }
                }
            }
            return list;
        }
        public int CreateSubGroup(SubGroup subGroup)
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO SubGroups (MainGroupID, SubGroupName, Description) 
                            VALUES (@MainGroupID, @SubGroupName, @Description); 
                            SELECT last_insert_rowid();"; // SQLite specific
                cmd.Parameters.AddWithValue("@MainGroupID", subGroup.MainGroupID);
                cmd.Parameters.AddWithValue("@SubGroupName", subGroup.SubGroupName);
                cmd.Parameters.AddWithValue("@Description", subGroup.Description ?? (object)DBNull.Value);

                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }
    }
}
