using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlItla.Models
{
    public class ListaAsignarProf
    {
        public int Id { get; set; }
        public Nullable<int> IdProfesor { get; set; }
        public Nullable<int> IdAsignatura { get; set; }

        public virtual Asignatura Asignatura { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}