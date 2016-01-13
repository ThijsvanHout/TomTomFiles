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
    public class JamsController : Controller
    {
        private JamContext db = new JamContext();

        // GET: Jams
        public ActionResult Index()
        {
            var jams = db.Jams.Include(j => j.Region).Include(j => j.Traject);
            return View(jams.ToList());
        }

        // GET: Jams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jam jam = db.Jams.Find(id);
            if (jam == null)
            {
                return HttpNotFound();
            }
            return View(jam);
        }

        // GET: Jams/Create
        public ActionResult Create()
        {
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName");
            ViewBag.TrajectID = new SelectList(db.Trajects, "ID", "TrajectName");
            return View();
        }

        // POST: Jams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JamID,TrajectID,RegionID,JamText")] Jam jam)
        {
            if (ModelState.IsValid)
            {
                db.Jams.Add(jam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName", jam.RegionID);
            ViewBag.TrajectID = new SelectList(db.Trajects, "ID", "TrajectName", jam.TrajectID);
            return View(jam);
        }

        // GET: Jams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jam jam = db.Jams.Find(id);
            if (jam == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName", jam.RegionID);
            ViewBag.TrajectID = new SelectList(db.Trajects, "ID", "TrajectName", jam.TrajectID);
            return View(jam);
        }

        // POST: Jams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JamID,TrajectID,RegionID,JamText")] Jam jam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName", jam.RegionID);
            ViewBag.TrajectID = new SelectList(db.Trajects, "ID", "TrajectName", jam.TrajectID);
            return View(jam);
        }

        // GET: Jams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jam jam = db.Jams.Find(id);
            if (jam == null)
            {
                return HttpNotFound();
            }
            return View(jam);
        }

        // POST: Jams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jam jam = db.Jams.Find(id);
            db.Jams.Remove(jam);
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
