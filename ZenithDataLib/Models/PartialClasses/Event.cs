using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenithDataLib.Models.CustomValidation;

namespace ZenithDataLib.Models
{
    [MetadataType(typeof(EventMetaData))]
    public partial class Event { }
    class EventMetaData
    {
        [Required]
        [DisplayName("Start Date")]
        public DateTime EventFrom { get; set; }

        [Required]
        [DisplayName("End Date")]
        [StartEndDateValidator]
        public DateTime EventTo { get; set; }

        [DisplayName("Username")]
        public string EnteredBy { get; set; }

        [Required]
        [DisplayName("Activity")]
        [UIHint("ActivityDropDownList")]
        public int ActivityId { get; set; }

        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }


    }
}
