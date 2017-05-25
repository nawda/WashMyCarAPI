using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WashMyCar.API.Models
{
    public class Service
    {
        //scalar properties
        public int ServiceId { get; set; }
        public int DetailerId { get; set; }
        public string ServiceType { get; set; }
        public decimal Cost { get; set; }

        //navigation properties
        public virtual Detailer Detailer { get; set; }
        public virtual ICollection<AppointmentService> AppointmentServices { get; set; }
    }
}