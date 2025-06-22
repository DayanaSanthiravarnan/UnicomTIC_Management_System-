using System;
using System.Collections.Generic;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{
    internal class TimeSlotService : ITimeSlotService
    {
        private readonly ITimeSlotRepository _repository;

        public TimeSlotService(ITimeSlotRepository repository)
        {
            _repository = repository;
        }

        public void AddTimeSlot(TimeSlotDTO timeSlotDTO)
        {
            if (timeSlotDTO == null)
                throw new ArgumentNullException(nameof(timeSlotDTO));
            if (string.IsNullOrWhiteSpace(timeSlotDTO.StartTime) || string.IsNullOrWhiteSpace(timeSlotDTO.EndTime))
                throw new ArgumentException("Start time and end time are required.");

            var timeSlot = TimeSlotMapper.ToEntity(timeSlotDTO);
            _repository.AddTimeSlot(timeSlot);
        }

        public void UpdateTimeSlot(TimeSlotDTO timeSlotDTO)
        {
            if (timeSlotDTO == null)
                throw new ArgumentNullException(nameof(timeSlotDTO));
            if (string.IsNullOrWhiteSpace(timeSlotDTO.StartTime) || string.IsNullOrWhiteSpace(timeSlotDTO.EndTime))
                throw new ArgumentException("Start time and end time are required.");

            var timeSlot = TimeSlotMapper.ToEntity(timeSlotDTO);
            _repository.UpdateTimeSlot(timeSlot);
        }

        public void DeleteTimeSlot(int slotId)
        {
            _repository.DeleteTimeSlot(slotId);
        }

        public TimeSlotDTO GetTimeSlotById(int slotId)
        {
            var timeSlot = _repository.GetTimeSlotById(slotId);
            return TimeSlotMapper.ToDTO(timeSlot);
        }

        public List<TimeSlotDTO> GetAllTimeSlots()
        {
            var timeSlots = _repository.GetAllTimeSlots();
            return TimeSlotMapper.ToDTOList(timeSlots);
        }
        public int CreateSlot(TimeSlotDTO slot)
        {
            var entity = TimeSlotMapper.ToEntity(slot);
            return _repository.AddSlot(entity);
        }
    }
}
