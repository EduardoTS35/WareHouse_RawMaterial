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
    public partial class frmReporteInventario : Form
    {
        ReportResume model = new ReportResume();
        ReportDetails detailModel = new ReportDetails();
        public frmReporteInventario()
        {
            InitializeComponent();
        }

        private void frmReporteInventario_Load(object sender, EventArgs e)
        {
            GetResume();
            GetDetails();
            this.reportViewer1.RefreshReport();
        }
        private void GetResume()
        {
            model.ResumenInv();
            ReportResumeBindingSource.DataSource = model.resume;
        }


        private void GetDetails()
        {
            detailModel.DetallesInv();
            ReportDetailsBindingSource.DataSource = detailModel.details;
        }
    }
}
