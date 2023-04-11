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
    public partial class frmConfigUsuarios : Form
    {
        UserModel userModel = new UserModel();
        private string IdUsuario = null;
        private bool editarUsuario = false;
        public frmConfigUsuarios()
        {
            InitializeComponent();
        }
        private void frmConfigUsuarios_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        private void MostrarUsuarios()
        {
            dataGridView1.DataSource = userModel.verUsuarios();
            dataGridView1.Columns["contraseña"].Visible = false;
            dataGridView1.Columns["idUsuario"].HeaderText = "Cód. Usuario";
            dataGridView1.Columns["nombre"].HeaderText = "Nombre";
            dataGridView1.Columns["apellido"].HeaderText = "Apellido";
            dataGridView1.Columns["usuario"].HeaderText = "Usuario";
            dataGridView1.Columns["cargo"].HeaderText = "Cargo";
            dataGridView1.Columns["area"].HeaderText = "Area";
        }

        private void LimpiarDatos()
        {
            editarUsuario = false;
            tboxNombre.Text = "";
            tboxApellido.Text = "";
            tboxUsuario.Text = "";
            tboxContraseña.Text = "";
            tboxConfirmarContraseña.Text = "";
            cmbCargo.Text = "";
            cmbArea.Text = "";
            tboxCorreoE.Text = "";
        }

        private void tboxContraseña_Enter(object sender, EventArgs e)
        {
            tboxContraseña.UseSystemPasswordChar = true;
            tboxConfirmarContraseña.UseSystemPasswordChar = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (editarUsuario == false)
            {
                if (tboxNombre.Text != "" && tboxApellido.Text != "" && tboxUsuario.Text != "" && tboxContraseña.Text != "" && cmbCargo.Text != "" && cmbArea.Text != "" && tboxCorreoE.Text != "")
                {
                    if (tboxContraseña.Text == tboxConfirmarContraseña.Text)
                    {
                        try
                        {
                            DialogResult dialogResult = MessageBox.Show("¿Estas seguro de guardar los datos?", "Adveritencia", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                userModel.agregarUsuario(tboxNombre.Text, tboxApellido.Text, tboxUsuario.Text, tboxContraseña.Text, cmbCargo.Text, cmbArea.Text, tboxCorreoE.Text);
                                LimpiarDatos();
                                MostrarUsuarios();
                                MessageBox.Show("Se guardo correctamente el nuevo usuario");
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                            }

                        }
                        catch
                        {
                            MessageBox.Show("Por favor completa todos los campos");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden", "Advertencia");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor completa todos los campos.", "Advertencia");
                }
            }
            if (editarUsuario == true)
            {
                if (tboxNombre.Text != "" && tboxApellido.Text != "" && tboxUsuario.Text != "" && tboxContraseña.Text != "" && cmbCargo.Text != "" && cmbArea.Text != "" && tboxCorreoE.Text != "")

                {
                    if (tboxContraseña.Text == tboxConfirmarContraseña.Text)
                    {
                        try
                        {
                            DialogResult dialogResult = MessageBox.Show("¿Estas seguro de editar los datos?", "Adveritencia", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                userModel.actualizarUsuario( IdUsuario,tboxNombre.Text, tboxApellido.Text, tboxUsuario.Text, tboxContraseña.Text, cmbCargo.Text, cmbArea.Text, tboxCorreoE.Text);
                                editarUsuario = false;
                                IdUsuario = null;
                                LimpiarDatos();
                                MostrarUsuarios();
                                MessageBox.Show("Se actualizo correctamente el usuario");
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Surgio un error: " + ex + "", "Advertencia");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden", "Advertencia");
                    }
                }
                else MessageBox.Show("Por favor complete todos los campos", "Advertencia");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (editarUsuario == true)
            {
                userModel.borrarUsuario(IdUsuario);
                editarUsuario = false;
                IdUsuario = null;
                LimpiarDatos();
                MostrarUsuarios();
                MessageBox.Show("Se eliminó exitosamente el usuario");
            }
            else
            {
                MessageBox.Show("Seleccione un usuario", "Advertencia");
            }
        }

        private void tboxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tboxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tboxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editarUsuario = true;
                IdUsuario = dataGridView1.CurrentRow.Cells["IdUsuario"].Value.ToString();
                tboxNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                tboxApellido.Text = dataGridView1.CurrentRow.Cells["Apellido"].Value.ToString();
                tboxUsuario.Text = dataGridView1.CurrentRow.Cells["Usuario"].Value.ToString();
                cmbCargo.Text = dataGridView1.CurrentRow.Cells["Cargo"].Value.ToString();
                cmbArea.Text = dataGridView1.CurrentRow.Cells["Area"].Value.ToString();
                tboxCorreoE.Text = dataGridView1.CurrentRow.Cells["CorreoE"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un usuario", "Advertencia");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }
    }
}
