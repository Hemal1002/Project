using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppDev_Project.Models;

namespace AppDev_Project.Controllers
{
    public class ServiceHistoriesController : Controller
    {
        private ProjectEntities db = new ProjectEntities();

        // GET: ServiceHistories
        public ActionResult Index()
        {
            var serviceHistories = db.ServiceHistories.Include(s => s.Truck);
            return View(serviceHistories.ToList());
        }

        // GET: ServiceHistories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceHistory serviceHistory = db.ServiceHistories.Find(id);
            if (serviceHistory == null)
            {
                return HttpNotFound();
            }
            return View(serviceHistory);
        }

        // GET: ServiceHistories/Create
        public ActionResult Create()
        {
            ViewBag.TruckID = new SelectList(db.Trucks, "TruckID", "Vin");
            return View();
        }

        // POST: ServiceHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceID,SDate,Engine,PF,Trans,Chassis,cabin,WT,Brakes,Cost,TruckID")] ServiceHistory serviceHistory)
        {
            if (ModelState.IsValid)
            {
                db.ServiceHistories.Add(serviceHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TruckID = new SelectList(db.Trucks, "TruckID", "Vin", serviceHistory.TruckID);
            return View(serviceHistory);
        }

        // GET: ServiceHistories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceHistory serviceHistory = db.ServiceHistories.Find(id);
            if (serviceHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.TruckID = new SelectList(db.Trucks, "TruckID", "Vin", serviceHistory.TruckID);
            return View(serviceHistory);
        }

        // POST: ServiceHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceID,SDate,Engine,PF,Trans,Chassis,cabin,WT,Brakes,Cost,TruckID")] ServiceHistory serviceHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TruckID = new SelectList(db.Trucks, "TruckID", "Vin", serviceHistory.TruckID);
            return View(serviceHistory);
        }

        // GET: ServiceHistories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceHistory serviceHistory = db.ServiceHistories.Find(id);
            if (serviceHistory == null)
            {
                return HttpNotFound();
            }
            return View(serviceHistory);
        }

        // POST: ServiceHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ServiceHistory serviceHistory = db.ServiceHistories.Find(id);
            db.ServiceHistories.Remove(serviceHistory);
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
