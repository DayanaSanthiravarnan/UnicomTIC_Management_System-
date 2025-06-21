using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Services.Interfaces
{
    internal interface INICDetailService
    {
        void AddNIC(NICDetailDTO nicDTO);
        void UpdateNIC(NICDetailDTO nicDTO);
        void MarkNICAsUsed(string nic);
        bool IsNICUsed(string nic);

     
        NICDetailDTO GetByNIC(string nic);

       
        List<NICDetailDTO> GetAllNICs();
    }
}
