using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WashMyCar.API.Models;

namespace WashMyCar.API.Data
{
    public class WashMyCarDataContext : DbContext
    {
        public WashMyCarDataContext() : base("WashMyCar")
        {
         
        }

        public IDbSet<Appointment> Appointments { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Models.DayOfWeek> DaysOfWeek { get; set; }
        public IDbSet<Detailer> Detailers { get; set; }
        public IDbSet<DetailerAvailability> DetailersAvailability { get; set; }
        public IDbSet<Payment> Payments { get; set; }
        public IDbSet<Service> Services { get; set; }
        public IDbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // customer has many sales
            modelBuilder.Entity<Appointment>()
                .HasMany(appointment => appointment.Payments)
                .WithRequired(payment => payment.Appointment)
                .HasForeignKey(payment => payment.AppointmentId);

            modelBuilder.Entity<Appointment>()
              .HasMany(appointment => appointment.AppointmentServices)
              .WithRequired(service => service.Appointment)
              .HasForeignKey(service => service.AppointmentId)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(customer => customer.Appointments)
                .WithRequired(appointment => appointment.Customer)
                .HasForeignKey(appointment => appointment.CustomerId);

            modelBuilder.Entity<Models.DayOfWeek>()
                .HasMany(dayOfWeek => dayOfWeek.DetailersAvailability)
                .WithRequired(detailersAvailability => detailersAvailability.DayOfWeek)
                .HasForeignKey(detailersAvailability => detailersAvailability.DayOfWeekId);

            modelBuilder.Entity<Detailer>()
                .HasMany(detailer => detailer.DetailersAvailability)
                .WithRequired(detailersAvailability => detailersAvailability.Detailer)
                .HasForeignKey(detailersAvailability => detailersAvailability.DetailerId);

            modelBuilder.Entity<Detailer>()
                .HasMany(detailer => detailer.Services)
                .WithRequired(service => service.Detailer)
                .HasForeignKey(service => service.DetailerId);

            modelBuilder.Entity<Detailer>()
                .HasMany(detailer => detailer.Appointments)
                .WithRequired(appointment => appointment.Detailer)
                .HasForeignKey(appointment=> appointment.DetailerId);

            modelBuilder.Entity<VehicleType>()
                .HasMany(vehicleType => vehicleType.Appointments)
                .WithRequired(appointment => appointment.VehicleType)
                .HasForeignKey(appointment => appointment.VehicleTypeId);

            // Configure the compound keys
            modelBuilder.Entity<AppointmentService>()
                        .HasKey(a => new { a.AppointmentId, a.ServiceId });

            modelBuilder.Entity<DetailerAvailability>()
                        .HasKey(a => new { a.DetailerId, a.DayOfWeekId });
        }

        public System.Data.Entity.DbSet<WashMyCar.API.Models.DayOfWeek> DayOfWeeks { get; set; }
    }
}