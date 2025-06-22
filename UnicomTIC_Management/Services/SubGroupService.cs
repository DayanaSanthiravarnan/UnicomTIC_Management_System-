using System;
using System.Collections.Generic;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{
    internal class SubGroupService : ISubGroupService
    {
        private readonly ISubGroupRepository _subGroupRepository;

        public SubGroupService(ISubGroupRepository subGroupRepository)
        {
            _subGroupRepository = subGroupRepository;
        }

        public int AddSubGroup(SubGroupDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var entity = SubGroupMapper.ToEntity(dto);
            return _subGroupRepository.AddSubGroup(entity);
        }

        public void UpdateSubGroup(SubGroupDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var entity = SubGroupMapper.ToEntity(dto);
            _subGroupRepository.UpdateSubGroup(entity);
        }

        public void DeleteSubGroup(int subGroupId)
        {
            _subGroupRepository.DeleteSubGroup(subGroupId);
        }

        public SubGroupDTO GetSubGroupById(int subGroupId)
        {
            var entity = _subGroupRepository.GetSubGroupById(subGroupId);
            return SubGroupMapper.ToDTO(entity);
        }

        public List<SubGroupDTO> GetAllSubGroups()
        {
            var entities = _subGroupRepository.GetAllSubGroups();
            return SubGroupMapper.ToDTOList(entities);
        }

        public List<SubGroupDTO> GetSubGroupsByMainGroupId(int mainGroupId)
        {
            var entities = _subGroupRepository.GetSubGroupsByMainGroupId(mainGroupId);
            return SubGroupMapper.ToDTOList(entities);
        }
    }
}

