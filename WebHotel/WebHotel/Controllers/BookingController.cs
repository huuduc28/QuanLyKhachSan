using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebHotel.Help;
using WebHotel.Models;

namespace WebHotel.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        HotelOnlineEntities _db = new HotelOnlineEntities();
        public ActionResult Index(long id)
        {
             var v = from t in _db.Bookings
                    where t.id == id
                    select t;
            return View(v.FirstOrDefault());
        }
        public ActionResult Detail(long id)
        {
            var v = from t in _db.Rooms
                    where t.id == id
                    select t;
            return View(v.FirstOrDefault());
        }
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                booking.meta = Functions.ConvertToUnSign(booking.nameRoom);
                booking.order = getMaxOder();
                _db.Bookings.Add(booking);
                _db.SaveChanges();
                return RedirectToAction("Index", "Booking", new { id = booking.id });
            }

            return View(booking);
        }
        public ActionResult FindBooking(long num)
        {
            var v = from t in _db.Bookings
                    where t.phone == num.ToString() || t.customerID == num.ToString()
                    select t;
            return PartialView(v.ToList());
        }

        public int getMaxOder()
        {
            var maxOrder = _db.Bookings.Max(c => c.order);
            return maxOrder.HasValue ? maxOrder.Value + 1 : 1;
        }

    }
}