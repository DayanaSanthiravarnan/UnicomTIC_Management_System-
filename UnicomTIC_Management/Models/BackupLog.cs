using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models
{
    internal class BackupLog
    {
        public int BackupID {  get; set; }
        public string BackupDate { get; set; }
        public string BackupPath { get; set; }
    }
}
