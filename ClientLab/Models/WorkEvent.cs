using System;
using System.Collections.Generic;
using System.Text;

namespace ClientLab.Models
{
    public class WorkEvent
    {
        public DateTime Time { get; set; }

        public string Device { get; set; }

        public string EventType { get; set; }
    }
}