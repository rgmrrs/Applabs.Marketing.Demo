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
    public class ALSMarketingController : Controller
    {
        private ApplabEntities db = new ApplabEntities();

        // GET: ALSMarketing
        public ActionResult Index()
        {
            return View(db.ALSMarketings.ToList());
        }

        // GET: ALSMarketing/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALSMarketing aLSMarketing = db.ALSMarketings.Find(id);
            if (aLSMarketing == null)
            {
                return HttpNotFound();
            }
            return View(aLSMarketing);
        }

        // GET: ALSMarketing/Create
        public ActionResult Create()
        {
           ViewBag.Marketing_Id = new SelectList(db.ALSEmployees, "Employee_Id", "First_Name");
           ALSMarketing Marketer = new ALSMarketing();
           Marketer.RK = db.ALSEmployees.Where(P => P.Is_Internal_Employee == false).ToList();
           Marketer.PRK = db.ALSEmployees.Where(P => P.Is_Internal_Employee == true).ToList();
           return View(Marketer);
            
        }

        // POST: ALSMarketing/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee,Marketer,Date,Status")] ALSMarketing aLSMarketing, FormCollection frm)
         {
            aLSMarketing.Employee = frm["RK"].ToString();
            aLSMarketing.Marketer = frm["PRK"].ToString();


            if (ModelState.IsValid)
              {
                  db.ALSMarketings.Add(aLSMarketing);
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }

            return View(aLSMarketing);
        }
       
        // GET: ALSMarketing/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALSMarketing aLSMarketing = db.ALSMarketings.Find(id);
            if (aLSMarketing == null)
            {
                return HttpNotFound();
            }
            return View(aLSMarketing);
        }

        // POST: ALSMarketing/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Marketing_Id,Employee,Marketer,Date,Status")] ALSMarketing aLSMarketing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLSMarketing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aLSMarketing);
        }

        // GET: ALSMarketing/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALSMarketing aLSMarketing = db.ALSMarketings.Find(id);
            if (aLSMarketing == null)
            {
                return HttpNotFound();
            }
            return View(aLSMarketing);
        }

        // POST: ALSMarketing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALSMarketing aLSMarketing = db.ALSMarketings.Find(id);
            db.ALSMarketings.Remove(aLSMarketing);
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
