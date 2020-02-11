using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using jk468115MIS4200.DAL;
using jk468115MIS4200.Models;

namespace jk468115MIS4200.Controllers
{
    public class RegistrationsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: Registrations
        public ActionResult Index()
        {
            var registration = db.Registration.Include(r => r.Course).Include(r => r.Student);
            return View(registration.ToList());
        }

        // GET: Registrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registration.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: Registrations/Create
        public ActionResult Create()
        {
            ViewBag.courseID = new SelectList(db.Courses, "courseID", "courseName");
            ViewBag.studentID = new SelectList(db.Students, "studentID", "studentFirstName");
            return View();
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "registrationID,studentID,courseID")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Registration.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.courseID = new SelectList(db.Courses, "courseID", "courseName", registration.courseID);
            ViewBag.studentID = new SelectList(db.Students, "studentID", "studentFirstName", registration.studentID);
            return View(registration);
        }

        // GET: Registrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registration.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseID = new SelectList(db.Courses, "courseID", "courseName", registration.courseID);
            ViewBag.studentID = new SelectList(db.Students, "studentID", "studentFirstName", registration.studentID);
            return View(registration);
        }

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "registrationID,studentID,courseID")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.courseID = new SelectList(db.Courses, "courseID", "courseName", registration.courseID);
            ViewBag.studentID = new SelectList(db.Students, "studentID", "studentFirstName", registration.studentID);
            return View(registration);
        }

        // GET: Registrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registration.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration registration = db.Registration.Find(id);
            db.Registration.Remove(registration);
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
