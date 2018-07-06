using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivosFijo.Models
{
    public class Activos_FijosViewModel
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Departamento { get; set; }
        public string Tipos_Activos { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public decimal Valor_Compra { get; set; }
        public decimal Depreciacion_Acumulada { get; set; }
        public DateTime? Periodo { get; set; }
        public int? Monto_Despreciado { get; set; }

    }
}