using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WashMyCar.API.Models
{
    public class Detailer : Person
    {
        //Scalar Properties
        public int DetailerId { get; set; }
        public decimal Rating { get; set; }

        //Navigation Properties
        public virtual ICollection<DetailerAvailability> DetailersAvailability { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}