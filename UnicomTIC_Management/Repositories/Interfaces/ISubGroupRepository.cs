using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Repositories.Interfaces
{
    internal interface ISubGroupRepository
    {
        int CreateSubGroup(SubGroup subGroup);
        void AddSubGroup(SubGroup subGroup);
        void UpdateSubGroup(SubGroup subGroup);
        void DeleteSubGroup(int subGroupId);
        SubGroup GetSubGroupById(int subGroupId);
        List<SubGroup> GetAllSubGroups();

        List<SubGroup> GetSubGroupsByMainGroupId(int mainGroupId);  
    }
}
