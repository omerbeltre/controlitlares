using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlItla.Models
{
    public class EditarTableClass
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Matricula")]
        public string Matricula { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public Nullable<System.DateTime> Fecha_de_Nacimiento { get; set; }
    }
}