using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebHotel.Help;

namespace WebHotel.Areas.admin.Controllers
{
    public class DefaultController : Controller
    {
        // GET: admin/Default
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(string email ,string password)
        {
            //check code
            if (email == "admin@gmail.com" && password == "123456")
            {
                Session["user"] = "Admin";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Sai tên đăng nhập hoặc mật khẩu";
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}