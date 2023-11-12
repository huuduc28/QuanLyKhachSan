using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHotel.Help;
using WebHotel.Models;

namespace WebHotel.Controllers
{
    public class SeviceController : Controller
    {
        HotelOnlineEntities _db = new HotelOnlineEntities();

        // GET: Sevice
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Review review)
        {
            if (ModelState.IsValid)
            {
                review.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                review.meta = Functions.ConvertToUnSign(review.name);
                review.order = getMaxOder();
                review.hide = true;
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(review);
        }
        public ActionResult getReview()
        {
            var v = from t in _db.Reviews
                    where t.hide == true
                    orderby t.datebegin ascending
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