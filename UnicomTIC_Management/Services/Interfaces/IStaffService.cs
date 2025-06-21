using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface IStaffService
    {
        int AddStaff(StaffDTO staffDTO);
        void UpdateStaff(StaffDTO staffDTO);
        void DeleteStaff(int staffId);
        StaffDTO GetStaffById(int staffId);
        List<StaffDTO> GetAllStaff();
    }
}
