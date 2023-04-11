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
using BarcodeLib;
using System.Drawing.Printing;

namespace ErpModuloAlmacenMP
{
    public partial class frmConfigAlmacenMP : Form
    {
        UserModel userModel = new UserModel();
        List<MaterialClass> data = new List<MaterialClass>();
        AppCache v = new AppCache();
        bool statusSeleccion;
        public frmConfigAlmacenMP()
        {
            InitializeComponent();
        }
        private void MostrarDatos()
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

            var filtroSalidas = (from d in data
                                 where d.idStatus >= 2 && d.idStatus <= 3
                                 select d).ToList();

            var filtroEntradas = (from d in data
                                 where d.idStatus == 1
                                 select d).ToList();

            if (cmbSeleccion.Text == "Entradas")
            {
                dataGridView1.DataSource = filtroEntradas;
            }
            else if (cmbSeleccion.Text == "Salidas")
            {
                dataGridView1.DataSource = filtroSalidas;
            }
            
            dataGridView1.Columns["idPrimario"].Visible = false;
            dataGridView1.Columns["costo"].Visible = false;
            dataGridView1.Columns["idUsuario"].Visible = false;
            dataGridView1.Columns["idStatus"].Visible = false;
            dataGridView1.Columns["idProveedor"].Visible = false;
            dataGridView1.Columns["idTraspaso"].Visible = false;

