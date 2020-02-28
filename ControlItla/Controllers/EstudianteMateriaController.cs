using ControlItla.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlDelItla.Controllers
{
    public class EstudianteMateriaController : Controller
    {
        public ControlDelItlaEntities db = new ControlDelItlaEntities();
        public ActionResult Index()
        {
            List<ListaSeleccionarMateria> lista;
            using (ControlDelItlaEntities db = new ControlDelItlaEntities())
            {
                lista = (from l in db.EstudianteAsignatura
                         select new ListaSeleccionarMateria
                         {
                             Id = l.id,
                             IdAsignatura = l.idAsignatura,
                             IdEstudiante = l.idEstudiante,
                             Asignatura = l.Asignatura,
                             Estudiante = l.Estudiante


                         }).ToList();
            }
            return View(lista);

        }
        public ActionResult Crear()
        {

            ViewBag.idAsignatura = new SelectList(db.Asignatura.ToList(), "Id", "Nombre");
            ViewBag.idEstudiante = new SelectList(db.Estudiante.ToList(), "Id", "Nombre");
            return View();

        }
        [HttpPost]
        public ActionResult Crear([Bind(Include = "id,idEstudiante,idAsignatura")] EstudianteAsignatura EstAsign)
        {
            if (ModelState.IsValid)
            {
                db.EstudianteAsignatura.Add(EstAsign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsignatura = new SelectList(db.Asignatura, "Id", "Nombre", EstAsign.idAsignatura);
            ViewBag.idEstudiante = new SelectList(db.Estudiante, "Id", "Nombre", EstAsign.idEstudiante);
            return View(EstAsign);
        }

        public ActionResult Editar(int Id)
        {
            EstudianteAsignatura EstAsign = db.EstudianteAsignatura.Find(Id);
            ViewBag.idAsignatura = new SelectList(db.Asignatura.ToList(), "Id", "Nombre");
            ViewBag.idEstudiante = new SelectList(db.Estudiante.ToList(), "Id", "Nombre");
            return View();

        }
        [HttpPost]
        public ActionResult Editar([Bind(Include = "id,idEstudiante,idAsignatura")] EstudianteAsignatura EstAsign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(EstAsign).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsignatura = new SelectList(db.Asignatura, "Id", "Nombre", EstAsign.idAsignatura);
            ViewBag.idEstudiante = new SelectList(db.Profesor, "Id", "Nombre", EstAsign.idEstudiante);
            return View(EstAsign);
        }
        [HttpGet]
        public ActionResult Borrar(int Id)
        {


            EstudianteAsignatura EstAsign = db.EstudianteAsignatura.Find(Id);
            db.EstudianteAsignatura.Remove(EstAsign);
            db.SaveChanges();

            return Redirect("~/EstudianteMateria/");
        }
    }
}
    