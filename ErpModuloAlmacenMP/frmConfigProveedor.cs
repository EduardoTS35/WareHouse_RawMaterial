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
    public partial class frmConfigProveedor : Form
    {
        UserModel userModel = new UserModel();
        private bool editarProveedor = false;
        public frmConfigProveedor()
        {
            InitializeComponent();
        }
        private void frmConfigProveedor_Load(object sender, EventArgs e)
        {
            MostrarCatalogo();
        }
        public void MostrarCatalogo()
        {
            dataGridView1.DataSource = userModel.ver_CatalogoProveedores();
            dataGridView1.Columns["idProveedor"].HeaderText = "Proveedor";
            dataGridView1.Columns["proveedor"].HeaderText = "Descripción";
        }
        private void LimpiarDatos()
        {
            tboxId.Text = "";
            tboxDesc.Text = "";
        }
        private void Agregar()
        {
            if (tboxDesc.Text != "")
            {
                try
                {
                    userModel.agregarProveedor(tboxDesc.Text);
                }
                catch
                {
                    MessageBox.Show("Por favor revisa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (editarProveedor == false)
            {
                if (tboxDesc.Text != "")
                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Estas seguro de guardar los datos?", "Adveritencia", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Agregar();
                            LimpiarDatos();
                            MostrarCatalogo();
                            MessageBox.Show("Se guardó correctamente el nuevo proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);                           
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Por favor completa todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (editarProveedor == true)
            {
                if (tboxId.Text != "" && tboxDesc.Text != "")

                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Estas seguro de editar los datos?", "Adveritencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            userModel.actualizarProveedor(Convert.ToInt32(tboxId.Text),tboxDesc.Text);
                            editarProveedor = false;
                            LimpiarDatos();
                            MostrarCatalogo();
                            MessageBox.Show("Se actualizó correctamente el proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Surgio un error: " + ex + "", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editarProveedor = true;
                tboxId.Text = dataGridView1.CurrentRow.Cells["idProveedor"].Value.ToString();
                tboxDesc.Text = dataGridView1.CurrentRow.Cells["proveedor"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (editarProveedor == true)
                {
                    userModel.borrarProveedor(tboxId.Text);
                    MostrarCatalogo();
                    MessageBox.Show("Se borró correctamente el proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarDatos();
                }

            }
            catch
            {

            }
        }
    }
}
