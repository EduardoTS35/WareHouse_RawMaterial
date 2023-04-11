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
using Domain;
using BarcodeLib;
using System.Drawing.Printing;
using System.IO.Ports;

namespace ErpModuloAlmacenMP
{
    public partial class frmEntrada : Form
    {
        UserModel userModel = new UserModel();
        string dataIN;
        char[] charToTrim = { 'S', 'T', 'G', '-', ',', '+', 'k', 'g', ' ' };
        List<MaterialClass> data = new List<MaterialClass>();
        bool entradaManual=false;


        public frmEntrada()
        {
            
            InitializeComponent();
            MostrarCatalogoMP();
            MostrarEntradas();
            MostrarProveedores();
            MostrarNumEtiqueta();
            MostrarTurno();
            
        }
        private void MostrarEntradas()
        {
            data = (from DataRow dr in userModel.ver_Datos().Rows
                    select new MaterialClass()
                    {
                        idPrimario=Convert.ToInt32(dr["idPrimario"]),
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
                    }).Where(d => d.idStatus == 1).ToList();

            dataGridView1.DataSource = data;
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
        private void MostrarCatalogoMP()
        {
            try
            {
                cmbProducto.DataSource = userModel.ver_CatalogoMP();
                cmbProducto.DisplayMember = "producto";
                cmbProducto.ValueMember = "idProducto";
            }
            catch
            {

            }
        }
        private void MostrarProveedores()
        {
            try
            {
                cmbProveedor.DataSource = userModel.ver_CatalogoProveedores();
                cmbProveedor.DisplayMember = "proveedor";
                cmbProveedor.ValueMember = "idProveedor";
            }
            catch
            {

            }

        }
        private void MostrarNumEtiqueta()
        {
            try
            {
                cmbIdSerial.DataSource = userModel.ver_NumEtiqueta();
                cmbIdSerial.DisplayMember = "idEtiqueta";
                if (cmbIdSerial.Text == "")
                {
                    cmbIdSerial.Text = "1";
                }
            }
            catch
            {

            }
        }

        private void MostrarCosto(string idProducto)
        {
            userModel.mostrar_Costo(idProducto);
        }

        private void InsertarDatos(string idEtiqueta, int idUsuario, string idProducto, string tara, string pesoBruto, string pesoNeto, double costo, int idStatus, int idProveedor,int idProceso)
        {            
            userModel.insertarEntradas(Convert.ToInt32(idEtiqueta),idUsuario, idProducto,Math.Round(Convert.ToDouble(tara),2), Math.Round(Convert.ToDouble(pesoBruto),2),Math.Round( Convert.ToDouble(pesoNeto),2), costo, idStatus, idProveedor,idProceso);
        }

        public void TurnoCorrespondienteN()
        {
            double hora = Convert.ToDouble(DateTime.Now.ToString("HH.mm"));
            if (hora <= 07)
            {
                if (hora >= 00)
                {
                    lblTurno.Text = "Nocturno";
                }

            }
            else
            {
                lblTurno.Text = "Nocturno";
            }

        }
        public void TurnoCorrespondienteD()
        {
            double hora = Convert.ToDouble(DateTime.Now.ToString("HH.mm"));
            if (hora <= 20)
            {
                if (hora >= 07)
                {
                    lblTurno.Text = "Diurno";
                }
            }
        }

        private void MostrarTurno()
        {
            TurnoCorrespondienteN();
            TurnoCorrespondienteD();
        }
        public void SerialPortCoN()
        {
            if (serialPort1.IsOpen)
            {
                AppCache.StatusPort = 1;
            }
            else AppCache.StatusPort = 0;
        }
        public void CapturarData()
        {
            string trimDataIn = tboxDatosB.Text.Trim(charToTrim);
            trimDataIn = Convert.ToString(Math.Round( Convert.ToDouble(tboxDatosB.Text),0));
            string dataFinal = trimDataIn.Normalize();
            if (tboxTara.Text == "")
            {
                tboxTara.Text = dataFinal;


            }
            else tboxDataIN.Text = dataFinal;
        }
        public void CalcularPesoNeto()
        {
            if (entradaManual == false)
            {
                string trimDataIn = tboxDatosB.Text.Trim(charToTrim);
                double pesoNeto = Math.Round(Convert.ToSingle(trimDataIn) - Convert.ToSingle(tboxTara.Text), 0);
                tboxPesoNeto.Text = Convert.ToString(pesoNeto);
            }
            else
            {
                tboxDataIN.Text = tboxDatosB.Text;
                double pesoNeto = Math.Round(Convert.ToSingle(tboxDataIN.Text)-Convert.ToSingle(tboxTara.Text),0);
                tboxPesoNeto.Text = Convert.ToString(pesoNeto);
            }
        }
        public void CorregirTara()
        {
            tboxTara.Text = "";
            tboxDataIN.Text = "";
            tboxPesoNeto.Text = "";
        }
        public void CalcularCosto()
        {
            double costoTotal;
            costoTotal = AppCache.costoActual * Convert.ToDouble(tboxPesoNeto.Text);
            AppCache.costoActual = costoTotal;
        }
        public void GuardarDatos()
        {
            try
            {
                if (tboxTara.Text != "")
                {
                    if (entradaManual == false)
                    {
                        CapturarData();
                    }
                    CalcularPesoNeto();
                    try
                    {
                        if (cmbIdSerial.Text != "" && tboxIDProd.Text != "" && cmbProducto.Text != "" && tboxDataIN.Text != "" && tboxPesoNeto.Text != "" && tboxTara.Text != "" && cmbProveedor.Text != "")
                        {
                            CalcularCosto();
                            InsertarDatos(cmbIdSerial.Text, UserLoginCache.Id, tboxIDProd.Text, tboxTara.Text, tboxDataIN.Text, tboxPesoNeto.Text, AppCache.costoActual, 1, Convert.ToInt32(cmbProveedor.SelectedValue), 1);
                            printDocument1 = new PrintDocument();
                            PrinterSettings ps = new PrinterSettings();
                            PageSettings pageSettings = new PageSettings();
                            PaperSize paper = new PaperSize("Etiqueta", 394, 551);
                            printDocument1.PrinterSettings = ps;
                            pageSettings.PaperSize = paper;
                            printDocument1.PrintPage += Imprimir;
                            printDocument1.Print();
                            printDocument1.Print();
                            MostrarNumEtiqueta();

                            tboxDataIN.Clear();
                            tboxPesoNeto.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Por favor completa todos los campos", "Advertencia");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se insertaron los datos por: " + ex);
                    }
                    MostrarEntradas();
                }
                else
                {
                    CapturarData();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }

        private void Imprimir(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Barcode barcode = new Barcode();
            barcode.IncludeLabel = false;
            barcode.Alignment = AlignmentPositions.CENTER;
            barcode.LabelFont = new Font(FontFamily.GenericMonospace, 14, FontStyle.Regular);
            Image img = barcode.Encode(TYPE.CODE128, cmbIdSerial.Text, Color.Black, Color.White, 240, 60);

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
            e.Graphics.DrawString(cmbProducto.Text, fontT, Brushes.Black, new RectangleF(7, largo, ancho, 40));
            e.Graphics.DrawString("                      ", fontP, Brushes.Black, new RectangleF(300, largo += 25, ancho, 25));
            e.Graphics.DrawString("                      ", fontP, Brushes.Black, new RectangleF(300, largo += 25, ancho, 25));
            e.Graphics.DrawString("ID: " + tboxIDProd.Text, ftext, Brushes.Black, new RectangleF(12, largo += 22, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Bruto:" + tboxDataIN.Text + " KG", font, Brushes.Black, new RectangleF(220, largo = 97, ancho, 40));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Fecha:  " + DateTime.Now.ToShortDateString(), ftext, Brushes.Black, new RectangleF(12, 170, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Neto:" + tboxPesoNeto.Text + " KG", font, Brushes.Black, new RectangleF(220, 200, ancho, 40));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Turno:  " + lblTurno.Text, ftext, Brushes.Black, new RectangleF(12, 230, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Número: " + cmbIdSerial.Text, ftext, Brushes.Black, new RectangleF(12, 300, ancho, 25));
            e.Graphics.DrawImage(img, 260, 310);
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                dataIN = serialPort1.ReadExisting();
                this.Invoke(new EventHandler(ShowData));
            }
            catch(Exception err)
            {
                AppCache.StatusPort = 0;
                serialPort1.Close();
                serialPort1.Dispose();
                btnConectar.Enabled = true;
                lblStatus.Text = "DESCONECTADO";
                lblStatus.ForeColor = Color.FromArgb(200, 46, 13);
                timer1.Stop();
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SerialPortCoN();
            }
        }

        private void ShowData(object sender, EventArgs e)
        {
            try
            {
                string trimDataIn = dataIN.Remove(0, 8);
                tboxDatosB.Text = trimDataIn.Remove(6);
            }
            catch (Exception err)
            {
                AppCache.StatusPort = 0;
                serialPort1.Close();
                serialPort1.Dispose();
                btnConectar.Enabled = true;
                lblStatus.Text = "DESCONECTADO";
                lblStatus.ForeColor = Color.FromArgb(200, 46, 13);
                timer1.Stop();
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SerialPortCoN();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    string trimDataIn = dataIN.Remove(0, 8);
            //    tboxDatosB.Text = trimDataIn.Remove(6);
            //}
            //catch(Exception err)
            //{
            //    AppCache.StatusPort = 0;
            //    serialPort1.Close();
            //    serialPort1.Dispose();
            //    btnConectar.Enabled = true;
            //    lblStatus.Text = "DESCONECTADO";
            //    lblStatus.ForeColor = Color.FromArgb(200, 46, 13);
            //    timer1.Stop();
            //    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    SerialPortCoN();
            //}
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                AppCache.StatusPort = 1;
                serialPort1.PortName = cmbComport.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = (StopBits)1;
                serialPort1.Parity = 0;
                serialPort1.Open();
                btnConectar.Enabled = false;
                btnDesconectar.Enabled = true;
                lblStatus.Text = "  CONECTADO";
                lblStatus.ForeColor = Color.FromArgb(61, 200, 13);
                //timer1.Start();
                SerialPortCoN();
            }
            catch (Exception err)
            {
                AppCache.StatusPort = 0;
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnConectar.Enabled = true;
                btnDesconectar.Enabled = false;
                lblStatus.Text = "DESCONECTADO";
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            dataIN = "Desconectado";
            if (dataIN == "Desconectado")
            {
                AppCache.StatusPort = 0;
                serialPort1.Close();
                serialPort1.Dispose();
                btnConectar.Enabled = true;
                lblStatus.Text = "DESCONECTADO";
                lblStatus.ForeColor = Color.FromArgb(200, 46, 13);
                SerialPortCoN();
            }
        }

        private void btnBorrarDatos_Click(object sender, EventArgs e)
        {
            CorregirTara();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            MostrarTurno();
        }

        private void cmbProducto_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString(cmbProducto.SelectedValue);
                MostrarCosto(id);
                tboxIDProd.Text = id;
            }
            catch
            {

            }
        }

        private void frmEntrada_KeyUp(object sender, KeyEventArgs e)
        {
            GuardarDatos();
        }

        private void frmEntrada_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cmbComport.Items.AddRange(ports);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dataIN = "Desconectado";
                if (dataIN == "Desconectado")
                {
                    AppCache.StatusPort = 0;
                    serialPort1.Close();
                    serialPort1.Dispose();
                    btnConectar.Enabled = true;
                    lblStatus.Text = "DESCONECTADO";
                    lblStatus.ForeColor = Color.FromArgb(200, 46, 13);
                    SerialPortCoN();
                }
                entradaManual = true;
                tboxDatosB.ReadOnly = false;
                tboxDatosB.Text = "";
            }
            else
            {
                entradaManual = false;
                tboxDatosB.ReadOnly = true;
                tboxDatosB.Text = "";
            }
                
        }
    }
}
