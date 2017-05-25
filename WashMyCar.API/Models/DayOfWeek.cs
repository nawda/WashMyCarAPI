using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WashMyCar.API.Models
{
    public class DayOfWeek
    {
        //scalar properties
        public int DayOfWeekId { get; set; }
        public string Weekday { get; set; }

        //navigation properties
        public virtual ICollection<DetailerAvailability> DetailersAvailability { get; set; }
    }
}