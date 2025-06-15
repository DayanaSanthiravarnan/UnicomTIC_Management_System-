using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface IExamService
    {
        void AddExam(ExamDTO examDTO);
        void UpdateExam(ExamDTO examDTO);
        void DeleteExam(int examId);
        ExamDTO GetExamById(int examId);
        List<ExamDTO> GetAllExams();
    }
}
