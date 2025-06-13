using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Models
{
    internal class Notification
    {
        public  int NotificationID {  get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string SentTo { get; set; }
        public string SentAt { get; set; }


    }
}
