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
                throw new Exception("Database error While adding cource :" + ex.Message,ex);
        }
    }
}
