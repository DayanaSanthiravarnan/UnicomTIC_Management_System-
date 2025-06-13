using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Utilities
{
    internal static class MainGroupMapper
    {
        public static MainGroupDTO ToDTO(MainGroup maingroup)
        {
            if (maingroup == null) return null;
            return new MainGroupDTO
            {
                MainGroupID = maingroup.MainGroupID,
                GroupCode = maingroup.GroupCode,
                Description = maingroup.Description
            };
        }
        public static MainGroup ToEntity(MainGroupDTO maingroupDTO)
        {
            return new MainGroup
            {
                MainGroupID = maingroupDTO.MainGroupID,
                GroupCode = maingroupDTO.GroupCode,
                Description = maingroupDTO.Description
            };
        } 
        public static List<MainGroupDTO> ToDTOList(IEnumerable<MainGroup> maingroups)
        {
            return maingroups?.Select(x => ToDTO(x)).ToList() ?? new List<MainGroupDTO>();
        }
        public static List<MainGroup> ToEntityList(IEnumerable<MainGroupDTO> maingroupDTOs)
        {
            return maingroupDTOs?.Select(x => ToEntity(x)).ToList() ?? new List<MainGroup>();
        }


    }
}
