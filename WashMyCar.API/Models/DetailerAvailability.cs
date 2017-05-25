using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WashMyCar.API.Models
{
    public class DetailerAvailability
    {
        //scalar properties
        #region Compound Key
        public int DetailerId { get; set; }
        public int DayOfWeekId { get; set; }
        #endregion
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public decimal Multiplier { get; set; }

        //Navigation Properties
        public virtual Detailer Detailer { get; set; }
        public virtual DayOfWeek  DayOfWeek { get; set; }
    }
}