using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface IMainGroupService
    {
        void AddMainGroup(MainGroupDTO mainGroupDTO);
        void UpdateMainGroup(MainGroupDTO mainGroupDTO);
        void DeleteMainGroup(int mainGroupId);
        MainGroupDTO GetMainGroupById(int mainGroupId);
        List<MainGroupDTO> GetAllMainGroup();
        int CreateMainGroup(MainGroupDTO dto);
    }
}
