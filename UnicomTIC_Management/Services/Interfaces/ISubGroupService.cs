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
        void AddSubGroup(SubGroupDTO dto);
        void UpdateSubGroup(SubGroupDTO dto);
        void DeleteSubGroup(int id);
        SubGroupDTO GetSubGroupById(int id);
        List<SubGroupDTO> GetAllSubGroups();

        List<SubGroupDTO> GetSubGroupsByMainGroupId(int mainGroupId);
        int CreateSubGroup(SubGroupDTO dto);
    }
}
