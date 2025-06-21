using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models
{
    internal class SubGroup
    {
        public int SubGroupID { get; set; }
        public int MainGroupID { get; set; }
        public string MainGroupName { get; set; }
        public string SubGroupName { get; set; }
        public string Description { get; set; }
    }
}
