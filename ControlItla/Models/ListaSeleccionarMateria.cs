using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlItla.Models
{
    public class ListaSeleccionarMateria
    {
        public int Id { get; set; }
        public Nullable<int> IdEstudiante { get; set; }
        public Nullable<int> IdAsignatura { get; set; }

        public virtual Asignatura Asignatura { get; set; }
        public virtual Estudiante Estudiante { get; set; }
    }
}