using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivosFijo.Models
{
    public class EmpleadosViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Departamento { get; set; }
        public string Tipo_Persona { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public bool Estado { get; set; }
   
    }
}