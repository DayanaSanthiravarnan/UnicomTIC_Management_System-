using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace UnicomTIC_Management.Utilities
{
    internal static class LecturerMapper
    {
        public static LecturerDTO ToDTO(Lecturer lecturer)
        {
            if(lecturer == null) return null;
            return new LecturerDTO
            {
                LecturerID = lecturer.LecturerID,
                Name = lecturer.Name,
               NIC = lecturer.NIC,
               Address = lecturer.Address,
               Phone = lecturer.Phone,
               DepartmentID = lecturer.DepartmentID,
                Email = lecturer.Email,
                CreatedAt = lecturer.CreatedAt,
                UpdatedAt= lecturer.UpdatedAt,
                


            };
        }
    }
}
