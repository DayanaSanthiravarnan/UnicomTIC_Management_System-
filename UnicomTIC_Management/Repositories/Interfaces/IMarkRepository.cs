using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models;

namespace UnicomTIC_Management.Repositories.Interfaces
{
    internal interface IMarksRepository
    {
        void AddMark(Marks mark);
        void UpdateMark(Marks mark);
        void DeleteMark(int markId);
        Marks GetMarkById(int markId);
        List<Marks> GetAllMarks();
    }
}
