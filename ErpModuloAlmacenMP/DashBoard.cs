using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commun.Cache;

namespace ErpModuloAlmacenMP
{
    public partial class DashBoard : Form
    {
        bool statusCerrar;
        public DashBoard()
        {
            InitializeComponent();

        }
        private void DashBoard_Load(object sender, EventArgs e)
        {
            loadUserData();
            Restricciones();
            openChildForm(new frmEntrada());
            hideSubMenu();
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)

                activeForm.Close();
            activeForm = childForm;
            childForm.Dock = DockStyle.Fill;
            childForm.TopLevel = false;
            childForm.TopMost = true;
            childForm.FormBorderStyle = FormBorderStyle.None;
            pnlFormloader.Controls.Add(childForm);
            pnlFormloader.Tag = childForm;
            childForm.Show();
        }
        private void hideSubMenu()
        {
            if (pnlSubMenuMP.Visible == true)
                pnlSubMenuMP.Visible = false;
            if (pnlSubMenuConfig.Visible == true)
                pnlSubMenuConfig.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void loadUserData()
        {
            lblName.Text = UserLoginCache.FirstName + " " + UserLoginCache.LastName;
            lblArea.Text = UserLoginCache.Area;
            lblCharge.Text = UserLoginCache.Position;
        }
        private void Restricciones()
        {

        }

        private void btnEntradaMP_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 0)
            {
                openChildForm(new frmEntrada());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSubMenuMateriaP_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenuMP);
        }

        private void btnSalidasMP_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 0)
            {
                openChildForm(new frmSalidas());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigMP_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 0)
            {
                openChildForm(new frmConfigAlmacenMP());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteEMP_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 0)
            {
                openChildForm(new frmReporteMateriaPrima());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteInventarioMP_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 0)
            {
                openChildForm(new frmReporteInventario());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteSMP_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 0)
            {
                openChildForm(new frmReporteTraspasoMP());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReporteProveedorMP_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 0)
            {
                openChildForm(new frmReporteProveedoresMP());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigUsuarios_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 0)
            {
                openChildForm(new frmConfigUsuarios());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigClientes_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 0)
            {
                openChildForm(new frmConfigProveedor());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConfigMateriaPrima_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 0)
            {
                openChildForm(new frmConfigMP());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSubMenuConfig_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenuConfig);
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 0)
            {
                openChildForm(new frmContacto());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            statusCerrar = true;
            if (AppCache.StatusPort == 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de cerrar sesión?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DashBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppCache.StatusPort == 0)
            {
                if (statusCerrar == false)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Estás seguro de cerrar el programa?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                        MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    e.Cancel = false;
            }
        }

        private void DashBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (statusCerrar == false)
            {
                Application.Exit();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

            if (AppCache.StatusPort == 0)
            {
                openChildForm(new frmEntrada());
                hideSubMenu();
            }
            else
                MessageBox.Show("Por favor desconecta la báscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
