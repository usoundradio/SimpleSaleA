using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleSale.Models;

namespace SimpleSale.Controllers
{
    public class Default2Controller : Controller
    {
        private SimpleSaleContext db = new SimpleSaleContext();

        //
        // GET: /Default2/

        public ActionResult Index()
        {
            return View(db.Reciepts.ToList());
        }

        //
        // GET: /Default2/Details/5

        public ActionResult Details(int id = 0)
        {
            Reciept reciept = db.Reciepts.Find(id);
            if (reciept == null)
            {
                return HttpNotFound();
            }
            return View(reciept);
        }

        //
        // GET: /Default2/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default2/Create

        [HttpPost]
        public ActionResult Create(Reciept reciept)
        {
            if (ModelState.IsValid)
            {
                db.Reciepts.Add(reciept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reciept);
        }

        //
        // GET: /Default2/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Reciept reciept = db.Reciepts.Find(id);
            if (reciept == null)
            {
                return HttpNotFound();
            }
            return View(reciept);
        }

        //
        // POST: /Default2/Edit/5

        [HttpPost]
        public ActionResult Edit(Reciept reciept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reciept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reciept);
        }

        //
        // GET: /Default2/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Reciept reciept = db.Reciepts.Find(id);
            if (reciept == null)
            {
                return HttpNotFound();
            }
            return View(reciept);
        }

        //
        // POST: /Default2/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Reciept reciept = db.Reciepts.Find(id);
            db.Reciepts.Remove(reciept);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}