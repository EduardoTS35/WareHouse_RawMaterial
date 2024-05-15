
namespace ErpModuloAlmacenMP
{
    partial class frmReporteInventario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReportResumeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReportResumeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Resumen";
            reportDataSource1.Value = this.ReportResumeBindingSource;
            reportDataSource2.Name = "Detalles";
            reportDataSource2.Value = this.ReportDetailsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ErpModuloAlmacenMP.Reports.Inventario.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1148, 800);
            this.reportViewer1.TabIndex = 0;
            // 
            // ReportResumeBindingSource
            // 
            this.ReportResumeBindingSource.DataSource = typeof(Domain.ReportResume);
            // 
            // ReportDetailsBindingSource
            // 
            this.ReportDetailsBindingSource.DataSource = typeof(Domain.ReportDetails);
            // 
            // frmReporteInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(1148, 800);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReporteInventario";
            this.Text = "frmReporteInventario";
            this.Load += new System.EventHandler(this.frmReporteInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportResumeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReportResumeBindingSource;
        private System.Windows.Forms.BindingSource ReportDetailsBindingSource;
    }
}