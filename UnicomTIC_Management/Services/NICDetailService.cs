using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Utilities.UnicomTIC_Management.Mappers;

namespace UnicomTIC_Management.Services
{
    public class NICDetailService : INICDetailService
    {
        private readonly INICDetailRepository _repository;

        internal NICDetailService(INICDetailRepository repository)
        {
            _repository = repository;
        }

        public void AddNIC(NICDetailDTO nicDTO)
        {

            if (nicDTO == null)
                throw new ArgumentNullException(nameof(nicDTO));

            if (string.IsNullOrWhiteSpace(nicDTO.NIC))
                throw new ArgumentException("NIC is required.");

            if (!_repository.Exists(nicDTO.NIC))
            {
                var nicEntity = NICDetailMapper.ToEntity(nicDTO);
                _repository.Add(nicEntity);
            }
            else
            {
                throw new InvalidOperationException("NIC already exists.");
            }
        }

        public void UpdateNIC(NICDetailDTO nicDTO)
        {
            if (nicDTO == null)
                throw new ArgumentNullException(nameof(nicDTO));
            if (string.IsNullOrWhiteSpace(nicDTO.NIC))
                throw new ArgumentException("NIC is required.");

            if (_repository.Exists(nicDTO.NIC))
            {
                var nic = NICDetailMapper.ToEntity(nicDTO);
                _repository.Update(nic);
            }
            else
            {
                throw new InvalidOperationException("NIC not found.");
            }
        }

        public void MarkNICAsUsed(string nic)
        {
            if (string.IsNullOrWhiteSpace(nic))
                throw new ArgumentException("NIC is required.");

            if (_repository.Exists(nic))
            {
                _repository.MarkAsUsed(nic);
            }
            else
            {
                throw new InvalidOperationException("NIC not found.");
            }
        }

        public bool IsNICUsed(string nic)
        {
            if (string.IsNullOrWhiteSpace(nic))
                throw new ArgumentException("NIC is required.");

            if (!_repository.Exists(nic))
                return false;

            return _repository.IsUsed(nic);
        }

        public List<NICDetailDTO> GetAllNICs()
        {
            var nicList = _repository.GetAll();
            return NICDetailMapper.ToDTOList(nicList);
        }

        // 🔁 CHANGED: This method name was 'GetNICById' earlier
        public NICDetailDTO GetByNIC(string nic)
        {
            if (string.IsNullOrWhiteSpace(nic))
                throw new ArgumentException("NIC is required.");

            var entity = _repository.GetByNIC(nic);
            return NICDetailMapper.ToDTO(entity);
        }
    }
}
