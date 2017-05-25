using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WashMyCar.API.Models
{
    public class VehicleType
    {
        //scalar properties
        public int VehicleTypeId { get; set; }
        public string VehicleSize { get; set; }
        public decimal Multiplier { get; set; }

        //navigation properties
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}