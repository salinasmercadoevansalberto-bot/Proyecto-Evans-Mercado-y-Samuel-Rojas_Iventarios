namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios
{
    partial class FrmClientes
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
            label1 = new Label();
            label2 = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            txtCedula = new TextBox();
            label4 = new Label();
            txtTelefono = new TextBox();
            label5 = new Label();
            txtCorreo = new TextBox();
            label6 = new Label();
            txtDireccion = new TextBox();
            label7 = new Label();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnGuardar = new Button();
            dgvClientes = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            Cedula = new DataGridViewTextBoxColumn();
            Telefono = new DataGridViewTextBoxColumn();
            CorreoElectronico = new DataGridViewTextBoxColumn();
            Direccion = new DataGridViewTextBoxColumn();
            txtBuscar = new TextBox();
            label9 = new Label();
            label10 = new Label();
            btnRetroceder = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(32, 9);
            label1.Name = "label1";
            label1.Size = new Size(357, 35);
            label1.TabIndex = 2;
            label1.Text = "Administracion de Clientes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(32, 56);
            label2.Name = "label2";
            label2.Size = new Size(380, 26);
            label2.TabIndex = 3;
            label2.Text = "Registro y mantenimiento de clientes";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(32, 141);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(368, 27);
            txtNombre.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(32, 102);
            label3.Name = "label3";
            label3.Size = new Size(196, 26);
            label3.TabIndex = 5;
            label3.Text = "Nombre Completo:";
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(32, 230);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(368, 27);
            txtCedula.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(32, 191);
            label4.Name = "label4";
            label4.Size = new Size(86, 26);
            label4.TabIndex = 7;
            label4.Text = "Cedula:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(32, 319);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(368, 27);
            txtTelefono.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(32, 280);
            label5.Name = "label5";
            label5.Size = new Size(103, 26);
            label5.TabIndex = 9;
            label5.Text = "Telefono:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(32, 407);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(368, 27);
            txtCorreo.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(32, 368);
            label6.Name = "label6";
            label6.Size = new Size(200, 26);
            label6.TabIndex = 11;
            label6.Text = "Correo electronico:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(32, 491);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(368, 27);
            txtDireccion.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.Location = new Point(32, 452);
            label7.Name = "label7";
            label7.Size = new Size(111, 26);
            label7.TabIndex = 13;
            label7.Text = "Direccion:";
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.RoyalBlue;
            btnLimpiar.ForeColor = SystemColors.ControlLightLight;
            btnLimpiar.Location = new Point(32, 617);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(131, 48);
            btnLimpiar.TabIndex = 22;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.RoyalBlue;
            btnEliminar.ForeColor = SystemColors.ControlLightLight;
            btnEliminar.Location = new Point(330, 547);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(131, 48);
            btnEliminar.TabIndex = 21;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.RoyalBlue;
            btnModificar.ForeColor = SystemColors.ControlLightLight;
            btnModificar.Location = new Point(182, 547);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(131, 48);
            btnModificar.TabIndex = 20;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.RoyalBlue;
            btnGuardar.ForeColor = SystemColors.ControlLightLight;
            btnGuardar.Location = new Point(32, 547);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(131, 48);
            btnGuardar.TabIndex = 19;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { Nombre, Cedula, Telefono, CorreoElectronico, Direccion });
            dgvClientes.Location = new Point(32, 760);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(745, 87);
            dgvClientes.TabIndex = 25;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.Width = 125;
            // 
            // Cedula
            // 
            Cedula.HeaderText = "Cedula";
            Cedula.MinimumWidth = 6;
            Cedula.Name = "Cedula";
            Cedula.Width = 125;
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
            // txtBuscar
            // 
            txtBuscar.Location = new Point(32, 716);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(281, 27);
            txtBuscar.TabIndex = 24;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(32, 678);
            label9.Name = "label9";
            label9.Size = new Size(217, 26);
            label9.TabIndex = 23;
            label9.Text = "Clientes Registrados";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(632, 47);
            label10.Name = "label10";
            label10.Size = new Size(69, 35);
            label10.TabIndex = 27;
            label10.Text = "<==";
            label10.Click += label10_Click;
            // 
            // btnRetroceder
            // 
            btnRetroceder.Location = new Point(707, 42);
            btnRetroceder.Name = "btnRetroceder";
            btnRetroceder.Size = new Size(117, 40);
            btnRetroceder.TabIndex = 26;
            btnRetroceder.Text = "Retroceder";
            btnRetroceder.UseVisualStyleBackColor = true;
            btnRetroceder.Click += this.btnRetroceder_Click;
            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(863, 859);
            Controls.Add(label10);
            Controls.Add(btnRetroceder);
            Controls.Add(dgvClientes);
            Controls.Add(txtBuscar);
            Controls.Add(label9);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnGuardar);
            Controls.Add(txtDireccion);
            Controls.Add(label7);
            Controls.Add(txtCorreo);
            Controls.Add(label6);
            Controls.Add(txtTelefono);
            Controls.Add(label5);
            Controls.Add(txtCedula);
            Controls.Add(label4);
            Controls.Add(txtNombre);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmClientes";
            Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNombre;
        private Label label3;
        private TextBox txtCedula;
        private Label label4;
        private TextBox txtTelefono;
        private Label label5;
        private TextBox txtCorreo;
        private Label label6;
        private TextBox txtDireccion;
        private Label label7;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnGuardar;
        private DataGridView dgvClientes;
        private TextBox txtBuscar;
        private Label label9;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Cedula;
        private DataGridViewTextBoxColumn Telefono;
        private DataGridViewTextBoxColumn CorreoElectronico;
        private DataGridViewTextBoxColumn Direccion;
        private Label label10;
        private Button btnRetroceder;
    }
}
