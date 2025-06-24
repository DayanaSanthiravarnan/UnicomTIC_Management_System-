using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface IMentorService
    {
        int AddMentor(MentorDTO mentorDTO);
        void UpdateMentor(MentorDTO mentorDTO);
        void DeleteMentor(int mentorId);
        MentorDTO GetMentorById(int mentorId);
        List<MentorDTO> GetAllMentors();
        MentorDTO GetMentorByUserId(int userId);

    }
}
