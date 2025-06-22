using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Repositories.Interfaces
{
    internal interface ISubGroupRepository
    {
        int AddSubGroup(SubGroup subgroup);
        void UpdateSubGroup(SubGroup subgroup);
        void DeleteSubGroup(int subGroupId);
        SubGroup GetSubGroupById(int subGroupId);
        List<SubGroup> GetAllSubGroups();
        List<SubGroup> GetSubGroupsByMainGroupId(int mainGroupId);
    }
}
