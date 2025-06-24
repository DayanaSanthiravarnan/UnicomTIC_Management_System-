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
    internal class TopPerformerController
    {
        private readonly ITopPerformerService _service;

        public TopPerformerController(ITopPerformerService service)
        {
            _service = service;
        }

        public void AddTopPerformer(TopPerformerDTO dto)
        {
            try
            {
                _service.AddTopPerformer(dto);
                MessageBox.Show("Top Performer added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public List<TopPerformerDTO> GetTopPerformersByExam(int examId)
        {
            return _service.GetTopPerformersByExam(examId);
        }
    }
}
