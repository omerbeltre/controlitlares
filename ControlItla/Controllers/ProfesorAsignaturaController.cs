using ControlItla.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ControlDelItla.Controllers
{

    public class ProfesorAsignaturaController : Controller
    {
        public ControlDelItlaEntities db = new ControlDelItlaEntities();
        // GET: ProfesorAsignatura
        public ActionResult Index()
        {
            List<ListaAsignarProf> lista;
            using (ControlDelItlaEntities db = new ControlDelItlaEntities())
            {
                lista = (from l in db.ProfesorAsignatura
                         select new ListaAsignarProf
                         {
                             Id = l.id,
                             IdAsignatura = l.idAsignatura,
                             IdProfesor = l.idProfesor,
                             Asignatura = l.Asignatura,
                             Profesor = l.Profesor


                         }).ToList();
            }
            return View(lista);

        }
        public ActionResult Crear()
        {

            ViewBag.idAsignatura = new SelectList(db.Asignatura.ToList(), "Id", "Nombre");
            ViewBag.idProfesor = new SelectList(db.Profesor.ToList(), "Id", "Nombre");
            return View();

        }
        [HttpPost]
        public ActionResult Crear([Bind(Include = "id,idProfesor,idAsignatura")] ProfesorAsignatura profAsign)
        {
            if (ModelState.IsValid)
            {
                db.ProfesorAsignatura.Add(profAsign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsignatura = new SelectList(db.Asignatura, "Id", "Nombre", profAsign.idAsignatura);
            ViewBag.idProfesor = new SelectList(db.Profesor, "Id", "Nombre", profAsign.idProfesor);
            return View(profAsign);
        }
        public ActionResult Editar(int Id)
        {
            ProfesorAsignatura profAsign = db.ProfesorAsignatura.Find(Id);
            ViewBag.idAsignatura = new SelectList(db.Asignatura.ToList(), "Id", "Nombre");
            ViewBag.idProfesor = new SelectList(db.Profesor.ToList(), "Id", "Nombre");
            return View();

        }
        [HttpPost]
        public ActionResult Editar([Bind(Include = "id,idProfesor,idAsignatura")] ProfesorAsignatura profAsign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profAsign).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsignatura = new SelectList(db.Asignatura, "Id", "Nombre", profAsign.idAsignatura);
            ViewBag.idProfesor = new SelectList(db.Profesor, "Id", "Nombre", profAsign.idProfesor);
            return View(profAsign);
        }
        [HttpGet]
        public ActionResult Borrar(int Id)
        {


            ProfesorAsignatura profAsign = db.ProfesorAsignatura.Find(Id);
            db.ProfesorAsignatura.Remove(profAsign);
            db.SaveChanges();

            return Redirect("~/ProfesorAsignatura/");
        }

    }
}