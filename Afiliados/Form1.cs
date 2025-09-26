using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            columnas.Add("Entidad");
            columnas.Add("Municipio");
            columnas.Add("Nombre");
            columnas.Add("Fecha afiliacion");
            columnas.Add("Estatus");
        }

        //Thread hilo;

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (oFDAfiliados.ShowDialog() == DialogResult.OK)
            {
                string archivo = oFDAfiliados.FileName;
                rTBArchivo.Text = oFDAfiliados.FileName;
                CargarExcel(archivo);
            }
        }

        private void CargarExcel(string ruta)
        {
            List <String> municipios;
            ExcelPackage.License.SetNonCommercialPersonal("Yushab Jesed Serrano López");

            //Thread.Sleep(100);
            using (var package = new ExcelPackage(new System.IO.FileInfo(ruta)))
            {
                municipios = new List<String>();
                //Tomar primera página del archivo xslx
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                int rowCount = worksheet.Dimension.End.Row;
                dGVInformacion.Rows.Add(rowCount + 1);
                String municipio = "";
                for (int i = 2; i < rowCount+1; i++)
                {
                    for (int j = 1; j < dGVInformacion.Columns.Count + 1; j++)
                    {
                        if (!worksheet.Cells[i, 3].Text.Equals(municipio) && !worksheet.Cells[i, 3].Text.Equals(""))
                        {
                            municipio = worksheet.Cells[i, 3].Text;
                            municipios.Add(municipio);
                        }
                        var columna = worksheet.Cells[i, j].Text;
                        dGVInformacion.Rows[i - 2].Cells[j - 1].Value = columna;
                    }
                }

                //Añadir municipios a ComboBox
                for (int i = 0; i < municipios.Count; i++)
                {
                    cBMunicipio.Items.Add(municipios[i]);
                }

            }

        }


    }
}
