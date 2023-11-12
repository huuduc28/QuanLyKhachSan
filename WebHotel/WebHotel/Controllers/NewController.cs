using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHotel.Models;

namespace WebHotel.Controllers
{
    public class NewController : Controller
    {
        HotelOnlineEntities _db = new HotelOnlineEntities();

        // GET: New
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getNews()
        {
            var v = from t in _db.News
                    where t.hide == true
                    orderby t.datebegin ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult Detail(long id)
        {
            var v = from t in _db.News
                    where t.id == id
                    select t;
            return View(v.FirstOrDefault());
        }
    }
}