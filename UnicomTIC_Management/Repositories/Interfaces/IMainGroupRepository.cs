using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Repositories.Interfaces
{
    internal interface IMainGroupRepository
    {
        void AddMainGroup(MainGroup MainGroup);
        void UpdateMainGroup(MainGroup MainGroup);
        void DeleteMainGroup(int MainGroupId);
        MainGroup GetMainGroupById(int MainGroupId);
        List<MainGroup> GetAllMainGroup();
    }
}
