namespace Afiliados
{
    partial class FrmAfiliados
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labArchivo = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labMunicipio = new System.Windows.Forms.Label();
            this.cBMunicipio = new System.Windows.Forms.ComboBox();
            this.dGVInformacion = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labNumAfiliado = new System.Windows.Forms.Label();
            this.rTBArchivo = new System.Windows.Forms.RichTextBox();
            this.rTBEstado = new System.Windows.Forms.RichTextBox();
            this.chBxFecha = new System.Windows.Forms.CheckBox();
            this.oFDAfiliados = new System.Windows.Forms.OpenFileDialog();
            this.dTPInicio = new System.Windows.Forms.DateTimePicker();
            this.dTPFin = new System.Windows.Forms.DateTimePicker();
            this.labInicio = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rTBAfiliados = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dGVInformacion)).BeginInit();
            this.SuspendLayout();
            // 
            // labArchivo
            // 
            this.labArchivo.AutoSize = true;
            this.labArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labArchivo.Location = new System.Drawing.Point(28, 24);
            this.labArchivo.Name = "labArchivo";
            this.labArchivo.Size = new System.Drawing.Size(98, 22);
            this.labArchivo.TabIndex = 0;
            this.labArchivo.Text = "ARCHIVO";
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(381, 36);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(106, 44);
            this.btnCargar.TabIndex = 1;
            this.btnCargar.Text = "CARGAR";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1017, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(101, 43);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "ESTADO:";
            // 
            // labMunicipio
            // 
            this.labMunicipio.AutoSize = true;
            this.labMunicipio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMunicipio.Location = new System.Drawing.Point(26, 155);
            this.labMunicipio.Name = "labMunicipio";
            this.labMunicipio.Size = new System.Drawing.Size(116, 22);
            this.labMunicipio.TabIndex = 5;
            this.labMunicipio.Text = "MUNICIPIO:";
            // 
            // cBMunicipio
            // 
            this.cBMunicipio.FormattingEnabled = true;
            this.cBMunicipio.Location = new System.Drawing.Point(148, 149);
            this.cBMunicipio.Name = "cBMunicipio";
            this.cBMunicipio.Size = new System.Drawing.Size(251, 28);
            this.cBMunicipio.TabIndex = 7;
            this.cBMunicipio.SelectedIndexChanged += new System.EventHandler(this.cBMunicipio_SelectedIndexChanged);
            // 
            // dGVInformacion
            // 
            this.dGVInformacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVInformacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dGVInformacion.Location = new System.Drawing.Point(30, 205);
            this.dGVInformacion.Name = "dGVInformacion";
            this.dGVInformacion.RowHeadersWidth = 62;
            this.dGVInformacion.RowTemplate.Height = 28;
            this.dGVInformacion.Size = new System.Drawing.Size(1088, 300);
            this.dGVInformacion.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ENTIDAD";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "MUNICIPIO";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "NOMBRE";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.Width = 250;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "FECHA AFILIACION";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ESTATUS";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.Width = 80;
            // 
            // labNumAfiliado
            // 
            this.labNumAfiliado.AutoSize = true;
            this.labNumAfiliado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNumAfiliado.Location = new System.Drawing.Point(25, 525);
            this.labNumAfiliado.Name = "labNumAfiliado";
            this.labNumAfiliado.Size = new System.Drawing.Size(117, 22);
            this.labNumAfiliado.TabIndex = 9;
            this.labNumAfiliado.Text = "AFILIADOS:";
            // 
            // rTBArchivo
            // 
            this.rTBArchivo.Location = new System.Drawing.Point(32, 49);
            this.rTBArchivo.Name = "rTBArchivo";
            this.rTBArchivo.Size = new System.Drawing.Size(343, 31);
            this.rTBArchivo.TabIndex = 10;
            this.rTBArchivo.Text = "";
            // 
            // rTBEstado
            // 
            this.rTBEstado.Location = new System.Drawing.Point(148, 109);
            this.rTBEstado.Name = "rTBEstado";
            this.rTBEstado.Size = new System.Drawing.Size(251, 31);
            this.rTBEstado.TabIndex = 11;
            this.rTBEstado.Text = "";
            // 
            // chBxFecha
            // 
            this.chBxFecha.AutoSize = true;
            this.chBxFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBxFecha.Location = new System.Drawing.Point(29, 562);
            this.chBxFecha.Name = "chBxFecha";
            this.chBxFecha.Size = new System.Drawing.Size(102, 26);
            this.chBxFecha.TabIndex = 13;
            this.chBxFecha.Text = "FECHA";
            this.chBxFecha.UseVisualStyleBackColor = true;
            this.chBxFecha.CheckedChanged += new System.EventHandler(this.chBxFecha_CheckedChanged);
            // 
            // oFDAfiliados
            // 
            this.oFDAfiliados.FileName = "openFileDialog1";
            this.oFDAfiliados.Filter = "ArchivosExcel|*.xlsx";
            // 
            // dTPInicio
            // 
            this.dTPInicio.Location = new System.Drawing.Point(98, 605);
            this.dTPInicio.Name = "dTPInicio";
            this.dTPInicio.Size = new System.Drawing.Size(200, 26);
            this.dTPInicio.TabIndex = 14;
            // 
            // dTPFin
            // 
            this.dTPFin.Location = new System.Drawing.Point(381, 605);
            this.dTPFin.Name = "dTPFin";
            this.dTPFin.Size = new System.Drawing.Size(200, 26);
            this.dTPFin.TabIndex = 15;
            // 
            // labInicio
            // 
            this.labInicio.AutoSize = true;
            this.labInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInicio.Location = new System.Drawing.Point(24, 608);
            this.labInicio.Name = "labInicio";
            this.labInicio.Size = new System.Drawing.Size(68, 22);
            this.labInicio.TabIndex = 16;
            this.labInicio.Text = "INICIO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(334, 605);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 22);
            this.label2.TabIndex = 17;
            this.label2.Text = "FIN";
            // 
            // rTBAfiliados
            // 
            this.rTBAfiliados.Location = new System.Drawing.Point(148, 524);
            this.rTBAfiliados.Name = "rTBAfiliados";
            this.rTBAfiliados.Size = new System.Drawing.Size(150, 31);
            this.rTBAfiliados.TabIndex = 18;
            this.rTBAfiliados.Text = "";
            // 
            // FrmAfiliados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 647);
            this.Controls.Add(this.rTBAfiliados);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labInicio);
            this.Controls.Add(this.dTPFin);
            this.Controls.Add(this.dTPInicio);
            this.Controls.Add(this.chBxFecha);
            this.Controls.Add(this.rTBEstado);
            this.Controls.Add(this.rTBArchivo);
            this.Controls.Add(this.labNumAfiliado);
            this.Controls.Add(this.dGVInformacion);
            this.Controls.Add(this.cBMunicipio);
            this.Controls.Add(this.labMunicipio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.labArchivo);
            this.Name = "FrmAfiliados";
            this.Text = "AFILIADOS";
            ((System.ComponentModel.ISupportInitialize)(this.dGVInformacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labArchivo;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labMunicipio;
        private System.Windows.Forms.ComboBox cBMunicipio;
        private System.Windows.Forms.DataGridView dGVInformacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label labNumAfiliado;
        private System.Windows.Forms.RichTextBox rTBArchivo;
        private System.Windows.Forms.RichTextBox rTBEstado;
        private System.Windows.Forms.CheckBox chBxFecha;
        private System.Windows.Forms.OpenFileDialog oFDAfiliados;
        private System.Windows.Forms.DateTimePicker dTPInicio;
        private System.Windows.Forms.DateTimePicker dTPFin;
        private System.Windows.Forms.Label labInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rTBAfiliados;
    }
}

