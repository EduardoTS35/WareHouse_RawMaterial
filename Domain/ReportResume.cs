using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ReportResume
    {
        public DateTime reportDate { get; set; }
        public string IdProducto { get; set; }
        public string Producto { get; set; }
        public double PesoBruto { get; set; }
        public double PesoNeto { get; set; }
        public int Pacas { get; set; }
        public List<ReportResume> resume { get; set; }
        public void ResumenInv()
        {
            reportDate = DateTime.Now;

            var dao = new ReportsQuerys();
            var result = dao.ResumenInv();

            resume = new List<ReportResume>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var folderResumeModel = new ReportResume()
                {
                    IdProducto = Convert.ToString(rows[0]),
                    Producto = Convert.ToString(rows[1]),
                    PesoBruto = Convert.ToDouble(rows[2]),
                    PesoNeto = Convert.ToDouble(rows[3]),
                    Pacas = Convert.ToInt32(rows[4]),
                };
                resume.Add(folderResumeModel);
            }
        }
        public void ResumenEntradas(DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;

            var dao = new ReportsQuerys();
            var result = dao.ResumenEntradas(fromDate, toDate);

            resume = new List<ReportResume>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var folderResumeModel = new ReportResume()
                {
                    IdProducto = Convert.ToString(rows[0]),
                    Producto = Convert.ToString(rows[1]),
                    PesoBruto = Convert.ToDouble(rows[2]),
                    PesoNeto = Convert.ToDouble(rows[3]),
                    Pacas = Convert.ToInt32(rows[4]),
                };
                resume.Add(folderResumeModel);
            }
        }
        public void ResumenSalidasProceso(DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;

            var dao = new ReportsQuerys();
            var result = dao.ResumenSalidasProceso(fromDate, toDate);

            resume = new List<ReportResume>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var folderResumeModel = new ReportResume()
                {
                    IdProducto = Convert.ToString(rows[0]),
                    Producto = Convert.ToString(rows[1]),
                    PesoBruto = Convert.ToDouble(rows[2]),
                    PesoNeto = Convert.ToDouble(rows[3]),
                    Pacas = Convert.ToInt32(rows[4]),
                };
                resume.Add(folderResumeModel);
            }
        }
        public void ResumenSalidasProveedores(DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;

            var dao = new ReportsQuerys();
            var result = dao.ResumenSalidasProveedores(fromDate, toDate);

            resume = new List<ReportResume>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var folderResumeModel = new ReportResume()
                {
                    IdProducto = Convert.ToString(rows[0]),
                    Producto = Convert.ToString(rows[1]),
                    PesoBruto = Convert.ToDouble(rows[2]),
                    PesoNeto = Convert.ToDouble(rows[3]),
                    Pacas = Convert.ToInt32(rows[4]),
                };
                resume.Add(folderResumeModel);
            }
        }
    }
}
