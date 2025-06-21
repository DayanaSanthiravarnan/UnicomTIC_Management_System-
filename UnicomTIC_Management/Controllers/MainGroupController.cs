using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Services.Interfaces;

namespace UnicomTIC_Management.Controllers
{
    internal class MainGroupController
    {
        private readonly IMainGroupService _mainGroupService;

        public MainGroupController(IMainGroupService mainGroupService)
        {
            _mainGroupService = mainGroupService;
        }

        public void AddMainGroup(MainGroupDTO mainGroupDTO)
        {
            try
            {
                _mainGroupService.AddMainGroup(mainGroupDTO);
                MessageBox.Show("MainGroup added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding MainGroup: {ex.Message}");
            }
        }

        public void UpdateMainGroup(MainGroupDTO mainGroupDTO)
        {
            try
            {
                _mainGroupService.UpdateMainGroup(mainGroupDTO);
                MessageBox.Show("MainGroup updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating MainGroup: {ex.Message}");
            }
        }

        public void DeleteMainGroup(int mainGroupId)
        {
            try
            {
                _mainGroupService.DeleteMainGroup(mainGroupId);
                MessageBox.Show("MainGroup deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting MainGroup: {ex.Message}");
            }
        }

        public MainGroupDTO GetMainGroupById(int mainGroupId)
        {
            try
            {
                return _mainGroupService.GetMainGroupById(mainGroupId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching MainGroup: {ex.Message}");
                return null;
            }
        }

        public List<MainGroupDTO> GetAllMainGroup()
        {
            try
            {
                return _mainGroupService.GetAllMainGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching MainGroups: {ex.Message}");
                return new List<MainGroupDTO>();
            }
        }

        public int CreateMainGroup(MainGroupDTO dto)
        {
            return _mainGroupService.CreateMainGroup(dto);
        }
    }
}

