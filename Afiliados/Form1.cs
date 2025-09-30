using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Afiliados
{
    public partial class FrmAfiliados : Form
    {
        List<string> columnas;
        string archivo;
        DataTable dt;
        public FrmAfiliados()
        {
            dt = new DataTable();
            InitializeComponent();
            chBxFecha.Enabled = false;
            columnas = new List<string>();
            columnas.Add("ID");
            columnas.Add("ENTIDAD");
            columnas.Add("MUNICIPIO");
            columnas.Add("NOMBRE");
            columnas.Add("FECHA_AFILIACION");
            columnas.Add("STATUS");
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (oFDAfiliados.ShowDialog() == DialogResult.OK)
            {
                archivo = oFDAfiliados.FileName;
                rTBArchivo.Text = oFDAfiliados.SafeFileName;
                Thread h1 = new Thread(() => CargarExcel(archivo));
                //Se inicia hilo
                h1.Start();
                btnCargar.Enabled = false;
            }
        }

        private void CargarExcel(string ruta)
        {
            dt = new DataTable();
            ExcelPackage.License.SetNonCommercialPersonal("Yushab Jesed Serrano López");

            using (var package = new ExcelPackage(new System.IO.FileInfo(ruta)))
            {
                //Tomar primera página del archivo xslx
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                int columnCount = worksheet.Dimension.End.Column;
                int rowCount = worksheet.Dimension.End.Row;

                // Leer los encabezados de columna
                foreach (var col in columnas)
                {
                    dt.Columns.Add(col);
                }
                //Se envía la información a DataTable
                for (int i = 2; i <= rowCount; i++)
                {
                    DataRow renglon = dt.NewRow();
                    for (int j = 1; j <= columnCount; j++)
                    {
                        renglon[j - 1] = worksheet.Cells[i, j].Text;
                    }
                    dt.Rows.Add(renglon);
                }
            }
            //Se usa hilo
            this.Invoke((MethodInvoker)delegate
            {
                mostrarEnDGV(dt);
                cBMunicipio.Items.Add("TODOS");
                cBMunicipio.Items.Add("SIN MUNICIPIO ASIGNADO");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String municipio = dt.Rows[i][2].ToString();

                    if (!cBMunicipio.Items.Contains(municipio) && municipio != "")
                    {
                        cBMunicipio.Items.Add(municipio);
                    }

                }

                rTBEstado.Text = dt.Rows[0][1].ToString();
                conteoAfiliados();
                chBxFecha.Enabled = true;
            });

        }

        //Método para mostrar DataTable en dGVInformacion
        private void mostrarEnDGV(DataTable informacion)
        {
            dGVInformacion.Columns.Clear();
            dGVInformacion.DataSource = informacion;
            ajustarTamaños();
        }

        //Método para ajustar atamaños en dGVInfomrmacion
        private void ajustarTamaños()
        {
            //Condición para que no modifique alguna columna si no existe
            if (dGVInformacion.Columns.Contains("ENTIDAD"))
                dGVInformacion.Columns["ENTIDAD"].Width = 150;

            if (dGVInformacion.Columns.Contains("MUNICIPIO"))
                dGVInformacion.Columns["MUNICIPIO"].Width = 150;

            if (dGVInformacion.Columns.Contains("NOMBRE"))
                dGVInformacion.Columns["NOMBRE"].Width = 200;
        }

        private void cBMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBMunicipio.Text.Equals("TODOS"))
            {
                dGVInformacion.DataSource = dt;
            }
            else if (cBMunicipio.Text.Equals("SIN MUNICIPIO ASIGNADO"))
            {
                //Se clona el data table para guardar las columnas
                DataTable dtMunicipio = dt.Clone();
                dGVInformacion.DataSource = null;
                //Se eliminan los registros del dt clonado
                dtMunicipio.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][2].ToString() == "")
                    {
                        dtMunicipio.ImportRow(dt.Rows[i]);
                    }
                }
                dGVInformacion.DataSource = dtMunicipio;
                ajustarTamaños();
            }
            else
            {
                //Se clona el data table para guardar las columnas
                DataTable dtMunicipio = dt.Clone();
                dGVInformacion.DataSource = null;
                //Se eliminan los registros del dt clonado
                dtMunicipio.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][2].ToString() == cBMunicipio.Text)
                    {
                        dtMunicipio.ImportRow(dt.Rows[i]);
                    }
                }
                dGVInformacion.DataSource = dtMunicipio;
                ajustarTamaños();
            }

            conteoAfiliados();
        }

        //Método para contar afiliados que se muestran en el dGVInformacion
        public void conteoAfiliados()
        {
            int numAfiliados = dGVInformacion.Rows.Count - 1;
            rTBAfiliados.Text = numAfiliados.ToString();
        }

        private void chBxFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chBxFecha.Checked)
            {
                //Se guardan los valores de los DateTimePicker
                DateTime inicio = dTPInicio.Value.Date;
                DateTime fin = dTPFin.Value.Date;
                //Se clona el DataTable
                DataTable dtFiltrado = dt.Clone();
                dtFiltrado.Clear();

                for (int i = 0; i < dGVInformacion.Rows.Count; i++)
                {
                    //Condición para no leer nulos
                    if (dGVInformacion.Rows[i].IsNewRow) continue;
                    //Guardar la celda de la fecha en un String
                    string fechaCelda = dGVInformacion.Rows[i].Cells[4].Value.ToString();
                    //Convertir la fecha a DateTime
                    DateTime fechaAfiliacion = DateTime.ParseExact(fechaCelda,
                    "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                    //Se filtra la información para solo mostrar los renglones solicitados
                    if (fechaAfiliacion >= inicio && fechaAfiliacion <= fin)
                    {
                        DataRow filaOriginal = ((DataRowView)dGVInformacion.Rows[i].DataBoundItem).Row;
                        dtFiltrado.ImportRow(filaOriginal);
                    }
                }
                //Se muestra la informacion en dGVInformacion 
                dGVInformacion.DataSource = dtFiltrado;
                //Se ajustan los tamaños y se actualiza el conteo de afiliados
                ajustarTamaños();
                conteoAfiliados();
            }
            if (!chBxFecha.Checked) 
            {
                //Si no está marcado el CheckBox
                dGVInformacion.DataSource = dt;
                cBMunicipio.SelectedItem = "TODOS";
                conteoAfiliados();
            }
            
        }

        //Se reinicia la información y los elementos visuales
        private void btnReset_Click(object sender, EventArgs e)
        {
            dGVInformacion.Columns.Clear();
            dt.Rows.Clear();
            rTBAfiliados.Text = "";
            rTBArchivo.Text = "";
            rTBEstado.Text = "";
            cBMunicipio.Items.Clear();
            cBMunicipio.Text = "";
            btnCargar.Enabled = true;
        }
        //Se cierra programa

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
