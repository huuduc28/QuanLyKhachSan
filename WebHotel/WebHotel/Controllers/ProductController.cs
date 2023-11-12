using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHotel.Models;
namespace WebHotel.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        HotelOnlineEntities _db = new HotelOnlineEntities();
        public ActionResult Index(string meta)
        {
            var v = from t in _db.Caterogies
                    where t.meta== meta
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
    }
}