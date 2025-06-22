using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface ITimeSlotService
    {
        void AddTimeSlot(TimeSlotDTO timeSlotDTO);
        void UpdateTimeSlot(TimeSlotDTO timeSlotDTO);
        void DeleteTimeSlot(int slotId);
        TimeSlotDTO GetTimeSlotById(int slotId);
        List<TimeSlotDTO> GetAllTimeSlots();
        int CreateSlot(TimeSlotDTO slot);
    }
}
