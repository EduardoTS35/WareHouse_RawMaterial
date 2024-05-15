using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErpModuloAlmacenMP
{
    public partial class frmReporteMateriaPrima : Form
    {
        ReportResume model = new ReportResume();
        ReportDetails detailModel = new ReportDetails();
        public frmReporteMateriaPrima()
        {
            InitializeComponent();
        }

        private void frmReporteMateriaPrima_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            
        }
        private void GetResume()
        {
            model.ResumenEntradas(dtpFrom.Value, dtpTo.Value);
            ReportResumeBindingSource.DataSource = model.resume;
        }


        private void GetDetails()
        {
            detailModel.DetallesEntradas(dtpFrom.Value, dtpTo.Value);
            ReportDetailsBindingSource.DataSource = detailModel.details;
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            GetResume();
            GetDetails();
            this.reportViewer1.RefreshReport();
        }
    }
}
