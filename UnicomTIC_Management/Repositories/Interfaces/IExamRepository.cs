using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Repositories.Interfaces
{
    internal interface IExamRepository
    {
        void AddExam(Exam exam);
        void UpdateExam(Exam exam);
        void DeleteExam(int examId);
        Exam GetExamById(int examId);
        List<Exam> GetAllExams();
        
    }
}
