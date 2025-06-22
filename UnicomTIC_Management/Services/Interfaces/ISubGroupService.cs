using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface ISubGroupService
    {
        int AddSubGroup(SubGroupDTO dto);
        void UpdateSubGroup(SubGroupDTO dto);
        void DeleteSubGroup(int subGroupId);
        SubGroupDTO GetSubGroupById(int subGroupId);
        List<SubGroupDTO> GetAllSubGroups();
        List<SubGroupDTO> GetSubGroupsByMainGroupId(int mainGroupId);
    }
}
