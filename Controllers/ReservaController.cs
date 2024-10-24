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
    public class ReservaController : Controller
    {
        private CineDBEntities1 db = new CineDBEntities1();

        // GET: Reserva
        public ActionResult Index()
        {
            var reserva = db.Reserva.Include(r => r.Cliente).Include(r => r.Funcion).Include(r => r.Horario).Include(r => r.Pelicula).Include(r => r.Sala);
            return View(reserva.ToList());
        }

        // GET: Reserva/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: Reserva/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NombreCliente");
            ViewBag.IdFuncion = new SelectList(db.Funcion, "IdFuncion", "NombreFuncion");
            ViewBag.IdHorario = new SelectList(db.Horario, "IdHorario", "Inicio");
            ViewBag.IdPelicula = new SelectList(db.Pelicula, "IdPelicula", "NombrePelicula");
            ViewBag.IdSala = new SelectList(db.Sala, "IdSala", "NombreSala");
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReserva,IdPelicula,IdCliente,IdSala,IdHorario,IdFuncion")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Reserva.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NombreCliente", reserva.IdCliente);
            ViewBag.IdFuncion = new SelectList(db.Funcion, "IdFuncion", "NombreFuncion", reserva.IdFuncion);
            ViewBag.IdHorario = new SelectList(db.Horario, "IdHorario", "Inicio", reserva.IdHorario);
            ViewBag.IdPelicula = new SelectList(db.Pelicula, "IdPelicula", "NombrePelicula", reserva.IdPelicula);
            ViewBag.IdSala = new SelectList(db.Sala, "IdSala", "NombreSala", reserva.IdSala);
            return View(reserva);
        }

        // GET: Reserva/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NombreCliente", reserva.IdCliente);
            ViewBag.IdFuncion = new SelectList(db.Funcion, "IdFuncion", "NombreFuncion", reserva.IdFuncion);
            ViewBag.IdHorario = new SelectList(db.Horario, "IdHorario", "Inicio", reserva.IdHorario);
            ViewBag.IdPelicula = new SelectList(db.Pelicula, "IdPelicula", "NombrePelicula", reserva.IdPelicula);
            ViewBag.IdSala = new SelectList(db.Sala, "IdSala", "NombreSala", reserva.IdSala);
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReserva,IdPelicula,IdCliente,IdSala,IdHorario,IdFuncion")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NombreCliente", reserva.IdCliente);
            ViewBag.IdFuncion = new SelectList(db.Funcion, "IdFuncion", "NombreFuncion", reserva.IdFuncion);
            ViewBag.IdHorario = new SelectList(db.Horario, "IdHorario", "Inicio", reserva.IdHorario);
            ViewBag.IdPelicula = new SelectList(db.Pelicula, "IdPelicula", "NombrePelicula", reserva.IdPelicula);
            ViewBag.IdSala = new SelectList(db.Sala, "IdSala", "NombreSala", reserva.IdSala);
            return View(reserva);
        }

        // GET: Reserva/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserva reserva = db.Reserva.Find(id);
            db.Reserva.Remove(reserva);
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
