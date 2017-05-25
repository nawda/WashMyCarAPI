using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WashMyCar.API.Models
{
    public class Customer : Person  
    {
        //scalar properties
        public int CustomerId { get; set; }


        // navigation properties
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}