using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WashMyCar.API.Data;
using WashMyCar.API.Models;

namespace WashMyCar.API.Controllers
{
    public class VehicleTypesController : ApiController
    {
        private WashMyCarDataContext db = new WashMyCarDataContext();

        // GET: api/VehicleTypes
        public IHttpActionResult GetVehicleTypes()
        {
            var resultSet = db.VehicleTypes.Select(vehicleType => new
            {
                vehicleType.VehicleTypeId,
                vehicleType.Multiplier,
                vehicleType.VehicleSize
            });
            return Ok(resultSet);
        }

        // GET: api/VehicleTypes/5
        [ResponseType(typeof(VehicleType))]
        public IHttpActionResult GetVehicleType(int id)
        {
            VehicleType vehicleType = db.VehicleTypes.Find(id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                vehicleType.VehicleTypeId,
                vehicleType.Multiplier,
                vehicleType.VehicleSize
            });
        }
    }
}