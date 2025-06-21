using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Utilities
{
    namespace UnicomTIC_Management.Mappers
    {
        internal static class NICDetailMapper
        {
            // Entity → DTO
            public static NICDetailDTO ToDTO(NICDetail entity)
            {
                if (entity == null) return null;

                return new NICDetailDTO
                {
                    NIC = entity.NIC,
                    IsUsed = entity.IsUsed
                };
            }

            // DTO → Entity
            public static NICDetail ToEntity(NICDetailDTO dto)
            {
                if (dto == null) return null;

                return new NICDetail
                {
                    NIC = dto.NIC,
                    IsUsed = dto.IsUsed
                };
            }

            // List<Entity> → List<DTO>
            public static List<NICDetailDTO> ToDTOList(IEnumerable<NICDetail> entities)
            {
                return entities?.Select(e => ToDTO(e)).ToList() ?? new List<NICDetailDTO>();
            }

            // List<DTO> → List<Entity>
            public static List<NICDetail> ToEntityList(IEnumerable<NICDetailDTO> dtos)
            {
                return dtos?.Select(d => ToEntity(d)).ToList() ?? new List<NICDetail>();
            }
        }
    }
}