using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface IRoomService
    {
        void AddRoom(RoomDTO roomDTO);
        void UpdateRoom(RoomDTO roomDTO);
        void DeleteRoom(int roomId);
        RoomDTO GetRoomById(int roomId);
        List<RoomDTO> GetAllRooms();

    }
}
