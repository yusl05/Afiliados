using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
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
        public FrmAfiliados()
        {
            InitializeComponent();
            columnas = new List<string>();
            columnas.Add("ID");
            columnas.Add("ENTIDAD");
            columnas.Add("MUNICIPIO");
            columnas.Add("NOMBRE");
            columnas.Add("FECHA_AFILIACION");
            columnas.Add("STATUS");
        }

        Thread hilo;
        string archivo;
        DataTable dt;
        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (oFDAfiliados.ShowDialog() == DialogResult.OK)
            {
                archivo = oFDAfiliados.FileName;
                rTBArchivo.Text = oFDAfiliados.SafeFileName;
                dGVInformacion.Rows.Clear();
                CargarExcel(archivo);
            }
        }

        private void CargarExcel(string ruta)
        {
            dt = new DataTable();
            ExcelPackage.License.SetNonCommercialPersonal("Yushab Jesed Serrano López");

            //Thread.Sleep(100);
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
            mostrarEnDGV(dt);

            //Llenar municipios
            List<string> municipios = new List<string>();
            bool tieneMunicipioEnBlanco = false;
            String municipio = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (!dt.Rows[i][2].ToString().Equals(municipio) && !dt.Rows[i][2].ToString().Equals("") && 
                    !municipios.Contains(municipio) && !municipio.Equals(""))
                {
                    municipios.Add(municipio);
                }
                if (dt.Rows[i][2].ToString().Equals(""))
                {
                    tieneMunicipioEnBlanco |= true;
                }

                municipio = dt.Rows[i][2].ToString();
            }

            cBMunicipio.Items.Clear();
            cBMunicipio.Items.Add("NINGUNO");
            if (tieneMunicipioEnBlanco) cBMunicipio.Items.Add("SIN MUNICIPIO ASIGNADO");
            for (int i = 0; i < municipios.Count; i++)
            {
                cBMunicipio.Items.Add(municipios[i]);
            }

            rTBEstado.Text = dt.Rows[0][1].ToString();
            
            conteoAfiliados();

        }

        private void mostrarEnDGV(DataTable informacion)
        {
            for (int i = 0; i < informacion.Rows.Count; i++)
            {
                dGVInformacion.Rows.Add();
                for (int j = 0; j < informacion.Columns.Count; j++)
                {
                    dGVInformacion.Rows[i].Cells[j].Value = informacion.Rows[i][j].ToString();
                }
            }
        }

        private void cBMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cBMunicipio.Text.Equals("NINGUNO"))
            {
                dGVInformacion.Rows.Clear();
                mostrarEnDGV(dt);
            }
            else if (cBMunicipio.Text.Equals("SIN MUNICIPIO ASIGNADO"))
            {
                dGVInformacion.Rows.Clear();
                int k = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][2].ToString() == "")
                    {
                        dGVInformacion.Rows.Add();
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            dGVInformacion.Rows[k].Cells[j].Value =
                                dt.Rows[i][j].ToString();
                        }
                        k++;
                    }
                }
            }
            else
            {
                dGVInformacion.Rows.Clear();
                int k = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][2].ToString() == cBMunicipio.Text)
                    {
                        dGVInformacion.Rows.Add();
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            dGVInformacion.Rows[k].Cells[j].Value =
                                dt.Rows[i][j].ToString();
                        }
                        k++;
                    }
                }
            }

            conteoAfiliados();
        }

        public void conteoAfiliados()
        {
            int numAfiliados = dGVInformacion.Rows.Count;
            rTBAfiliados.Text = numAfiliados.ToString();
        }
    }
}
