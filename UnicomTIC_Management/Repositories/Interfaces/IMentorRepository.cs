using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Repositories.Interfaces
{
    internal interface IMentorRepository
    {
        int CreateMentor(Mentor mentor);
        void UpdateMentor(Mentor mentor);
        void DeleteMentor(int mentorId);
        Mentor GetMentorById(int mentorId);
        List<Mentor> GetAllMentors();
    }
}
