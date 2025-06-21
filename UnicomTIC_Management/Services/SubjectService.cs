using System;
using System.Collections.Generic;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{
    internal class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
            
        }


        public void AddSubject(SubjectDTO subjectDTO)
        {
            if (subjectDTO == null)
                throw new ArgumentNullException(nameof(subjectDTO));

            var subject = SubjectMapper.ToEntity(subjectDTO);
            _subjectRepository.AddSubject(subject);
        }

        public void UpdateSubject(SubjectDTO subjectDTO)
        {
            if (subjectDTO == null)
                throw new ArgumentNullException(nameof(subjectDTO));

            var subject = SubjectMapper.ToEntity(subjectDTO);
            _subjectRepository.UpdateSubject(subject);
        }

        public void DeleteSubject(int subjectId)
        {
            _subjectRepository.DeleteSubject(subjectId);
        }

        public SubjectDTO GetSubjectById(int subjectId)
        {
            var subject = _subjectRepository.GetSubjectById(subjectId);
            return SubjectMapper.ToDTO(subject);
        }

        public List<SubjectDTO> GetAllSubjects()
        {
            var subjects = _subjectRepository.GetAllSubjects();
            return SubjectMapper.ToDTOList(subjects);
        }
        public List<SubjectDTO> GetSubjectsByCourseId(int courseId)
        {
            var subjects = _subjectRepository.GetSubjectsByCourseId(courseId);
            return SubjectMapper.ToDTOList(subjects);
        }
        public int CreateSubject(SubjectDTO dto)
        {
            var entity = SubjectMapper.ToEntity(dto);
            return _subjectRepository.CreateSubject(entity); // must return new ID
        }

    }
}
