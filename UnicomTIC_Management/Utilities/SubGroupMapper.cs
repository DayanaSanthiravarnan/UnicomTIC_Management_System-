using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Utilities
{
    internal static class SubGroupMapper
    {
        public static SubGroupDTO ToDTO(SubGroup entity, string mainGroupName = null)
        {
            if (entity == null) return null;
            return new SubGroupDTO
            {
                SubGroupID = entity.SubGroupID,
                MainGroupID = entity.MainGroupID,
                MainGroupName = mainGroupName,
                SubGroupName = entity.SubGroupName,
                Description = entity.Description
            };
        }

        public static SubGroup ToEntity(SubGroupDTO dto)
        {
            if (dto == null) return null;
            return new SubGroup
            {
                SubGroupID = dto.SubGroupID,
                MainGroupID = dto.MainGroupID,
                SubGroupName = dto.SubGroupName,
                Description = dto.Description
            };
        }

        public static List<SubGroupDTO> ToDTOList(IEnumerable<SubGroup> entities, IEnumerable<(int id, string name)> mainGroupNames = null)
        {
            if (entities == null) return new List<SubGroupDTO>();

            if (mainGroupNames == null)
                return entities.Select(e => ToDTO(e)).ToList();

            var nameDict = mainGroupNames.ToDictionary(x => x.id, x => x.name);

            return entities.Select(e => ToDTO(e, nameDict.ContainsKey(e.MainGroupID) ? nameDict[e.MainGroupID] : null)).ToList();
        }

        public static List<SubGroup> ToEntityList(IEnumerable<SubGroupDTO> dtos)
        {
            return dtos?.Select(dto => ToEntity(dto)).ToList() ?? new List<SubGroup>();
        }
    }
}

