namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios
{
    partial class FrmProveedores
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnGuardar = new Button();
            txtCorreo = new TextBox();
            label6 = new Label();
            txtTelefono = new TextBox();
            label5 = new Label();
            txtDireccion = new TextBox();
            label4 = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvProveedores = new DataGridView();
            txtBuscar = new TextBox();
            label9 = new Label();
            NombredelProveedor = new DataGridViewTextBoxColumn();
            Telefono = new DataGridViewTextBoxColumn();
            CorreoElectronico = new DataGridViewTextBoxColumn();
            Direccion = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            SuspendLayout();
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.RoyalBlue;
            btnLimpiar.ForeColor = SystemColors.ControlLightLight;
            btnLimpiar.Location = new Point(51, 528);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(131, 48);
            btnLimpiar.TabIndex = 38;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.RoyalBlue;
            btnEliminar.ForeColor = SystemColors.ControlLightLight;
            btnEliminar.Location = new Point(349, 458);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(131, 48);
            btnEliminar.TabIndex = 37;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.RoyalBlue;
            btnModificar.ForeColor = SystemColors.ControlLightLight;
            btnModificar.Location = new Point(201, 458);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(131, 48);
            btnModificar.TabIndex = 36;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.RoyalBlue;
            btnGuardar.ForeColor = SystemColors.ControlLightLight;
            btnGuardar.Location = new Point(51, 458);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(131, 48);
            btnGuardar.TabIndex = 35;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(51, 310);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(368, 27);
            txtCorreo.TabIndex = 32;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(51, 271);
            label6.Name = "label6";
            label6.Size = new Size(200, 26);
            label6.TabIndex = 31;
            label6.Text = "Correo electronico:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(51, 226);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(368, 27);
            txtTelefono.TabIndex = 30;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(51, 187);
            label5.Name = "label5";
            label5.Size = new Size(103, 26);
            label5.TabIndex = 29;
            label5.Text = "Telefono:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(51, 395);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(368, 27);
            txtDireccion.TabIndex = 28;
            txtDireccion.TextChanged += txtCedula_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(51, 356);
            label4.Name = "label4";
            label4.Size = new Size(111, 26);
            label4.TabIndex = 27;
            label4.Text = "Direccion:";
            label4.Click += this.label4_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(51, 141);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(368, 27);
            txtNombre.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(51, 102);
            label3.Name = "label3";
            label3.Size = new Size(237, 26);
            label3.TabIndex = 25;
            label3.Text = "Nombre del proveedor:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(51, 56);
            label2.Name = "label2";
            label2.Size = new Size(468, 26);
            label2.TabIndex = 24;
            label2.Text = "Registro de empresas y personas proveedoras";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(51, 9);
            label1.Name = "label1";
            label1.Size = new Size(408, 35);
            label1.TabIndex = 23;
            label1.Text = "Administracion de Proveedores";
            // 
            // dgvProveedores
            // 
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Columns.AddRange(new DataGridViewColumn[] { NombredelProveedor, Telefono, CorreoElectronico, Direccion });
            dgvProveedores.Location = new Point(12, 697);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.RowHeadersWidth = 51;
            dgvProveedores.Size = new Size(745, 87);
            dgvProveedores.TabIndex = 41;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(12, 653);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(281, 27);
            txtBuscar.TabIndex = 40;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(12, 615);
            label9.Name = "label9";
            label9.Size = new Size(260, 26);
            label9.TabIndex = 39;
            label9.Text = "Proveedores Registrados";
            // 
            // NombredelProveedor
            // 
            NombredelProveedor.HeaderText = "Nombre del Proveedor";
            NombredelProveedor.MinimumWidth = 6;
            NombredelProveedor.Name = "NombredelProveedor";
            NombredelProveedor.Width = 125;
            // 
            // Telefono
            // 
            Telefono.HeaderText = "Telefono";
            Telefono.MinimumWidth = 6;
            Telefono.Name = "Telefono";
            Telefono.Width = 125;
            // 
            // CorreoElectronico
            // 
            CorreoElectronico.HeaderText = "Correo Electronico";
            CorreoElectronico.MinimumWidth = 6;
            CorreoElectronico.Name = "CorreoElectronico";
            CorreoElectronico.Width = 125;
            // 
            // Direccion
            // 
            Direccion.HeaderText = "Direccion";
            Direccion.MinimumWidth = 6;
            Direccion.Name = "Direccion";
            Direccion.Width = 125;
            // 
            // FrmProveedores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(726, 863);
            Controls.Add(dgvProveedores);
            Controls.Add(txtBuscar);
            Controls.Add(label9);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnGuardar);
            Controls.Add(txtCorreo);
            Controls.Add(label6);
            Controls.Add(txtTelefono);
            Controls.Add(label5);
            Controls.Add(txtDireccion);
            Controls.Add(label4);
            Controls.Add(txtNombre);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmProveedores";
            Text = "Proveedores";
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnGuardar;
        private TextBox txtCorreo;
        private Label label6;
        private TextBox txtTelefono;
        private Label label5;
        private TextBox txtDireccion;
        private Label label4;
        private TextBox txtNombre;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dgvProveedores;
        private DataGridViewTextBoxColumn NombredelProveedor;
        private DataGridViewTextBoxColumn Telefono;
        private DataGridViewTextBoxColumn CorreoElectronico;
        private DataGridViewTextBoxColumn Direccion;
        private TextBox txtBuscar;
        private Label label9;
    }
}
