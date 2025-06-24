using System;
using System.Collections.Generic;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{
    internal class LecturerService : ILecturerService
    {
        private readonly ILecturerRepository _repository;

        public LecturerService(ILecturerRepository repository)
        {
            _repository = repository;
        }

        public int AddLecturer(LecturerDTO lecturerDTO)
        {
            if (lecturerDTO == null)
                throw new ArgumentNullException(nameof(lecturerDTO));

            var lecturer = LecturerMapper.ToEntity(lecturerDTO);
            return _repository.CreateLecturer(lecturer);
        }

        public void UpdateLecturer(LecturerDTO lecturerDTO)
        {
            if (lecturerDTO == null)
                throw new ArgumentNullException(nameof(lecturerDTO));

            if (string.IsNullOrWhiteSpace(lecturerDTO.Name))
                throw new ArgumentException("Lecturer name is required.");

            var lecturer = LecturerMapper.ToEntity(lecturerDTO);
            _repository.UpdateLecturer(lecturer);
        }

        public void DeleteLecturer(int lecturerId)
        {
            _repository.DeleteLecturer(lecturerId);
        }

        public LecturerDTO GetLecturerById(int lecturerId)
        {
            var lecturer = _repository.GetLecturerById(lecturerId);
            return LecturerMapper.ToDTO(lecturer);
        }

        public List<LecturerDTO> GetAllLecturers()
        {
            var lecturers = _repository.GetAllLecturers();
            return LecturerMapper.ToDTOList(lecturers);
        }
        public Lecturer GetLecturerByUserId(int userId)
        {
            return _repository.GetLecturerByUserId(userId);
        }

    }
}
