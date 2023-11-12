using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebHotel.Models;
using WebHotel.Help;
namespace WebHotel.Areas.admin.Controllers
{
    public class CaterogiesController : Controller
    {
        private HotelOnlineEntities db = new HotelOnlineEntities();

        // GET: admin/Caterogies
        public ActionResult Index()
        {
            return View(db.Caterogies.ToList());
        }

        // GET: admin/Caterogies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caterogy caterogy = db.Caterogies.Find(id);
            if (caterogy == null)
            {
                return HttpNotFound();
            }
            return View(caterogy);
        }

        // GET: admin/Caterogies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Caterogies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,link,meta,hide,order,datebegin")] Caterogy caterogy)
        {
            if (ModelState.IsValid)
            {
                caterogy.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                db.Caterogies.Add(caterogy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caterogy);
        }

        // GET: admin/Caterogies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caterogy caterogy = db.Caterogies.Find(id);
            if (caterogy == null)
            {
                return HttpNotFound();
            }
            return View(caterogy);
        }

        // POST: admin/Caterogies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,link,meta,hide,order,datebegin")] Caterogy caterogy)
        {
            if (ModelState.IsValid)
            {
                caterogy.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                db.Entry(caterogy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caterogy);
        }

        // GET: admin/Caterogies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caterogy caterogy = db.Caterogies.Find(id);
            if (caterogy == null)
            {
                return HttpNotFound();
            }
            return View(caterogy);
        }

        // POST: admin/Caterogies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caterogy caterogy = db.Caterogies.Find(id);
            db.Caterogies.Remove(caterogy);
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
