using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{

    
        internal class SubGroupService : ISubGroupService
        {
            private readonly ISubGroupRepository _repository;
            private readonly IMainGroupRepository _mainGroupRepository; // MainGroup data fetch
        private SubGroupRepository subGroupRepository;

        public SubGroupService(ISubGroupRepository repository, IMainGroupRepository mainGroupRepository)
            {
                _repository = repository;
                _mainGroupRepository = mainGroupRepository;
            }

        public SubGroupService(SubGroupRepository subGroupRepository)
        {
            this.subGroupRepository = subGroupRepository;
        }

        public void AddSubGroup(SubGroupDTO dto)
            {
                if (dto == null) throw new ArgumentNullException(nameof(dto));
                if (string.IsNullOrWhiteSpace(dto.SubGroupName))
                    throw new ArgumentException("SubGroup name is required.");

                var entity = SubGroupMapper.ToEntity(dto);
                _repository.AddSubGroup(entity);
            }

            public void UpdateSubGroup(SubGroupDTO dto)
            {
                if (dto == null) throw new ArgumentNullException(nameof(dto));
                var entity = SubGroupMapper.ToEntity(dto);
                _repository.UpdateSubGroup(entity);
            }

            public void DeleteSubGroup(int id)
            {
                _repository.DeleteSubGroup(id);
            }

            public SubGroupDTO GetSubGroupById(int id)
            {
                var entity = _repository.GetSubGroupById(id);
                string mainGroupName = "";
                if (entity != null)
                {
                    var mainGroup = _mainGroupRepository.GetAllMainGroup().Find(mg => mg.MainGroupID == entity.MainGroupID);
                    if (mainGroup != null)
                        mainGroupName = mainGroup.GroupCode;
                }
                return SubGroupMapper.ToDTO(entity, mainGroupName);
            }

            public List<SubGroupDTO> GetAllSubGroups()
            {
                var entities = _repository.GetAllSubGroups();
                var mainGroups = _mainGroupRepository.GetAllMainGroup();
                var mainGroupNames = mainGroups.ConvertAll(mg => (mg.MainGroupID, mg.GroupCode));
                return SubGroupMapper.ToDTOList(entities, mainGroupNames);
            }

            public List<SubGroupDTO> GetSubGroupsByMainGroupId(int mainGroupId)
            {
                var entities = _repository.GetSubGroupsByMainGroupId(mainGroupId);
                var mainGroup = _mainGroupRepository.GetAllMainGroup().Find(mg => mg.MainGroupID == mainGroupId);
                string mainGroupName = mainGroup?.GroupCode;
                return SubGroupMapper.ToDTOList(entities, new List<(int, string)> { (mainGroupId, mainGroupName) });
            }
        public int CreateSubGroup(SubGroupDTO dto)
        {
            var subGroup = SubGroupMapper.ToEntity(dto); // DTO to entity mapping
            return _repository.CreateSubGroup(subGroup);
        }


    }
}

