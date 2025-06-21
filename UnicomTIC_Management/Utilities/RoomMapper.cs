using System.Collections.Generic;
using System.Linq;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Utilities
{
    internal static class RoomMapper
    {
        public static RoomDTO ToDTO(Room room)
        {
            if (room == null) return null;

            return new RoomDTO
            {
                RoomID = room.RoomID,
                RoomName = room.RoomName
            };
        }

        public static Room ToEntity(RoomDTO roomDTO)
        {
            if (roomDTO == null) return null;

            return new Room
            {
                RoomID = roomDTO.RoomID,
                RoomName = roomDTO.RoomName
            };
        }

        public static List<RoomDTO> ToDTOList(IEnumerable<Room> rooms)
        {
            return rooms?.Select(ToDTO).ToList() ?? new List<RoomDTO>();
        }

        public static List<Room> ToEntityList(IEnumerable<RoomDTO> roomDTOs)
        {
            return roomDTOs?.Select(ToEntity).ToList() ?? new List<Room>();
        }
    }
}
