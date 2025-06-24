using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Repositories.Interfaces
{
    internal interface ITopPerformerRepository
    {
        void AddTopPerformer(TopPerformer tp);
        List<TopPerformer> GetTopPerformersByExam(int examId);
    }
}
