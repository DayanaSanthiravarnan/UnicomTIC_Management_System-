using System;
using System.Collections.Generic;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;  // For MarksMapper

namespace UnicomTIC_Management.Services
{
    internal class MarksService : IMarksService
    {
        private readonly IMarksRepository _marksRepository;

        public MarksService(IMarksRepository marksRepository)
        {
            _marksRepository = marksRepository ?? throw new ArgumentNullException(nameof(marksRepository));
        }

        public void AddMark(MarksDTO markDTO)
        {
            if (markDTO == null)
                throw new ArgumentNullException(nameof(markDTO));

            // Add any validation you need here, for example:
            if (markDTO.StudentID <= 0)
                throw new ArgumentException("Valid StudentID is required.");
            if (markDTO.SubjectID <= 0)
                throw new ArgumentException("Valid SubjectID is required.");
            if (markDTO.ExamID <= 0)
                throw new ArgumentException("Valid ExamID is required.");
            if (markDTO.MarksObtained < 0)
                throw new ArgumentException("MarksObtained cannot be negative.");

            var mark = MarksMapper.ToEntity(markDTO);
            _marksRepository.AddMark(mark);
        }

        public void UpdateMark(MarksDTO markDTO)
        {
            if (markDTO == null)
                throw new ArgumentNullException(nameof(markDTO));
            if (markDTO.MarkID <= 0)
                throw new ArgumentException("Valid MarkID is required.");

            var mark = MarksMapper.ToEntity(markDTO);
            _marksRepository.UpdateMark(mark);
        }

        public void DeleteMark(int markId)
        {
            if (markId <= 0)
                throw new ArgumentException("Invalid Mark ID");

            _marksRepository.DeleteMark(markId);
        }

        public MarksDTO GetMarkById(int markId)
        {
            if (markId <= 0)
                throw new ArgumentException("Invalid Mark ID");

            var mark = _marksRepository.GetMarkById(markId);
            return MarksMapper.ToDTO(mark);
        }

        public List<MarksDTO> GetAllMarks()
        {
            var marks = _marksRepository.GetAllMarks();
            return MarksMapper.ToDTOList(marks);
        }
    }
}
