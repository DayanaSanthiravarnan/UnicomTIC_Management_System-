using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface ILecturerService
    {
        int AddLecturer(LecturerDTO lecturerDTO);
        void UpdateLecturer(LecturerDTO lecturerDTO);
        void DeleteLecturer(int lecturerId);
        LecturerDTO GetLecturerById(int lecturerId);
        List<LecturerDTO> GetAllLecturers();
    }
}
