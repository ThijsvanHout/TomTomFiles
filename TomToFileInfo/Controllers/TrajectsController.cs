using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TomToFileInfo.DAL;
using TomToFileInfo.Models;

namespace TomToFileInfo.Controllers
{
    public class TrajectsController : Controller
    {
        private JamContext db = new JamContext();

        // GET: Trajects
        public ActionResult Index()
        {
            return View(db.Trajects.ToList());
        }

        // GET: Trajects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traject traject = db.Trajects.Find(id);
            if (traject == null)
            {
                return HttpNotFound();
            }
            return View(traject);
        }

        // GET: Trajects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trajects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TrajectName,JamDateTime")] Traject traject)
        {
            if (ModelState.IsValid)
            {
                db.Trajects.Add(traject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(traject);
        }

        // GET: Trajects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traject traject = db.Trajects.Find(id);
            if (traject == null)
            {
                return HttpNotFound();
            }
            return View(traject);
        }

        // POST: Trajects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TrajectName,JamDateTime")] Traject traject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(traject);
        }

        // GET: Trajects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traject traject = db.Trajects.Find(id);
            if (traject == null)
            {
                return HttpNotFound();
            }
            return View(traject);
        }

        // POST: Trajects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Traject traject = db.Trajects.Find(id);
            db.Trajects.Remove(traject);
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
