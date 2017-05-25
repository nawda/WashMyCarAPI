using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WashMyCar.API.Models
{
    public class AppointmentService
    {
        // scalar properties
        public int AppointmentId { get; set; }
        public int ServiceId { get; set; }

        // navigation properties
        public virtual Appointment Appointment { get; set; }
        public virtual Service Service { get; set; }
    }
}