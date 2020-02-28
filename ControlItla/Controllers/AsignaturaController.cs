using ControlItla.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlItla.Controllers
{
    public class AsignaturaController : Controller
    {
        public ActionResult Index()
        {
            List<TableClassAsig> lista;
            using (ControlDelItlaEntities db = new ControlDelItlaEntities())
            {
                lista = (from l in db.Asignatura
                         select new TableClassAsig
                         {
                             Id = l.Id,
                             Nombre = l.Nombre,
                         }).ToList();
            }

            return View(lista);
        }

        public ActionResult Crear()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Crear(TableClassAsig model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (ControlDelItlaEntities db = new ControlDelItlaEntities())
                    {
                        var tabla = new Asignatura();

                        tabla.Nombre = model.Nombre;
                       

                        db.Asignatura.Add(tabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Asignatura/");
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
            TableClassAsig model = new TableClassAsig();
            using (ControlDelItlaEntities db = new ControlDelItlaEntities())
            {
                var tabla = db.Asignatura.Find(Id);

                model.Nombre = tabla.Nombre;
          
                model.Id = tabla.Id;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(TableClassAsig model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ControlDelItlaEntities db = new ControlDelItlaEntities())
                    {
                        var tabla = db.Asignatura.Find(model.Id);

                        tabla.Nombre = model.Nombre;
                       

                        db.Entry(tabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Asignatura/");
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
                var tabla = db.Asignatura.Find(Id);

                db.Asignatura.Remove(tabla);
                db.SaveChanges();

            }

            return Redirect("~/Asignatura/");

        }

    }
}