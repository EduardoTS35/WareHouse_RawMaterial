using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commun.Cache
{
    public class AppCache
    {
        public static double costoActual;

        public static int StatusPort { get; set; }

        //Variables Materia Prima
        public int? idPrimario { get; set; }
        public int? idEtiqueta { get; set; }
        public DateTime? fechaRegistro { get; set; }
        public int? idUsuario { get; set; }
        public string idProducto { get; set; }
        public double? tara { get; set; }
        public double? pesoBruto { get; set; }
        public double? pesoNeto { get; set; }
        public double? costo { get; set; }
        public int? idStatus { get; set; }
        public int? idProveedor { get; set; }
        public int? idTraspaso { get; set; }
    }
}
