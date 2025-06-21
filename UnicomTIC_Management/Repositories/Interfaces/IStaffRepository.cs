using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Repositories.Interfaces
{
    internal interface IStaffRepository
    {
        int CreateStaff(Staff staff);
        void UpdateStaff(Staff staff);
        void DeleteStaff(int staffId);
        Staff GetStaffById(int staffId);
        List<Staff> GetAllStaff();
    }
}
