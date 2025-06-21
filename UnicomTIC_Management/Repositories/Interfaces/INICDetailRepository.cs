using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_Management.Models;
using UnicomTIC_Management.Models.DTOs;

namespace UnicomTIC_Management.Repositories.Interfaces
{
    internal interface INICDetailRepository
    {
        void Add(NICDetail nic);
        void Update(NICDetail nic);
        void MarkAsUsed(string nic);
        bool Exists(string nic);
        bool IsUsed(string nic);
        NICDetail GetByNIC(string nic);
        List<NICDetail> GetAll();
    }
}
