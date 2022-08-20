using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System;
using DataBaseFirstAppr.Models;

namespace DatabaseFirstAppr.Controllers
{
    public class HomeController : Controller
    {
        MYBUSEntities db = new MYBUSEntities();

        // GET: Bus
        public ActionResult Index()
        {
            var data = db.BusInfoes.ToList();
            return View(data);
        }
        public ActionResult Create()
        {

            return View();

        }
        [HttpPost]

        public ActionResult Create(BusInfo b)
        {
            if (ModelState.IsValid == true)
            {
                db.BusInfoes.Add(b);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Inserted!!')";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert(' Not Inserted!!')";
                }


            }


            return View();
        }



        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BusId,BoardingPoint,TravelDate,Amount,Rating")] BusInfo busInfo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        busInfo.BoardingPoint = (busInfo.BoardingPoint);
        //        db.BusInfoes.Add(busInfo);
        //        db.SaveChanges();


        //        return RedirectToAction("Index");
        //    }
        //    return View();


        //}

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusInfo busInfo = db.BusInfoes.Find(id);
            if (busInfo == null)
            {
                return HttpNotFound();
            }
            return View(busInfo);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusInfo busInfo = db.BusInfoes.Find(id);
            if (busInfo == null)
            {
                return HttpNotFound();
            }
            return View(busInfo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusID,BoardingPoint,TravelDate,Amount,Rating")] BusInfo busInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busInfo);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusInfo busInfo = db.BusInfoes.Find(id);
            if (busInfo == null)
            {
                return HttpNotFound();
            }
            return View(busInfo);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusInfo busInfo = db.BusInfoes.Find(id);
            db.BusInfoes.Remove(busInfo);
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
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}