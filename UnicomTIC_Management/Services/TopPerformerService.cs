using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{
    internal class TopPerformerService : ITopPerformerService
    {
        private readonly ITopPerformerRepository _repository;

        public TopPerformerService(ITopPerformerRepository repository)
        {
            _repository = repository;
        }

        public void AddTopPerformer(TopPerformerDTO dto)
        {
            var entity = TopPerformerMapper.ToEntity(dto);
            _repository.AddTopPerformer(entity);
        }

        public List<TopPerformerDTO> GetTopPerformersByExam(int examId)
        {
            var list = _repository.GetTopPerformersByExam(examId);
            return TopPerformerMapper.ToDTOList(list);
        }
    }

}
