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
using Commun.Cache;

namespace ErpModuloAlmacenMP
{
    public partial class frmSalidas : Form
    {
        UserModel userModel = new UserModel();
        List<MaterialClass> data = new List<MaterialClass>();
        AppCache v = new AppCache();
        int statusSalida;
        public frmSalidas()
        {
            InitializeComponent();
        }

        private void frmSalidas_Load(object sender, EventArgs e)
        {
            MostrarSalidas();
        }
        private void MostrarSalidas()
        {
            data = (from DataRow dr in userModel.ver_Datos().Rows
                    select new MaterialClass()
                    {
                        idPrimario = Convert.ToInt32(dr["idPrimario"]),
                        idEtiqueta = Convert.ToInt32(dr["idEtiqueta"]),
                        fechaRegistro = Convert.ToDateTime(dr["fechaRegistro"]),
                        idUsuario = Convert.ToInt32(dr["idUsuario"]),
                        idProducto = Convert.ToString(dr["idProducto"]),
                        tara = Convert.ToDouble(dr["tara"]),
                        pesoBruto = Convert.ToDouble(dr["pesoBruto"]),
                        pesoNeto = Convert.ToDouble(dr["pesoNeto"]),
                        costo = Convert.ToDouble(dr["costo"]),
                        idStatus = Convert.ToInt32(dr["idStatus"]),
                        idProveedor = Convert.ToInt32(dr["idProveedor"]),
                        idTraspaso = Convert.ToInt32(dr["idTraspaso"])
                    }).ToList();

            var filtroSalidas = (from d in data
                                where d.idStatus >= 2 && d.idStatus<=3
                                select d).ToList();
            dgvSalidas.DataSource = filtroSalidas;
            dgvSalidas.Columns["idPrimario"].Visible = false;
            dgvSalidas.Columns["costo"].Visible = false;
            dgvSalidas.Columns["idUsuario"].Visible = false;
            dgvSalidas.Columns["idStatus"].Visible = false;
            dgvSalidas.Columns["idProveedor"].Visible = false;
            dgvSalidas.Columns["idTraspaso"].Visible = false;

            dgvSalidas.Columns["idEtiqueta"].HeaderText = "Núm.Etiqueta";
            dgvSalidas.Columns["fechaRegistro"].HeaderText = "Fecha de Registro";
            dgvSalidas.Columns["idProducto"].HeaderText = "Cód.Producto";
            dgvSalidas.Columns["tara"].HeaderText = "Tara";
            dgvSalidas.Columns["pesoBruto"].HeaderText = "Peso Bruto";
            dgvSalidas.Columns["pesoNeto"].HeaderText = "Peso Neto";
        }

