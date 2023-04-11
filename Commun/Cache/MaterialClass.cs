using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commun.Cache
{
    public class MaterialClass
    {
        public int idPrimario { get; set; }
        public int idEtiqueta { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int idUsuario { get; set; }
        public string idProducto { get; set; }
        public double tara { get; set; }
        public double pesoBruto { get; set; }
        public double pesoNeto { get; set; }
        public double costo { get; set; }
        public int idStatus { get; set; }
        public Nullable<int> idProveedor { get; set; }
        public Nullable<int> idTraspaso { get; set; }

    }
}
