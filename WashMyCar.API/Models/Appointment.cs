using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WashMyCar.API.Models
{
    public class Appointment 
    {
        //scalar properties
        public int AppointmentId { get; set; }
        public int VehicleTypeId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int CustomerId { get; set; }
        public int DetailerId { get; set; }

        // computed properties
        public decimal TotalCost
        {
            get
            {
                return AppointmentServices.Sum(s => s.Service.Cost);
            }
        }
        public decimal Outstanding
        {
            get
            {
                var totalPaid = Payments.Sum(p => p.AmountReceived);

                return TotalCost - totalPaid;
            }
        }
        public bool HasPaid
        {
            get
            {
                return Outstanding > 0;
            }
        }

        // Navigation Properties
        public virtual VehicleType VehicleType { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Detailer Detailer { get; set; }

        public virtual ICollection<AppointmentService> AppointmentServices { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}