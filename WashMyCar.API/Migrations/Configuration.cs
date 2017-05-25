namespace WashMyCar.API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WashMyCar.API.Data.WashMyCarDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WashMyCar.API.Data.WashMyCarDataContext context)
        {
            if (context.Customers.Count() == 0)
            {
                for(int i = 0; i < 20; i++)
                {
                    var address = Faker.LocationFaker.StreetNumber() + " " + Faker.LocationFaker.StreetName() + ", " + Faker.LocationFaker.City() + Faker.LocationFaker.ZipCode();
                    context.Customers.Add(new Models.Customer
                    {
                        EmailAddress = Faker.InternetFaker.Email(),
                        FirstName = Faker.NameFaker.FirstName(),
                        LastName = Faker.NameFaker.LastName(),
                        Cellphone = Faker.PhoneFaker.Phone(),
                        Address = address

                    });
                        
                }
                context.SaveChanges();
            }
            if (context.Detailers.Count()== 0)
            {
                for(int i = 0; i < 20; i++)
                {
                    var address = Faker.LocationFaker.StreetNumber() + " " + Faker.LocationFaker.StreetName() + ", " + Faker.LocationFaker.City() + Faker.LocationFaker.ZipCode();
                    context.Detailers.Add(new Models.Detailer
                    {
                        Rating = Faker.NumberFaker.Number(1, 5),
                        FirstName = Faker.NameFaker.FirstName(),
                        LastName = Faker.NameFaker.LastName(),
                        Cellphone = Faker.PhoneFaker.Phone(),
                        Address = address
                    });
                }
                context.SaveChanges();

            }
            if (context.DaysOfWeek.Count()==0)
            {
                string[] weekday = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday","Friday", "Saturday" };
                for(int i= 0; i<weekday.Length; i++)
                {
                    context.DaysOfWeek.Add(new Models.DayOfWeek
                    {
                        Weekday = weekday[i]
                    });
                }
                context.SaveChanges();
            }
            if (context.VehicleTypes.Count() == 0)
            {
                string[] vehicletype = new string[] { "Coupe", "Sedan", "SUV" };
                decimal[] multiplier = new decimal[] { 1, 1.2M, 1.3M  };
                for (int i =0; i<vehicletype.Length; i++)
                {
                    context.VehicleTypes.Add(new Models.VehicleType
                    {
                        VehicleSize = vehicletype[i],
                        Multiplier = multiplier[i]
                    });
                }
                context.SaveChanges();
            }
            if (context.Services.Count() == 0)
            {
                string[] servicetype = new string[] { "Handwash", "Handwax", "Complete Interior", "Complete Exterior", "Steam Clean Interior", "Leather Treatment", "Deluxe Detail", "Light and Rim Restoration" };
                decimal[] cost = new decimal[] { 39.99M, 69.99M, 129.99M, 179.99M, 119.99M, 59.99M, 239.99M };
                for(int i = 0; i < servicetype.Length; i++)
                {
                    context.Services.Add(new Models.Service
                    {
                        ServiceType = servicetype[i],
                        Cost = cost[i]
                    });

                }
                context.SaveChanges();
            }
        }

    }
}
