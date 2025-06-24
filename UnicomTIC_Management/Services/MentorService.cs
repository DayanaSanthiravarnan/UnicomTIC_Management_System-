using System;
using System.Collections.Generic;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{
    internal class MentorService : IMentorService
    {
        private readonly IMentorRepository _repository;

        public MentorService(IMentorRepository repository)
        {
            _repository = repository;
        }

        public int AddMentor(MentorDTO mentorDTO)
        {
            if (mentorDTO == null)
                throw new ArgumentNullException(nameof(mentorDTO));
            if (string.IsNullOrWhiteSpace(mentorDTO.Name))
                throw new ArgumentException("Mentor name is required.");

            var mentor = MentorMapper.ToEntity(mentorDTO);
            return _repository.CreateMentor(mentor);
        }

        public void UpdateMentor(MentorDTO mentorDTO)
        {
            if (mentorDTO == null)
                throw new ArgumentNullException(nameof(mentorDTO));
            if (string.IsNullOrWhiteSpace(mentorDTO.Name))
                throw new ArgumentException("Mentor name is required.");

            var mentor = MentorMapper.ToEntity(mentorDTO);
            _repository.UpdateMentor(mentor);
        }

        public void DeleteMentor(int mentorId)
        {
            _repository.DeleteMentor(mentorId);
        }

        public MentorDTO GetMentorById(int mentorId)
        {
            var mentor = _repository.GetMentorById(mentorId);
            return MentorMapper.ToDTO(mentor);
        }

        public List<MentorDTO> GetAllMentors()
        {
            var mentors = _repository.GetAllMentors();
            return MentorMapper.ToDTOList(mentors);
        }

        public MentorDTO GetMentorByUserId(int userId)
        {
            return _repository.GetMentorByUserId(userId);
        }
    }
}
