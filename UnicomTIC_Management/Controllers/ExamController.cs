using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Services.Interfaces;

namespace UnicomTIC_Management.Controllers
{
   
        internal class ExamController
        {
            private readonly IExamService _service;

            public ExamController(IExamService service)
            {
                _service = service;
            }

            public void AddExam(ExamDTO examDTO)
            {
                try
                {
                    _service.AddExam(examDTO);
                    MessageBox.Show("Exam added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding exam: {ex.Message}");
                }
            }

            public void UpdateExam(ExamDTO examDTO)
            {
                try
                {
                    _service.UpdateExam(examDTO);
                    MessageBox.Show("Exam updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating exam: {ex.Message}");
                }
            }

            public void DeleteExam(int examId)
            {
                try
                {
                    _service.DeleteExam(examId);
                    MessageBox.Show("Exam deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting exam: {ex.Message}");
                }
            }

            public ExamDTO GetExamById(int examId)
            {
                return _service.GetExamById(examId);
            }

            public List<ExamDTO> GetAllExams()
            {
                return _service.GetAllExams();
            }
        }

    
}
