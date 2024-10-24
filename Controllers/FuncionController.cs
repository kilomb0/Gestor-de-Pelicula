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
    public class FuncionController : Controller
    {
        private CineDBEntities1 db = new CineDBEntities1();

        // GET: Funcion
        public ActionResult Index()
        {
            return View(db.Funcion.ToList());
        }

        // GET: Funcion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcion funcion = db.Funcion.Find(id);
            if (funcion == null)
            {
                return HttpNotFound();
            }
            return View(funcion);
        }

        // GET: Funcion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFuncion,NombreFuncion")] Funcion funcion)
        {
            if (ModelState.IsValid)
            {
                db.Funcion.Add(funcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(funcion);
        }

        // GET: Funcion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcion funcion = db.Funcion.Find(id);
            if (funcion == null)
            {
                return HttpNotFound();
            }
            return View(funcion);
        }

        // POST: Funcion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFuncion,NombreFuncion")] Funcion funcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcion);
        }

        // GET: Funcion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcion funcion = db.Funcion.Find(id);
            if (funcion == null)
            {
                return HttpNotFound();
            }
            return View(funcion);
        }

        // POST: Funcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcion funcion = db.Funcion.Find(id);
            db.Funcion.Remove(funcion);
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
