using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Repositories.Interfaces
{
    internal interface ITimeSlotRepository
    {
        void AddTimeSlot(TimeSlot timeSlot);
        void UpdateTimeSlot(TimeSlot timeSlot);
        void DeleteTimeSlot(int slotId);
        TimeSlot GetTimeSlotById(int slotId);
        List<TimeSlot> GetAllTimeSlots();
        int AddSlot(TimeSlot slot);
    }
}
