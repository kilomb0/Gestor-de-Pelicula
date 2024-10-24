using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CineProyecto.Models;

namespace CineProyecto.Controllers
{
    public class SalaController : Controller
    {
        private CineDBEntities1 db = new CineDBEntities1();

        // GET: Sala
        public ActionResult Index()
        {
            return View(db.Sala.ToList());
        }

        // GET: Sala/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sala sala = db.Sala.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // GET: Sala/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sala/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSala,NombreSala,TamañoSala")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                db.Sala.Add(sala);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sala);
        }

        // GET: Sala/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sala sala = db.Sala.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // POST: Sala/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSala,NombreSala,TamañoSala")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sala).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sala);
        }

        // GET: Sala/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sala sala = db.Sala.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // POST: Sala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sala sala = db.Sala.Find(id);
            db.Sala.Remove(sala);
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
