using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface ISubjectService
    {
        void AddSubject(SubjectDTO subjectDTO);
        void UpdateSubject(SubjectDTO subjectDTO);
        void DeleteSubject(int subjectId);
        SubjectDTO GetSubjectById(int subjectId);
        List<SubjectDTO> GetAllSubjects();
    }
}