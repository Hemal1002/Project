﻿//asdas

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
    public class CargoesController : Controller
    {
        private ProjectEntities db = new ProjectEntities();

        // GET: Cargoes
        public ActionResult Index(string option, string search)
        {
            if (option == "CType")
            {
                return View(db.Cargoes.Where(x => x.CType == search || search == null).ToList());
            }
            else if (option=="Rate")
            {
                return View(db.Cargoes.Where(x => x.HazPer.ToString() == search || search == null).ToList());
            }
            else if (option=="WeightR")
            {
                return View(db.Cargoes.Where(x => x.WRate.ToString() == search || search == null).ToList());
            }
            else if (option=="DR")
            {
                return View(db.Cargoes.Where(x => x.DRate.ToString() == search || search == null).ToList());
            }
            else
            {
                return View(db.Cargoes.Where(x => x.CargoID.StartsWith(search) || search == null).ToList());
            }
            
            
             
        }

        // GET: Cargoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargoes.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // GET: Cargoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cargoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CargoID,CType,HazPer,WRate,DRate")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Cargoes.Add(cargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargo);
        }

        // GET: Cargoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargoes.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CargoID,CType,HazPer,WRate,DRate")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargo);
        }

        // GET: Cargoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargoes.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cargo cargo = db.Cargoes.Find(id);
            db.Cargoes.Remove(cargo);
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
