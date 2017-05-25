using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WashMyCar.API.Models
{
    public class Payment
    {
        //scalar properties
        public int PaymentId { get; set; }
        public int AppointmentId { get; set; }
        public decimal AmountReceived { get; set; }

        //navigation properties
        public virtual Appointment Appointment { get; set; }
    }
}