        private void MostrarDatosCombo()
        {
            if (checkBox1.Checked == true)
            {
                cmbTraspaso.DataSource= userModel.ver_CatalogoProveedores();
                cmbTraspaso.DisplayMember = "proveedor";
                cmbTraspaso.ValueMember = "idProveedor";
            }else if(checkBox2.Checked==true){
                cmbTraspaso.DataSource = userModel.ver_CatalogoTraspaso();
                cmbTraspaso.DisplayMember = "descripcion";
                cmbTraspaso.ValueMember = "idTraspaso";
            }
        }
        private void MostrarMaterial(int id)
        {
            data = (from DataRow dr in userModel.ver_Datos(1).Rows
                    select new MaterialClass()
                    {
                        idPrimario = Convert.ToInt32(dr["idPrimario"]),
                        idEtiqueta = Convert.ToInt32(dr["idEtiqueta"]),
                        fechaRegistro = Convert.ToDateTime(dr["fechaRegistro"]),
                        idUsuario = Convert.ToInt32(dr["idUsuario"]),
                        idProducto = Convert.ToString(dr["idProducto"]),
                        tara = Convert.ToDouble(dr["tara"]),
                        pesoBruto = Convert.ToDouble(dr["pesoBruto"]),
                        pesoNeto = Convert.ToDouble(dr["pesoNeto"]),
                        costo = Convert.ToDouble(dr["costo"]),
                        idStatus = Convert.ToInt32(dr["idStatus"]),
                        idProveedor = Convert.ToInt32(dr["idProveedor"]),
                        idTraspaso = Convert.ToInt32(dr["idTraspaso"])
                    }).ToList();
            var idEti = (from d in data
                        where d.idEtiqueta == id 
                        && d.idStatus==1
                        select d).ToList();

            dgvSeleccion.DataSource = idEti;
            dgvSeleccion.Columns["idPrimario"].Visible = false;
            dgvSeleccion.Columns["costo"].Visible = false;
            dgvSeleccion.Columns["idUsuario"].Visible = false;
            dgvSeleccion.Columns["idStatus"].Visible = false;
            dgvSeleccion.Columns["idProveedor"].Visible = false;
            dgvSeleccion.Columns["idTraspaso"].Visible = false;

            dgvSeleccion.Columns["idEtiqueta"].HeaderText = "Núm.Etiqueta";
            dgvSeleccion.Columns["fechaRegistro"].HeaderText = "Fecha de Registro";
            dgvSeleccion.Columns["idProducto"].HeaderText = "Cód.Producto";
            dgvSeleccion.Columns["tara"].HeaderText = "Tara";
            dgvSeleccion.Columns["pesoBruto"].HeaderText = "Peso Bruto";
            dgvSeleccion.Columns["pesoNeto"].HeaderText = "Peso Neto";
        }
        private void LeerDatos()
        {
            try
            {
                DataGridViewRow row = dgvSeleccion.Rows[0];

                v.idPrimario = Convert.ToInt32(row.Cells["idPrimario"].Value);
                v.idEtiqueta = Convert.ToInt32(row.Cells["idEtiqueta"].Value);
                v.fechaRegistro = Convert.ToDateTime(row.Cells["fechaRegistro"].Value);
                v.idProducto = Convert.ToString(row.Cells["idProducto"].Value);
                v.tara = Convert.ToDouble(row.Cells["tara"].Value);
                v.pesoBruto = Convert.ToDouble(row.Cells["pesoBruto"].Value);
                v.pesoNeto = Convert.ToDouble(row.Cells["pesoNeto"].Value);
                v.costo = Convert.ToDouble(row.Cells["costo"].Value);
                v.idStatus = Convert.ToInt32(row.Cells["idStatus"].Value);
                v.idProveedor = Convert.ToInt32(row.Cells["idProveedor"].Value);
                v.idTraspaso = Convert.ToInt32(row.Cells["idTraspaso"].Value);
            }
            catch
            {

            }

        }
        private void InsertarDatos()
        {
            if (checkBox2.Checked == true)
            {
                userModel.insertarSalidas((int)v.idEtiqueta, UserLoginCache.Id, v.idProducto, (int)v.tara, (int)v.pesoBruto, (int)v.pesoNeto, (int)v.costo, statusSalida, (int)v.idProveedor, (int)cmbTraspaso.SelectedValue);
            }
            else if (checkBox1.Checked == true)
            {
                userModel.insertarSalidas((int)v.idEtiqueta, UserLoginCache.Id, v.idProducto, (int)v.tara, (int)v.pesoBruto, (int)v.pesoNeto, (int)v.costo, statusSalida, (int)cmbTraspaso.SelectedValue, 2);
            }
            v.idStatus = null;
            v.idProducto = null;
            v.tara = null;
            v.pesoBruto = null;
            v.pesoNeto = null;
            v.costo = null;
            v.idProveedor = null;
        }
        private void LeerMultiLine()
        {
            foreach (var row in tboxID.Lines)
            {
                try
                {
                    MostrarMaterial(Convert.ToInt32(row));
                    LeerDatos();
                    InsertarDatos();
                }
                catch
                {
                    MessageBox.Show("La Bolsa número: " + row + " no se encontró", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox2.Checked = false;                
                statusSalida = 2;
                checkBox2.Checked = false;
                label3.Text = "Proveedor";
                checkBox1.CheckState = CheckState.Checked;
            }
            else
            {
                statusSalida = 2;
                checkBox2.Checked = false;
                label3.Text = "Proveedor";
            }
            MostrarDatosCombo();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox1.Checked = false;
                statusSalida = 3;
                checkBox1.Checked = false;
                label3.Text = "Traspaso";
                checkBox2.CheckState = CheckState.Checked;

            }
            else
            {
                statusSalida = 3;
                checkBox1.Checked = false;
                label3.Text = "Traspaso";
            }
            MostrarDatosCombo();
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            try
            {
                LeerMultiLine();
                MessageBox.Show("Se realizó correctamente el movimiento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarSalidas();
            }
            catch
            {

            }
            
        }
    }
}
