using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ReportDetails
    {
        public int IdEtiqueta { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string IdProducto { get; set; }
        public string Producto { get; set; }
        public double PesoBruto { get; set; }
        public double PesoNeto { get; set; }
        public List<ReportDetails> details { get; set; }
        public void DetallesInv()
        {

            var dao = new ReportsQuerys();
            var result = dao.DatallesInv();

            details = new List<ReportDetails>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var folderResumeModel = new ReportDetails()
                {
                    IdEtiqueta = Convert.ToInt32(rows[1]),
                    FechaRegistro = Convert.ToDateTime(rows[2]),
                    IdProducto = Convert.ToString(rows[4]),
                    Producto = Convert.ToString(rows[12]),
                    PesoBruto = Convert.ToDouble(rows[6]),
                    PesoNeto = Convert.ToDouble(rows[7]),
                    
                };
                details.Add(folderResumeModel);
            }
        }
        public void DetallesEntradas(DateTime fromDate, DateTime toDate)
        {
            var dao = new ReportsQuerys();
            var result = dao.DatallesEntradas(fromDate, toDate);

            details = new List<ReportDetails>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var folderResumeModel = new ReportDetails()
                {
                    IdEtiqueta = Convert.ToInt32(rows[1]),
                    FechaRegistro = Convert.ToDateTime(rows[2]),
                    IdProducto = Convert.ToString(rows[4]),
                    Producto = Convert.ToString(rows[12]),
                    PesoBruto = Convert.ToDouble(rows[6]),
                    PesoNeto = Convert.ToDouble(rows[7]),

                };
                details.Add(folderResumeModel);
            }
        }
        public void DetallesSalidasProceso(DateTime fromDate, DateTime toDate)
        {
            var dao = new ReportsQuerys();
            var result = dao.DatallesSalidasProceso(fromDate, toDate);

            details = new List<ReportDetails>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var folderResumeModel = new ReportDetails()
                {
                    IdEtiqueta = Convert.ToInt32(rows[1]),
                    FechaRegistro = Convert.ToDateTime(rows[2]),
                    IdProducto = Convert.ToString(rows[4]),
                    Producto = Convert.ToString(rows[12]),
                    PesoBruto = Convert.ToDouble(rows[6]),
                    PesoNeto = Convert.ToDouble(rows[7]),

                };
                details.Add(folderResumeModel);
            }
        }
        public void DetallesSalidasProveedores(DateTime fromDate, DateTime toDate)
        {
            var dao = new ReportsQuerys();
            var result = dao.DatallesSalidasProveedores(fromDate, toDate);

            details = new List<ReportDetails>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var folderResumeModel = new ReportDetails()
                {
                    IdEtiqueta = Convert.ToInt32(rows[1]),
                    FechaRegistro = Convert.ToDateTime(rows[2]),
                    IdProducto = Convert.ToString(rows[4]),
                    Producto = Convert.ToString(rows[12]),
                    PesoBruto = Convert.ToDouble(rows[6]),
                    PesoNeto = Convert.ToDouble(rows[7]),

                };
                details.Add(folderResumeModel);
            }
        }
    }
}
