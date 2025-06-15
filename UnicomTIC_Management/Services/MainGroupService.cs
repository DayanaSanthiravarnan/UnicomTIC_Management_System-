using System;
using System.Collections.Generic;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{
    internal class MainGroupService : IMainGroupService
    {
        private readonly IMainGroupRepository _mainGroupRepository;

        public MainGroupService(IMainGroupRepository mainGroupRepository)
        {
            _mainGroupRepository = mainGroupRepository;
        }

        public void AddMainGroup(MainGroupDTO mainGroupDTO)
        {
            if (mainGroupDTO == null)
                throw new ArgumentNullException(nameof(mainGroupDTO));
            if (string.IsNullOrWhiteSpace(mainGroupDTO.GroupCode))
                throw new ArgumentException("GroupCode is required.");

            var mainGroupEntity = MainGroupMapper.ToEntity(mainGroupDTO);
            _mainGroupRepository.AddMainGroup(mainGroupEntity);
        }

        public void UpdateMainGroup(MainGroupDTO mainGroupDTO)
        {
            if (mainGroupDTO == null)
                throw new ArgumentNullException(nameof(mainGroupDTO));
            if (string.IsNullOrWhiteSpace(mainGroupDTO.GroupCode))
                throw new ArgumentException("GroupCode is required.");

            var mainGroupEntity = MainGroupMapper.ToEntity(mainGroupDTO);
            _mainGroupRepository.UpdateMainGroup(mainGroupEntity);
        }

        public void DeleteMainGroup(int mainGroupId)
        {
            _mainGroupRepository.DeleteMainGroup(mainGroupId);
        }

        public MainGroupDTO GetMainGroupById(int mainGroupId)
        {
            var MainGroup = _mainGroupRepository.GetMainGroupById(mainGroupId);
            return MainGroupMapper.ToDTO(MainGroup);
        }

        public List<MainGroupDTO> GetAllMainGroup()
        {
            var MainGroup = _mainGroupRepository.GetAllMainGroup();
            return MainGroupMapper.ToDTOList(MainGroup);
        }
    }
}
