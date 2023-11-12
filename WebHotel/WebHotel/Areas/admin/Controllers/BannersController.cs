using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebHotel.Help;
using WebHotel.Models;

namespace WebHotel.Areas.admin.Controllers
{
    public class BannersController : Controller
    {
        private HotelOnlineEntities db = new HotelOnlineEntities();

        // GET: admin/Banners
        public ActionResult Index()
        {
            return View(db.Banners.ToList());
        }

        // GET: admin/Banners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // GET: admin/Banners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Banners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,title,img1,img2,img3,link,meta,hide,order,datebegin")] Banner banner)
        {
            if (ModelState.IsValid)
            {
                db.Banners.Add(banner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banner);
        }

        // GET: admin/Banners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: admin/Banners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,title,img1,img2,img3,link,meta,hide,order,datebegin")] Banner banner, HttpPostedFileBase img1, HttpPostedFileBase img2, HttpPostedFileBase img3)
        {
            try
            {
                var path1 = "";
                var path2 = "";
                var path3 = "";

                var filename1 = "";
                var filename2 = "";
                var filename3 = "";
                Banner temp = db.Banners.Find(banner.id);
                if (ModelState.IsValid)
                {
                    if (img1 != null)
                    {
                        filename1 = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img1.FileName;
                        path1 = Path.Combine(Server.MapPath("~/Upload/img"), filename1);
                        img1.SaveAs(path1);
                        temp.img1 = filename1;
                    }
                    else
                    if (img2 != null)
                    {
                        filename2 = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img2.FileName;
                        path2 = Path.Combine(Server.MapPath("~/Upload/img"), filename2);
                        img2.SaveAs(path2);
                        temp.img2 = filename2;
                    }
                    else
                    if (img3 != null)
                    {
                        filename3 = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img3.FileName;
                        path3 = Path.Combine(Server.MapPath("~/Upload/img"), filename3);
                        img3.SaveAs(path3);
                        temp.img3 = filename3;
                    }
                    temp.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    temp.meta = Functions.ConvertToUnSign(banner.name); //convert Tiếng Việt không dấu
                    db.Entry(temp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(banner);
        }
       

        // GET: admin/Banners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: admin/Banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banner banner = db.Banners.Find(id);
            db.Banners.Remove(banner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
