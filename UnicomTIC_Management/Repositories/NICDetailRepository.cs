using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Repositories.Interfaces;

namespace UnicomTIC_Management.Repositories
{
    namespace UnicomTIC_Management.Repositories
    {
        internal class NICDetailRepository : INICDetailRepository
        {
            public void Add(NICDetail nic)
            {
                try
                {
                    if (nic == null)
                        throw new ArgumentNullException(nameof(nic));

                    using (var conn = Dbconfig.GetConnection())
                    {
                        var cmd = conn.CreateCommand();
                        cmd.CommandText = @"
                        INSERT INTO NICDetails (NIC, IsUsed)
                        VALUES (@NIC, @IsUsed)";
                        cmd.Parameters.AddWithValue("@NIC", nic.NIC);
                        cmd.Parameters.AddWithValue("@IsUsed", nic.IsUsed ? 1 : 0);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SQLiteException ex)
                {
                    throw new Exception("Database error while adding NIC: " + ex.Message, ex);
                }
            }

            public void Update(NICDetail nic)
            {
                try
                {
                    if (nic == null)
                        throw new ArgumentNullException(nameof(nic));

                    using (var conn = Dbconfig.GetConnection())
                    {
                        var cmd = conn.CreateCommand();
                        cmd.CommandText = @"
                        UPDATE NICDetails 
                        SET IsUsed = @IsUsed
                        WHERE NIC = @NIC";
                        cmd.Parameters.AddWithValue("@NIC", nic.NIC);
                        cmd.Parameters.AddWithValue("@IsUsed", nic.IsUsed ? 1 : 0);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SQLiteException ex)
                {
                    throw new Exception("Database error while updating NIC: " + ex.Message, ex);
                }
            }

            public void MarkAsUsed(string nic)
            {
                try
                {
                    using (var conn = Dbconfig.GetConnection())
                    {
                        var cmd = conn.CreateCommand();
                        cmd.CommandText = "UPDATE NICDetails SET IsUsed = 1 WHERE NIC = @NIC";
                        cmd.Parameters.AddWithValue("@NIC", nic);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SQLiteException ex)
                {
                    throw new Exception("Database error while marking NIC as used: " + ex.Message, ex);
                }
            }

            public bool Exists(string nic)
            {
                try
                {
                    using (var conn = Dbconfig.GetConnection())
                    {
                        var cmd = conn.CreateCommand();
                        cmd.CommandText = "SELECT COUNT(*) FROM NICDetails WHERE NIC = @NIC";
                        cmd.Parameters.AddWithValue("@NIC", nic);
                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
                catch (SQLiteException ex)
                {
                    throw new Exception("Database error while checking NIC existence: " + ex.Message, ex);
                }
            }

            public bool IsUsed(string nic)
            {
                try
                {
                    using (var conn = Dbconfig.GetConnection())
                    {
                        var cmd = conn.CreateCommand();
                        cmd.CommandText = "SELECT IsUsed FROM NICDetails WHERE NIC = @NIC";
                        cmd.Parameters.AddWithValue("@NIC", nic);
                        var result = cmd.ExecuteScalar();
                        return result != null && Convert.ToInt32(result) == 1;
                    }
                }
                catch (SQLiteException ex)
                {
                    throw new Exception("Database error while checking NIC status: " + ex.Message, ex);
                }
            }

            public NICDetail GetByNIC(string nic)
            {
                try
                {
                    using (var conn = Dbconfig.GetConnection())
                    {
                        var cmd = conn.CreateCommand();
                        cmd.CommandText = "SELECT NIC, IsUsed FROM NICDetails WHERE NIC = @NIC";
                        cmd.Parameters.AddWithValue("@NIC", nic);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new NICDetail
                                {
                                    NIC = reader["NIC"].ToString(),
                                    IsUsed = Convert.ToInt32(reader["IsUsed"]) == 1
                                };
                            }
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    throw new Exception("Database error while retrieving NIC: " + ex.Message, ex);
                }

                return null;
            }

            public List<NICDetail> GetAll()
            {
                var list = new List<NICDetail>();
                try
                {
                    using (var conn = Dbconfig.GetConnection())
                    {
                        var cmd = conn.CreateCommand();
                        cmd.CommandText = "SELECT NIC, IsUsed FROM NICDetails";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new NICDetail
                                {
                                    NIC = reader["NIC"].ToString(),
                                    IsUsed = Convert.ToInt32(reader["IsUsed"]) == 1
                                });
                            }
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    throw new Exception("Database error while retrieving NIC list: " + ex.Message, ex);
                }

                return list;
            }
        }
    }
}