using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Applabs.Marketing.Demo.Models;

namespace Applabs.Marketing.Demo.Controllers
{
    public class ALSEmployeeController : Controller
    {
        private ApplabEntities db = new ApplabEntities();

        // GET: ALSEmployee
        public ActionResult Index()
        {
            return View(db.ALSEmployees.ToList());
        }

        // GET: ALSEmployee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALSEmployee aLSEmployee = db.ALSEmployees.Find(id);
            if (aLSEmployee == null)
            {
                return HttpNotFound();
            }
            return View(aLSEmployee);
        }

        // GET: ALSEmployee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ALSEmployee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_Id,First_Name,Last_Name,Gender,D_O_B,Technology,Contact_Number,Email_Id,SSN,EAD,Is_Internal_Employee")] ALSEmployee aLSEmployee)
        {
            if (ModelState.IsValid)
            {
                db.ALSEmployees.Add(aLSEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aLSEmployee);
        }

        // GET: ALSEmployee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALSEmployee aLSEmployee = db.ALSEmployees.Find(id);
            if (aLSEmployee == null)
            {
                return HttpNotFound();
            }
            return View(aLSEmployee);
        }

        // POST: ALSEmployee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_Id,First_Name,Last_Name,Gender,D_O_B,Technology,Contact_Number,Email_Id,SSN,EAD,Is_Internal_Employee")] ALSEmployee aLSEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLSEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aLSEmployee);
        }

        // GET: ALSEmployee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALSEmployee aLSEmployee = db.ALSEmployees.Find(id);
            if (aLSEmployee == null)
            {
                return HttpNotFound();
            }
            return View(aLSEmployee);
        }

        // POST: ALSEmployee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALSEmployee aLSEmployee = db.ALSEmployees.Find(id);
            db.ALSEmployees.Remove(aLSEmployee);
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
