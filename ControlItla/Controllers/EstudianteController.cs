using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlItla.Models;

namespace ControlItla.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        public ActionResult Index()
        {
            List<TableClass> lista;
            using (ControlDelItlaEntities db = new ControlDelItlaEntities())
            {
                lista = (from l in db.Estudiante
                         select new TableClass
                         {
                             Id = l.Id,
                             Nombre = l.Nombre,
                             Apellido = l.Apellido,
                             Matricula = l.Matricula,
                             Fecha_de_Nacimiento = l.Fecha_Nacimiento
                         }).ToList();
            }

            return View(lista);
        }
        public ActionResult Crear()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Crear(TableClass model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (ControlDelItlaEntities db = new ControlDelItlaEntities())
                    {
                        var tabla = new Estudiante();

                        tabla.Nombre = model.Nombre;
                        tabla.Apellido = model.Apellido;
                        tabla.Matricula = model.Matricula;
                        tabla.Fecha_Nacimiento = model.Fecha_de_Nacimiento;

                        db.Estudiante.Add(tabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Estudiante/");
                }

                return View(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ActionResult Editar(int Id)
        {
            EditarTableClass model = new EditarTableClass();
            using (ControlDelItlaEntities db = new ControlDelItlaEntities())
            {
                var tabla = db.Estudiante.Find(Id);

                model.Nombre = tabla.Nombre;
                model.Apellido = tabla.Apellido;
                model.Matricula = tabla.Matricula;
                model.Fecha_de_Nacimiento = tabla.Fecha_Nacimiento;
                model.Id = tabla.Id;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(EditarTableClass model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ControlDelItlaEntities db = new ControlDelItlaEntities())
                    {
                        var tabla = db.Estudiante.Find(model.Id);

                        tabla.Nombre = model.Nombre;
                        tabla.Apellido = model.Apellido;
                        tabla.Matricula = model.Matricula;
                        tabla.Fecha_Nacimiento = model.Fecha_de_Nacimiento;

                        db.Entry(tabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Estudiante/");
                }

                return View(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public ActionResult Borrar(int Id)
        {

            using (ControlDelItlaEntities db = new ControlDelItlaEntities())
            {
                var tabla = db.Estudiante.Find(Id);

                db.Estudiante.Remove(tabla);
                db.SaveChanges();

            }
            
            return Redirect("~/Estudiante/");

        }

    }
}