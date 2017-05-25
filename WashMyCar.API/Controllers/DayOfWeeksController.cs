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
    public class DayOfWeeksController : ApiController
    {
        private WashMyCarDataContext db = new WashMyCarDataContext();

        // GET: api/DayOfWeeks
        public IHttpActionResult GetDayOfWeeks()
        {
            var resultSet = db.DayOfWeeks.Select(dayOfWeek => new
            {
                dayOfWeek.DayOfWeekId,
                dayOfWeek.Weekday
              
            });
            return Ok(resultSet);
        }
    }
}