namespace Compilador
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtCodigo = new TextBox();
            btnEjecutar = new Button();
            dtgDefiniciones = new DataGridView();
            dtgSimbolos = new DataGridView();
            dtgErrores = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtDescargar = new Button();
            txtinfo = new TextBox();
            label4 = new Label();
            txtNumLinea = new TextBox();
            btnGuardar = new Button();
            btnAbrir = new Button();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            textBox1 = new TextBox();
            label6 = new Label();
            btnLeerArchivoTokens = new Button();
            btnDescargarListaSimbolos = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgDefiniciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgSimbolos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgErrores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(67, 59);
            txtCodigo.Multiline = true;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(322, 308);
            txtCodigo.TabIndex = 0;
            txtCodigo.TextChanged += textBox1_TextChanged;
            // 
            // btnEjecutar
            // 
            btnEjecutar.Location = new Point(43, 24);
            btnEjecutar.Name = "btnEjecutar";
            btnEjecutar.Size = new Size(94, 29);
            btnEjecutar.TabIndex = 1;
            btnEjecutar.Text = "Ejecutar";
            btnEjecutar.UseVisualStyleBackColor = true;
            btnEjecutar.Click += btnEjecutar_Click;
            // 
            // dtgDefiniciones
            // 
            dtgDefiniciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDefiniciones.Location = new Point(452, 59);
            dtgDefiniciones.Name = "dtgDefiniciones";
            dtgDefiniciones.RowHeadersWidth = 51;
            dtgDefiniciones.Size = new Size(441, 308);
            dtgDefiniciones.TabIndex = 2;
            // 
            // dtgSimbolos
            // 
            dtgSimbolos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgSimbolos.Location = new Point(359, 443);
            dtgSimbolos.Name = "dtgSimbolos";
            dtgSimbolos.RowHeadersWidth = 51;
            dtgSimbolos.Size = new Size(482, 188);
            dtgSimbolos.TabIndex = 3;
            // 
            // dtgErrores
            // 
            dtgErrores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgErrores.Location = new Point(31, 443);
            dtgErrores.Name = "dtgErrores";
            dtgErrores.RowHeadersWidth = 51;
            dtgErrores.Size = new Size(322, 188);
            dtgErrores.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(452, 33);
            label1.Name = "label1";
            label1.Size = new Size(153, 20);
            label1.TabIndex = 5;
            label1.Text = "ARCHIVO DE TOKENS";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(545, 420);
            label2.Name = "label2";
            label2.Size = new Size(149, 20);
            label2.TabIndex = 6;
            label2.Text = "TABLA DE SIMBOLOS";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(106, 420);
            label3.Name = "label3";
            label3.Size = new Size(131, 20);
            label3.TabIndex = 7;
            label3.Text = "ERRORES LEXICOS";
            // 
            // txtDescargar
            // 
            txtDescargar.Location = new Point(452, 373);
            txtDescargar.Name = "txtDescargar";
            txtDescargar.Size = new Size(94, 29);
            txtDescargar.TabIndex = 8;
            txtDescargar.Text = "Descargar";
            txtDescargar.UseVisualStyleBackColor = true;
            txtDescargar.Click += txtDescargar_Click;
            // 
            // txtinfo
            // 
            txtinfo.Location = new Point(31, 690);
            txtinfo.Multiline = true;
            txtinfo.Name = "txtinfo";
            txtinfo.Size = new Size(515, 85);
            txtinfo.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 667);
            label4.Name = "label4";
            label4.Size = new Size(143, 20);
            label4.TabIndex = 10;
            label4.Text = "Informacion general";
            label4.Click += label4_Click;
            // 
            // txtNumLinea
            // 
            txtNumLinea.Location = new Point(43, 59);
            txtNumLinea.Multiline = true;
            txtNumLinea.Name = "txtNumLinea";
            txtNumLinea.Size = new Size(23, 308);
            txtNumLinea.TabIndex = 11;
            txtNumLinea.TextChanged += textBox1_TextChanged_1;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(43, 373);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnAbrir
            // 
            btnAbrir.Location = new Point(295, 373);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(94, 29);
            btnAbrir.TabIndex = 13;
            btnAbrir.Text = "Abrir";
            btnAbrir.UseVisualStyleBackColor = true;
            btnAbrir.Click += btnAbrir_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(847, 443);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(322, 188);
            dataGridView1.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(924, 420);
            label5.Name = "label5";
            label5.Size = new Size(164, 20);
            label5.TabIndex = 15;
            label5.Text = "ERRORES SINTACTICOS";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(642, 690);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(515, 85);
            textBox1.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(642, 667);
            label6.Name = "label6";
            label6.Size = new Size(143, 20);
            label6.TabIndex = 17;
            label6.Text = "Informacion general";
            // 
            // btnLeerArchivoTokens
            // 
            btnLeerArchivoTokens.Location = new Point(747, 373);
            btnLeerArchivoTokens.Name = "btnLeerArchivoTokens";
            btnLeerArchivoTokens.Size = new Size(146, 29);
            btnLeerArchivoTokens.TabIndex = 18;
            btnLeerArchivoTokens.Text = "LeerArchivoTokens";
            btnLeerArchivoTokens.UseVisualStyleBackColor = true;
            btnLeerArchivoTokens.Click += btnLeerArchivoTokens_Click;
            // 
            // btnDescargarListaSimbolos
            // 
            btnDescargarListaSimbolos.Location = new Point(359, 637);
            btnDescargarListaSimbolos.Name = "btnDescargarListaSimbolos";
            btnDescargarListaSimbolos.Size = new Size(94, 29);
            btnDescargarListaSimbolos.TabIndex = 19;
            btnDescargarListaSimbolos.Text = "Descargar";
            btnDescargarListaSimbolos.UseVisualStyleBackColor = true;
            btnDescargarListaSimbolos.Click += btnDescargarListaSimbolos_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1181, 794);
            Controls.Add(btnDescargarListaSimbolos);
            Controls.Add(btnLeerArchivoTokens);
            Controls.Add(label6);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(dataGridView1);
            Controls.Add(btnAbrir);
            Controls.Add(btnGuardar);
            Controls.Add(txtNumLinea);
            Controls.Add(label4);
            Controls.Add(txtinfo);
            Controls.Add(txtDescargar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtgErrores);
            Controls.Add(dtgSimbolos);
            Controls.Add(dtgDefiniciones);
            Controls.Add(btnEjecutar);
            Controls.Add(txtCodigo);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dtgDefiniciones).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgSimbolos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgErrores).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCodigo;
        private Button btnEjecutar;
        private DataGridView dtgDefiniciones;
        private DataGridView dtgSimbolos;
        private DataGridView dtgErrores;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button txtDescargar;
        private TextBox txtinfo;
        private Label label4;
        private TextBox txtNumLinea;
        private Button btnGuardar;
        private Button btnAbrir;
        private DataGridView dataGridView1;
        private Label label5;
        private TextBox textBox1;
        private Label label6;
        private Button btnLeerArchivoTokens;
        private Button btnDescargarListaSimbolos;
    }
}
