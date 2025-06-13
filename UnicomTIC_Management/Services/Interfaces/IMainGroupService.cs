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
        void AddMainGroup(MainGroupDTO MainGroupDTO);
        void UpdateMainGroup(CourseDTO MainGroupDTO);
        void DeleteMainGroup(int MainGroupId);
        MainGroupDTO GetMainGroupById(int MainGroupId);
        List<MainGroupDTO> GetAllMainGroup();
        
    }
}
