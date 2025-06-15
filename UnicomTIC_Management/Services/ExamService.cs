using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{
    internal class ExamService : IExamService
    {
        private readonly IExamRepository _repository;

        public ExamService(IExamRepository repository)
        {
            _repository = repository;
        }

        public void AddExam(ExamDTO examDTO)
        {
            if (examDTO == null)
                throw new ArgumentNullException(nameof(examDTO));
            if (string.IsNullOrWhiteSpace(examDTO.ExamName))
                throw new ArgumentException("Exam name is required.");
            if (examDTO.SubjectID <= 0)
                throw new ArgumentException("Valid SubjectID is required.");

            var exam = ExamMapper.ToEntity(examDTO);
            _repository.AddExam(exam);
        }

        public void UpdateExam(ExamDTO examDTO)
        {
            if (examDTO == null)
                throw new ArgumentNullException(nameof(examDTO));
            if (examDTO.ExamID <= 0)
                throw new ArgumentException("Valid ExamID is required.");

            var exam = ExamMapper.ToEntity(examDTO);
            _repository.UpdateExam(exam);
        }

        public void DeleteExam(int examId)
        {
            _repository.DeleteExam(examId);
        }

        public ExamDTO GetExamById(int examId)
        {
            var exam = _repository.GetExamById(examId);
            return ExamMapper.ToDTO(exam);
        }

        public List<ExamDTO> GetAllExams()
        {
            var exams = _repository.GetAllExams();
            return ExamMapper.ToDTOList(exams);
        }
    }
}
