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
    internal class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;

        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }

        public void AddRoom(RoomDTO roomDTO)
        {
            if (roomDTO == null)
                throw new ArgumentNullException(nameof(roomDTO));

            if (string.IsNullOrWhiteSpace(roomDTO.RoomName))
                throw new ArgumentException("Room name is required.");

            var room = RoomMapper.ToEntity(roomDTO);
            _repository.AddRoom(room);
        }

        public void UpdateRoom(RoomDTO roomDTO)
        {
            if (roomDTO == null)
                throw new ArgumentNullException(nameof(roomDTO));

            if (string.IsNullOrWhiteSpace(roomDTO.RoomName))
                throw new ArgumentException("Room name is required.");

            var room = RoomMapper.ToEntity(roomDTO);
            _repository.UpdateRoom(room);
        }

        public void DeleteRoom(int roomId)
        {
            _repository.DeleteRoom(roomId);
        }

        public RoomDTO GetRoomById(int roomId)
        {
            var room = _repository.GetRoomById(roomId);
            return RoomMapper.ToDTO(room);
        }

        public List<RoomDTO> GetAllRooms()
        {
            var rooms = _repository.GetAllRooms();
            return RoomMapper.ToDTOList(rooms);
        }
    }
}
