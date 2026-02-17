namespace AS
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
            btnAbrirArchivo = new Button();
            btnAgregarRegistro = new Button();
            btnEliminarRegistro = new Button();
            btnBuscar = new Button();
            btnModificar = new Button();
            btnCrearArchivo = new Button();
            dgvRegistros = new DataGridView();
            txtNombre = new TextBox();
            txtCarrera = new TextBox();
            lblNombre = new Label();
            lblCarrera = new Label();
            lblArchivoActual = new Label();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            btnPropiedades = new Button();
            btnCrearCarpeta = new Button();
            btnRenombrar = new Button();
            btnGuardarCambios = new Button();
            btnCopiarArchivo = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRegistros).BeginInit();
            SuspendLayout();
            // 
            // btnAbrirArchivo
            // 
            btnAbrirArchivo.Location = new Point(138, 12);
            btnAbrirArchivo.Name = "btnAbrirArchivo";
            btnAbrirArchivo.Size = new Size(120, 40);
            btnAbrirArchivo.TabIndex = 0;
            btnAbrirArchivo.Text = "Abrir Archivo";
            btnAbrirArchivo.UseVisualStyleBackColor = true;
            btnAbrirArchivo.Click += btnAbrirArchivo_Click;
            // 
            // btnAgregarRegistro
            // 
            btnAgregarRegistro.Location = new Point(390, 12);
            btnAgregarRegistro.Name = "btnAgregarRegistro";
            btnAgregarRegistro.Size = new Size(120, 40);
            btnAgregarRegistro.TabIndex = 7;
            btnAgregarRegistro.Text = "Agregar";
            btnAgregarRegistro.UseVisualStyleBackColor = true;
            btnAgregarRegistro.Click += btnAgregarRegistro_Click;
            // 
            // btnEliminarRegistro
            // 
            btnEliminarRegistro.Location = new Point(12, 58);
            btnEliminarRegistro.Name = "btnEliminarRegistro";
            btnEliminarRegistro.Size = new Size(120, 40);
            btnEliminarRegistro.TabIndex = 8;
            btnEliminarRegistro.Text = "Eliminar Registro";
            btnEliminarRegistro.UseVisualStyleBackColor = true;
            btnEliminarRegistro.Click += btnEliminarRegistro_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(138, 58);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(120, 40);
            btnBuscar.TabIndex = 9;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(390, 58);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(120, 40);
            btnModificar.TabIndex = 10;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnCrearArchivo
            // 
            btnCrearArchivo.Location = new Point(12, 12);
            btnCrearArchivo.Name = "btnCrearArchivo";
            btnCrearArchivo.Size = new Size(120, 40);
            btnCrearArchivo.TabIndex = 1;
            btnCrearArchivo.Text = "Crear Archivo";
            btnCrearArchivo.UseVisualStyleBackColor = true;
            btnCrearArchivo.Click += btnCrearArchivo_Click;
            // 
            // dgvRegistros
            // 
            dgvRegistros.AllowUserToAddRows = false;
            dgvRegistros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRegistros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistros.Location = new Point(12, 150);
            dgvRegistros.Name = "dgvRegistros";
            dgvRegistros.ReadOnly = true;
            dgvRegistros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistros.Size = new Size(786, 288);
            dgvRegistros.TabIndex = 11;
            dgvRegistros.SelectionChanged += dgvRegistros_SelectionChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(203, 111);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 4;
            // 
            // txtCarrera
            // 
            txtCarrera.Location = new Point(465, 111);
            txtCarrera.Name = "txtCarrera";
            txtCarrera.Size = new Size(200, 23);
            txtCarrera.TabIndex = 6;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(151, 114);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 14;
            lblNombre.Text = "Nombre:";
            // 
            // lblCarrera
            // 
            lblCarrera.AutoSize = true;
            lblCarrera.Location = new Point(409, 114);
            lblCarrera.Name = "lblCarrera";
            lblCarrera.Size = new Size(48, 15);
            lblCarrera.TabIndex = 15;
            lblCarrera.Text = "Carrera:";
            // 
            // lblArchivoActual
            // 
            lblArchivoActual.AutoSize = true;
            lblArchivoActual.ForeColor = SystemColors.HotTrack;
            lblArchivoActual.Location = new Point(642, 25);
            lblArchivoActual.Name = "lblArchivoActual";
            lblArchivoActual.Size = new Size(129, 15);
            lblArchivoActual.TabIndex = 16;
            lblArchivoActual.Text = "Ningún archivo abierto";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(57, 111);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(86, 23);
            txtBuscar.TabIndex = 18;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(12, 114);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(45, 15);
            lblBuscar.TabIndex = 17;
            lblBuscar.Text = "Buscar:";
            // 
            // btnPropiedades
            // 
            btnPropiedades.Location = new Point(264, 58);
            btnPropiedades.Name = "btnPropiedades";
            btnPropiedades.Size = new Size(120, 40);
            btnPropiedades.TabIndex = 19;
            btnPropiedades.Text = "Propiedades";
            btnPropiedades.UseVisualStyleBackColor = true;
            btnPropiedades.Click += btnPropiedades_Click;
            // 
            // btnCrearCarpeta
            // 
            btnCrearCarpeta.Location = new Point(264, 12);
            btnCrearCarpeta.Name = "btnCrearCarpeta";
            btnCrearCarpeta.Size = new Size(120, 40);
            btnCrearCarpeta.TabIndex = 20;
            btnCrearCarpeta.Text = "Crear Carpeta";
            btnCrearCarpeta.UseVisualStyleBackColor = true;
            btnCrearCarpeta.Click += btnCrearCarpeta_Click;
            // 
            // btnRenombrar
            // 
            btnRenombrar.Location = new Point(516, 12);
            btnRenombrar.Name = "btnRenombrar";
            btnRenombrar.Size = new Size(120, 40);
            btnRenombrar.TabIndex = 21;
            btnRenombrar.Text = "Renombrar";
            btnRenombrar.UseVisualStyleBackColor = true;
            btnRenombrar.Click += btnRenombrar_Click;
            // 
            // btnGuardarCambios
            // 
            btnGuardarCambios.Location = new Point(516, 58);
            btnGuardarCambios.Name = "btnGuardarCambios";
            btnGuardarCambios.Size = new Size(120, 40);
            btnGuardarCambios.TabIndex = 22;
            btnGuardarCambios.Text = "Guardar Cambios";
            btnGuardarCambios.UseVisualStyleBackColor = true;
            btnGuardarCambios.Click += btnGuardarCambios_Click;
            // 
            // btnCopiarArchivo
            // 
            btnCopiarArchivo.Location = new Point(642, 58);
            btnCopiarArchivo.Name = "btnCopiarArchivo";
            btnCopiarArchivo.Size = new Size(120, 40);
            btnCopiarArchivo.TabIndex = 23;
            btnCopiarArchivo.Text = "Copiar Archivo";
            btnCopiarArchivo.UseVisualStyleBackColor = true;
            btnCopiarArchivo.Click += btnCopiarArchivo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 450);
            Controls.Add(btnCopiarArchivo);
            Controls.Add(btnGuardarCambios);
            Controls.Add(btnRenombrar);
            Controls.Add(btnCrearCarpeta);
            Controls.Add(btnPropiedades);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(lblArchivoActual);
            Controls.Add(lblCarrera);
            Controls.Add(lblNombre);
            Controls.Add(txtCarrera);
            Controls.Add(txtNombre);
            Controls.Add(dgvRegistros);
            Controls.Add(btnCrearArchivo);
            Controls.Add(btnModificar);
            Controls.Add(btnBuscar);
            Controls.Add(btnEliminarRegistro);
            Controls.Add(btnAgregarRegistro);
            Controls.Add(btnAbrirArchivo);
            Name = "Form1";
            Text = "Gestor de Archivos Secuenciales";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRegistros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAbrirArchivo;
        private Button btnAgregarRegistro;
        private Button btnEliminarRegistro;
        private Button btnBuscar;
        private Button btnModificar;
        private Button btnCrearArchivo;
        private DataGridView dgvRegistros;
        private TextBox txtNombre;
        private TextBox txtCarrera;
        private Label lblNombre;
        private Label lblCarrera;
        private Label lblArchivoActual;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private Button btnPropiedades;
        private Button btnCrearCarpeta;
        private Button btnRenombrar;
        private Button btnGuardarCambios;
        private Button btnCopiarArchivo;
    }
}