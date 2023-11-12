using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHotel.Models;
namespace WebHotel.Controllers
{
    public class DefaultController : Controller
    {
        HotelOnlineEntities _db = new HotelOnlineEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getMenu()
        {
            var v = from t in _db.Menus
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getFooter()
        {
            var v = from t in _db.footers
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getBanner()
        {
            var v = from t in _db.Banners
                    where t.hide == true
                    select t;
            return PartialView(v.FirstOrDefault());
        }
        public ActionResult getBannerSmall()
        {
            var v = from t in _db.Banners
                    where t.hide == true
                    select t;
            return PartialView(v.FirstOrDefault());
        }

        public ActionResult getAbout()
        {
            var v = from t in _db.Abouts
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getRoom()
        {
            var v = (from t in _db.Rooms
                    where t.hide == true
                    orderby t.order ascending
                    select t).Take(6);
            return PartialView(v.ToList());
        }
        public ActionResult getCategory()
        {
            ViewBag.meta = "Phong";
            var v = from t in _db.Caterogies
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getRoomByCaterogy(long id, string metatitle)
        {
            ViewBag.meta = metatitle;
            var v = from t in _db.Rooms
                    where t.idcategory == id && t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getNews()
        {
            var v = (from t in _db.News
                    where t.hide == true
                    orderby t.datebegin ascending
                    select t).Take(3);
            return PartialView(v.ToList());
        }
      

    }
}