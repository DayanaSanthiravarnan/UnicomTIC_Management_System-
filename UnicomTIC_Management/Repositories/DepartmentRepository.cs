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
    public class DepartmentRepository : IDepartmentRepository
    {
        public void AddDepartment(Department department)
        {
            try
            {
                if (department == null)
                    throw new ArgumentNullException(nameof(department));

                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        INSERT INTO Departments (DepartmentName)
                        VALUES (@DepartmentName)";
                    cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while adding department: " + ex.Message, ex);
            }
        }

        public void UpdateDepartment(Department department)
        {
            try
            {
                if (department == null)
                    throw new ArgumentNullException(nameof(department));

                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        UPDATE Departments
                        SET DepartmentName = @DepartmentName
                        WHERE DepartmentID = @DepartmentID";

                    cmd.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
                    cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while updating department: " + ex.Message, ex);
            }
        }

        public void DeleteDepartment(int departmentId)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Departments WHERE DepartmentID = @DepartmentID";
                    cmd.Parameters.AddWithValue("@DepartmentID", departmentId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while deleting department: " + ex.Message, ex);
            }
        }

        public Department GetDepartmentById(int departmentId)
        {
            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT DepartmentID, DepartmentName FROM Departments WHERE DepartmentID = @DepartmentID";
                    cmd.Parameters.AddWithValue("@DepartmentID", departmentId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Department
                            {
                                DepartmentID = reader.GetInt32(0),
                                DepartmentName = reader.GetString(1)
                            };
                        }
                        return null;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while retrieving department: " + ex.Message, ex);
            }
        }

        public List<Department> GetAllDepartments()
        {
            var departments = new List<Department>();

            try
            {
                using (var conn = Dbconfig.GetConnection())
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT DepartmentID, DepartmentName FROM Departments";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departments.Add(new Department
                            {
                                DepartmentID = reader.GetInt32(0),
                                DepartmentName = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Database error while retrieving departments: " + ex.Message, ex);
            }

            return departments;
        }
    }
}
