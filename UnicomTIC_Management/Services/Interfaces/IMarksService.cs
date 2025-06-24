using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface IMarksService
    {
        void AddMark(MarksDTO markDto);
        void UpdateMark(MarksDTO markDto);
        void DeleteMark(int markId);
        MarksDTO GetMarkById(int markId);
        List<MarksDTO> GetAllMarks();
    }
}
