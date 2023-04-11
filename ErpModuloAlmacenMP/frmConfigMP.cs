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
    public partial class frmConfigMP : Form
    {
        UserModel userModel = new UserModel();
        private bool editarMaterial = false;
        string idMaterial;  
        public frmConfigMP()
        {
            InitializeComponent();
        }
        public void MostrarCatalogo()
        {
            dataGridView1.DataSource = userModel.ver_CatalogoMP();
            dataGridView1.Columns["idProducto"].HeaderText = "Cód. Producto";
            dataGridView1.Columns["producto"].HeaderText = "Producto";
            dataGridView1.Columns["costo"].HeaderText = "Costo";
        }
        private void LimpiarDatos()
        {
            tboxId.Text = "";
            tboxDesc.Text = "";
            tboxCosto.Text = "";
        }
        private void Agregar()
        {
            if (tboxId.Text != "" & tboxDesc.Text != "" & tboxCosto.Text != "")
            {
                try
                {
                    userModel.agregarMateria(tboxId.Text, tboxDesc.Text, Convert.ToDouble(tboxCosto.Text));
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
            if (editarMaterial == false)
            {
                if (tboxId.Text != "" & tboxDesc.Text != "" & tboxCosto.Text != "")
                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Estas seguro de guardar los datos?", "Adveritencia", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Agregar();
                            LimpiarDatos();
                            MostrarCatalogo();
                            MessageBox.Show("Se guardo correctamente el nuevo material", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (editarMaterial == true)
            {
                if (tboxId.Text != "" && tboxDesc.Text != "" && tboxCosto.Text != "")

                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Estas seguro de editar los datos?", "Adveritencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            userModel.actualizarMateria(idMaterial, tboxId.Text, tboxDesc.Text, Convert.ToDouble(tboxCosto.Text));
                            editarMaterial = false;
                            idMaterial = null;
                            LimpiarDatos();
                            MostrarCatalogo();
                            MessageBox.Show("Se actualizó correctamente el material", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                editarMaterial = true;
                idMaterial = dataGridView1.CurrentRow.Cells["IdProducto"].Value.ToString();
                tboxId.Text = dataGridView1.CurrentRow.Cells["IdProducto"].Value.ToString();
                tboxDesc.Text = dataGridView1.CurrentRow.Cells["Producto"].Value.ToString();
                tboxCosto.Text = dataGridView1.CurrentRow.Cells["Costo"].Value.ToString();
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
                if (editarMaterial == true)
                {
                    userModel.borrarMaterial(tboxId.Text);
                    MostrarCatalogo();
                    MessageBox.Show("Se borró correctamente el material", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch
            {

            }
        }

        private void frmConfigMP_Load(object sender, EventArgs e)
        {
            MostrarCatalogo();
        }
    }
}
