using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace ErpModuloAlmacenMP
{
    public partial class frmReporteProveedoresMP : Form
    {
        ReportResume model = new ReportResume();
        ReportDetails detailModel = new ReportDetails();
        public frmReporteProveedoresMP()
        {
            InitializeComponent();
        }

        private void frmReporteProveedoresMP_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
        private void GetResume()
        {
            model.ResumenSalidasProveedores(dtpFrom.Value, dtpTo.Value);
            ReportResumeBindingSource.DataSource = model.resume;
        }


        private void GetDetails()
        {
            detailModel.DetallesSalidasProveedores(dtpFrom.Value, dtpTo.Value);
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
