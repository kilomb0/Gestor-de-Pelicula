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
    public class PeliculaController : Controller
    {
        private CineDBEntities1 db = new CineDBEntities1();

        // GET: Pelicula
        public ActionResult Index()
        {
            var pelicula = db.Pelicula.Include(p => p.Genero);
            return View(pelicula.ToList());
        }

        // GET: Pelicula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Pelicula.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // GET: Pelicula/Create
        public ActionResult Create()
        {
            ViewBag.IdGenero = new SelectList(db.Genero, "IdGenero", "NombreGenero");
            return View();
        }

        // POST: Pelicula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPelicula,IdGenero,NombrePelicula,Anho,UrlPoster")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Pelicula.Add(pelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGenero = new SelectList(db.Genero, "IdGenero", "NombreGenero", pelicula.IdGenero);
            return View(pelicula);
        }

        // GET: Pelicula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Pelicula.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGenero = new SelectList(db.Genero, "IdGenero", "NombreGenero", pelicula.IdGenero);
            return View(pelicula);
        }

        // POST: Pelicula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPelicula,IdGenero,NombrePelicula,Anho,UrlPoster")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGenero = new SelectList(db.Genero, "IdGenero", "NombreGenero", pelicula.IdGenero);
            return View(pelicula);
        }

        // GET: Pelicula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Pelicula.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Pelicula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pelicula pelicula = db.Pelicula.Find(id);
            db.Pelicula.Remove(pelicula);
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