            dataGridView1.Columns["idEtiqueta"].HeaderText = "Núm.Etiqueta";
            dataGridView1.Columns["fechaRegistro"].HeaderText = "Fecha de Registro";
            dataGridView1.Columns["idProducto"].HeaderText = "Cód.Producto";
            dataGridView1.Columns["tara"].HeaderText = "Tara";
            dataGridView1.Columns["pesoBruto"].HeaderText = "Peso Bruto";
            dataGridView1.Columns["pesoNeto"].HeaderText = "Peso Neto";
        }
        private void SeleccionarMovimiento()
        {
            statusSeleccion = true;
            v.idEtiqueta= Convert.ToInt32(dataGridView1.CurrentRow.Cells["idEtiqueta"].Value.ToString());
            v.fechaRegistro = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["fechaRegistro"].Value.ToString());
            v.idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
            v.tara = Convert.ToDouble(dataGridView1.CurrentRow.Cells["tara"].Value.ToString());
            v.pesoBruto = Convert.ToDouble(dataGridView1.CurrentRow.Cells["pesoBruto"].Value.ToString());
            v.pesoNeto = Convert.ToDouble(dataGridView1.CurrentRow.Cells["pesoNeto"].Value.ToString());
            v.costo = Convert.ToDouble(dataGridView1.CurrentRow.Cells["costo"].Value.ToString());
            v.idStatus = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idStatus"].Value.ToString());
            v.idProveedor = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idProveedor"].Value.ToString());
            v.idTraspaso = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idTraspaso"].Value.ToString());
            tboxIdEtiqueta.Text = dataGridView1.CurrentRow.Cells["idEtiqueta"].Value.ToString();
            tboxFechaRegistro.Text = dataGridView1.CurrentRow.Cells["fechaRegistro"].Value.ToString();
            tboxIdProducto.Text = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
            tboxPesoBruto.Text = dataGridView1.CurrentRow.Cells["pesoBruto"].Value.ToString();
            tboxPesoNeto.Text = dataGridView1.CurrentRow.Cells["pesoNeto"].Value.ToString();
        }
        
        private void LimpiarTbox()
        {
            tboxIdEtiqueta.Clear();
            tboxFechaRegistro.Clear();
            tboxIdProducto.Clear();
            tboxPesoBruto.Clear();
            tboxPesoNeto.Clear();
        }
        private void DeshacerMovimiento()
        {
            if (statusSeleccion == true)
            {
                try
                {
                    if (cmbSeleccion.Text == "Entradas")
                    {
                        userModel.deshacerMoviemientoEntradas((int)v.idEtiqueta);

                    }
                    else if (cmbSeleccion.Text == "Salidas")
                    {
                        userModel.deshacerMoviemientoSalidas((int)v.idEtiqueta, (int)v.idStatus, 1, 1);
                    }
                    MessageBox.Show("Se realizó correctamente el cambio.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarTbox();
                    statusSeleccion = false;
                    MostrarDatos();
                }
                catch
                {
                    MessageBox.Show("Favor de comunicarse con soporte técnico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarTbox();
                    statusSeleccion = false;
                }               
            }
            else
            {
                MessageBox.Show("Por favor seleccione un movimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarTbox();
                statusSeleccion = false;
            }
        }

        private void Imprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Barcode barcode = new Barcode();
            barcode.IncludeLabel = false;
            barcode.Alignment = AlignmentPositions.CENTER;
            barcode.LabelFont = new Font(FontFamily.GenericMonospace, 14, FontStyle.Regular);
            Image img = barcode.Encode(TYPE.CODE128, Convert.ToString(v.idEtiqueta), Color.Black, Color.White, 240, 60);

            PageSettings pageSettings = new PageSettings();
            PaperSize paper = new PaperSize("Etiqueta", 404, 551);
            pageSettings.PaperSize = paper;
            Font fontT = new Font("Arial", 22, FontStyle.Bold);
            Font font = new Font("Arial", 26, FontStyle.Bold);
            Font fontP = new Font("Arial", 14, FontStyle.Bold);
            Font ftext = new Font("Arial", 13, FontStyle.Bold);
            Font fontS = new Font("Arial", 5);
            Pen blackpen = new Pen(Color.Black, 3);
            int ancho = 900;
            int largo = 20;

            e.Graphics.DrawRectangle(blackpen, 5, 5, 534, 375);
            e.Graphics.DrawRectangle(blackpen, 215, 53, 303, 228);
            e.Graphics.DrawLine(blackpen, 215, 170, 519, 170);
            e.Graphics.DrawString(v.idProducto, fontT, Brushes.Black, new RectangleF(7, largo, ancho, 40));
            e.Graphics.DrawString("                      ", fontP, Brushes.Black, new RectangleF(300, largo += 25, ancho, 25));
            e.Graphics.DrawString("                      ", fontP, Brushes.Black, new RectangleF(300, largo += 25, ancho, 25));
            e.Graphics.DrawString("ID: " + v.idProducto, ftext, Brushes.Black, new RectangleF(12, largo += 22, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Bruto:" + Math.Round((double)v.pesoBruto, 2) + " KG", font, Brushes.Black, new RectangleF(220, largo = 97, ancho, 40));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Fecha:  " + DateTime.Now.ToShortDateString(), ftext, Brushes.Black, new RectangleF(12, 170, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Neto:" + Math.Round((double)v.pesoNeto,2) + " KG", font, Brushes.Black, new RectangleF(220, 200, ancho, 40));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Turno: *** ", ftext, Brushes.Black, new RectangleF(12, 230, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Número: " + v.idEtiqueta, ftext, Brushes.Black, new RectangleF(12, 300, ancho, 25));
            e.Graphics.DrawImage(img, 260, 310);
        }

        private void cmbSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatos();
            LimpiarTbox();
            statusSeleccion = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SeleccionarMovimiento();
            }
            catch
            {
                MessageBox.Show("Por favor seleccione un registro válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarTbox();
                statusSeleccion = false;
            }
        }

        private void btnReimpresion_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument1 = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                PageSettings pageSettings = new PageSettings();
                PaperSize paper = new PaperSize("Etiqueta", 394, 551);
                printDocument1.PrinterSettings = ps;
                pageSettings.PaperSize = paper;
                printDocument1.PrintPage += Imprimir;
                printDocument1.Print();
                LimpiarTbox();
                statusSeleccion = false;
            }
            catch
            {

            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DeshacerMovimiento();
        }
    }
}
