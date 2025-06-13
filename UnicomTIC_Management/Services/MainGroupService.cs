using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities;

namespace UnicomTIC_Management.Services
{
    internal class MainGroupService : IMainGroupService
    {
        private readonly IMainGroupService _mainGroupService;
        public MainGroupService(IMainGroupService mainGroupService)
        {
            _mainGroupService = mainGroupService;
        }
        public void AddMainGroup(MainGroupDTO mainGroupDTO)
        {
            if (mainGroupDTO == null)
                throw new ArgumentNullException(nameof(mainGroupDTO));
            if (string.IsNullOrWhiteSpace(mainGroupDTO.GroupCode))
                throw new ArgumentException("GroupCode is requird.");
            var maingroup = MainGroupMapper.ToEntity(mainGroupDTO);
            _mainGroupService.AddMainGroup(maingroup);
        }
        public void UpdateMainGroup(MainGroupDTO MainGroupDTO)
        {
            if (MainGroupDTO == null)
                throw new ArgumentNullException(nameof(MainGroupDTO));
            if (MainGroupDTO == null)
                throw new ArgumentException("GroupCode is requird.");

            var mainGroup = MainGroupMapper.ToEntity(MainGroupDTO);
            _mainGroupService.UpdateMainGroup(mainGroup);
        }
        public void DeleteMainGroup(int MainGroupId)
        {
            _mainGroupService.DeleteMainGroup(MainGroupId);
        }
    }
}
