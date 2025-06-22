using System;
using System.Collections.Generic;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Utilities
{
    internal static class MentorMapper
    {
        public static MentorDTO ToDTO(Mentor mentor)
        {
            if (mentor == null)
                return null;

            return new MentorDTO
            {
                MentorID = mentor.MentorID,
                UserID = mentor.UserID,
                Name = mentor.Name,
                NIC = mentor.NIC,
                Email = mentor.Email,
                Phone = mentor.Phone,
                DepartmentID = mentor.DepartmentID
            };
        }

        public static Mentor ToEntity(MentorDTO dto)
        {
            if (dto == null)
                return null;

            return new Mentor
            {
                MentorID = dto.MentorID,
                UserID = dto.UserID,
                Name = dto.Name,
                NIC = dto.NIC,
                Email = dto.Email,
                Phone = dto.Phone,
                DepartmentID = dto.DepartmentID
            };
        }

        public static List<MentorDTO> ToDTOList(List<Mentor> mentors)
        {
            if (mentors == null)
                return null;

            var list = new List<MentorDTO>();
            foreach (var mentor in mentors)
                list.Add(ToDTO(mentor));
            return list;
        }
    }
}
