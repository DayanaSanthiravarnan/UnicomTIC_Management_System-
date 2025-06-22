using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models.DTOs
{
    internal class TimeSlotDTO
    {
        public int SlotID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
