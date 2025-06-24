using System;
using System.Collections.Generic;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{
    internal class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public void AddAttendance(AttendanceDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var entity = AttendanceMapper.ToEntity(dto);
            _attendanceRepository.AddAttendance(entity);
        }

        public void UpdateAttendance(AttendanceDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var entity = AttendanceMapper.ToEntity(dto);
            _attendanceRepository.UpdateAttendance(entity);
        }

        public void DeleteAttendance(int id)
        {
            _attendanceRepository.DeleteAttendance(id);
        }

        public AttendanceDTO GetAttendanceById(int id)
        {
            var entity = _attendanceRepository.GetAttendanceById(id);
            return AttendanceMapper.ToDTO(entity);
        }

        public List<AttendanceDTO> GetAllAttendances()
        {
            var entities = _attendanceRepository.GetAllAttendances();
            return AttendanceMapper.ToDTOList(entities);
        }

        public bool IsAttendanceMarked(int studentId,  string date)
        {
            return _attendanceRepository.IsAttendanceMarked(studentId, date);
        }
    }
}
