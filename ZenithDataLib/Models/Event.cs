
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public DateTime EventFrom { get; set; }
        public DateTime EventTo { get; set; }
        public string EnteredBy { get; set; }
        public int ActivityId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
