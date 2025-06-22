using System.Collections.Generic;
using System.Linq;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Utilities
{
    internal static class TimeSlotMapper
    {
        public static TimeSlot ToEntity(TimeSlotDTO dto)
        {
            if (dto == null) return null;

            return new TimeSlot
            {
                SlotID = dto.SlotID,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime
            };
        }

        public static TimeSlotDTO ToDTO(TimeSlot entity)
        {
            if (entity == null) return null;

            return new TimeSlotDTO
            {
                SlotID = entity.SlotID,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime
            };
        }

        public static List<TimeSlotDTO> ToDTOList(List<TimeSlot> entities)
        {
            return entities?.Select(ToDTO).ToList();
        }
    }
}

