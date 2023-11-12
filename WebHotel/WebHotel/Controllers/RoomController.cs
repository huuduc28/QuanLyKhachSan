using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHotel.Models;
namespace WebHotel.Controllers
{
    public class RoomController : Controller
    {
        HotelOnlineEntities _db = new HotelOnlineEntities();
        // GET: Room
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getRoom()
        {
            var v = from t in _db.Rooms
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getReview()
        {
            var v = from t in _db.Rooms
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
    }
}