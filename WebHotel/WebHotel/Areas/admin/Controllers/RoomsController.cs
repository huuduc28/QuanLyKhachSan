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
    public class RoomsController : Controller
    {
        private HotelOnlineEntities db = new HotelOnlineEntities();

        // GET: admin/Rooms
        public ActionResult Index(long? id = null)
        {
            getCategory(id);
            //return View(db.products.ToList());
            return View();
        }
        public void getCategory(long? selectedId = null)
        {
            ViewBag.Category = new SelectList(db.Caterogies.Where(x => x.hide == true)
                .OrderBy(x => x.order), "id", "name", selectedId);
        }
        public ActionResult getRooms(long? id)
        {
            if (id == null)
            {
                var v = db.Rooms.OrderBy(x => x.order).ToList();
                return PartialView(v);
            }
            var m = db.Rooms.Where(x => x.idcategory == id).OrderBy(x => x.order).ToList();
            return PartialView(m);
        }

        // GET: admin/Rooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: admin/Rooms/Create
        public ActionResult Create()
        {
            getCategory();
            return View();
        }

        // POST: admin/Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,name,price,img,content,link,meta,hide,order,datebegin,idcategory")] Room Room, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img.FileName;
                        path = Path.Combine(Server.MapPath("~/Upload/img"), filename);
                        img.SaveAs(path);
                        Room.img = filename; //Lưu ý
                    }
                    else
                    {
                        Room.img = "logo.png";
                    }
                    Room.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    Room.meta = Functions.ConvertToUnSign(Room.meta); //convert Tiếng Việt không dấu
                    Room.order = getMaxOrder(Room.idcategory);
                    db.Rooms.Add(Room);
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                    return RedirectToAction("Index", "Rooms", new { id = Room.idcategory });
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
            return View(Room);
        }

        // GET: admin/Rooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            getCategory(room.idcategory); 
            return View(room);
        }
            
        // POST: admin/Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,price,img,content,link,meta,hide,order,datebegin,idcategory")] Room Room, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                Room temp = db.Rooms.Find(Room.id);
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img.FileName;
                        path = Path.Combine(Server.MapPath("~/Upload/img"), filename);
                        img.SaveAs(path);
                        temp.img = filename; //Lưu ý
                    }
                    temp.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    temp.name = Room.name;
                    temp.price = Room.price;
                    temp.content = Room.content;
                    temp.meta = Functions.ConvertToUnSign(Room.name); //convert Tiếng Việt không dấu
                    temp.hide = Room.hide;
                    temp.order = Room.order;
                    db.Entry(temp).State = EntityState.Modified;
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                    return RedirectToAction("Index", "Rooms", new { id = Room.idcategory });
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

            return View(Room);
        }

        // GET: admin/Rooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: admin/Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
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
        public int getMaxOrder(long? CategoryId)
        {
            if (CategoryId == null)
                return 1;
            return db.Rooms.Where(x => x.idcategory == CategoryId).Count();
        }
    }
}
