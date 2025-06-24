using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface ITopPerformerService
    {
        void AddTopPerformer(TopPerformerDTO dto);
        List<TopPerformerDTO> GetTopPerformersByExam(int examId);
    }
}
