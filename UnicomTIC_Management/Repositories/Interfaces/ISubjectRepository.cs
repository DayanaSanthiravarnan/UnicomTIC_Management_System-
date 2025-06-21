using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Repositories.Interfaces
{
   
        internal interface ISubjectRepository
        {
            void AddSubject(Subject subject);
            void UpdateSubject(Subject subject);
            void DeleteSubject(int subjectId);
            Subject GetSubjectById(int subjectId);
            List<Subject> GetAllSubjects();
            List<Subject> GetSubjectsByCourseId(int courseId);
        int CreateSubject(Subject subject);
    }
    
}
