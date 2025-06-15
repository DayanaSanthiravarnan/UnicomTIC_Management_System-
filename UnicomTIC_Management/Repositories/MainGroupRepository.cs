using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;

namespace UnicomTIC_Management.Repositories
{
    internal class MainGroupRepository: IMainGroupRepository

    {
        public void AddMainGroup(MainGroup mainGroup)
        {
            try
            {
                if (mainGroup == null)
                    throw new ArgumentNullException(nameof(mainGroup));
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                    INSERT INTO MainGroups (GroupCode,Description)
                    VALUES(@GroupCode,@Description)";
                    cmd.Parameters.AddWithValue("@GroupCode", mainGroup.GroupCode);
                    cmd.Parameters.AddWithValue("@Description", mainGroup.Description);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error While adding cource :" + ex.Message, ex);
            }

        }
        public void UpdateMainGroup(MainGroup mainGroup)
        {
            try
            {
                if (mainGroup == null)
                    throw new ArgumentNullException(nameof(mainGroup));
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        UPDATE MainGroups
                        SET GroupCode = @GroupCode,Description = @Description
                        WHERE MainGroupID = @MainGroupID";
                    cmd.Parameters.AddWithValue("@MainGroupID", mainGroup.MainGroupID);
                    cmd.Parameters.AddWithValue("@GroupCode", mainGroup.GroupCode);
                    cmd.Parameters.AddWithValue("@Description", mainGroup.Description);
                    cmd.ExecuteNonQuery();


                }

            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while updating cource :" + ex.Message, ex);
            }

        }
        public void DeleteMainGroup(int MainGroupId)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM MainGroups WHERE MainGroupID = MainGroupID";

                    cmd.Parameters.AddWithValue("@MainGroupID", MainGroupId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while updating cource :" + ex.Message, ex);
            }
        }
        public MainGroup GetMainGroupById(int MainGroupId)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT MainGroupID, GroupCode, Description FROM MainGroups WHERE MainGroupID = @MainGroupID";
                    cmd.Parameters.AddWithValue("@MainGroupID", MainGroupId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new MainGroup
                            {
                                MainGroupID = reader.GetInt32(0),
                                GroupCode = reader.GetString(1),
                               Description = reader.IsDBNull(2) ? null : reader.GetString(2)
                            };
                        }
                        return null;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while retrieving course: " + ex.Message, ex);
            }
        }
        public List<MainGroup> GetAllMainGroup()
        {
            var mainGroup = new List<MainGroup>();
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT MainGroupID, GroupCode, Description FROM MainGroups ";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mainGroup.Add(new MainGroup
                            {
                                MainGroupID = reader.GetInt32(0),
                                GroupCode = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? null : reader.GetString(2)
                            });
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while retrieving courses: " + ex.Message, ex);
            }
            return mainGroup;
        }

    }
}
