namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios
{
    partial class FrmVentas
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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbCliente = new ComboBox();
            label4 = new Label();
            dtpFechaVenta = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            cmbProducto = new ComboBox();
            label7 = new Label();
            txtCantidad = new TextBox();
            txtPrecioVenta = new TextBox();
            label8 = new Label();
            btnAgregarProducto = new Button();
            label9 = new Label();
            dgvDetalleVenta = new DataGridView();
            NombredelCliente = new DataGridViewTextBoxColumn();
            FechaVenta = new DataGridViewTextBoxColumn();
            Producto = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            PrecioCosto = new DataGridViewTextBoxColumn();
            lblTotal = new Label();
            btnCancelar = new Button();
            btnRegistrarVenta = new Button();
            btnQuitarProducto = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(12, 95);
            label3.Name = "label3";
            label3.Size = new Size(193, 26);
            label3.TabIndex = 31;
            label3.Text = "Cliente (opcional):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(12, 56);
            label2.Name = "label2";
            label2.Size = new Size(497, 26);
            label2.TabIndex = 30;
            label2.Text = "Venta de productos y actualización del inventario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(249, 35);
            label1.TabIndex = 29;
            label1.Text = "Registro de Ventas";
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(14, 124);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(247, 28);
            cmbCliente.TabIndex = 34;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(12, 176);
            label4.Name = "label4";
            label4.Size = new Size(168, 26);
            label4.TabIndex = 35;
            label4.Text = "Fecha de venta:";
            // 
            // dtpFechaVenta
            // 
            dtpFechaVenta.Location = new Point(14, 205);
            dtpFechaVenta.Name = "dtpFechaVenta";
            dtpFechaVenta.Size = new Size(296, 27);
            dtpFechaVenta.TabIndex = 37;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(14, 266);
            label5.Name = "label5";
            label5.Size = new Size(208, 30);
            label5.TabIndex = 38;
            label5.Text = "Agregar producto";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(14, 316);
            label6.Name = "label6";
            label6.Size = new Size(107, 26);
            label6.TabIndex = 39;
            label6.Text = "Producto:";
            // 
            // cmbProducto
            // 
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(14, 345);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(247, 28);
            cmbProducto.TabIndex = 40;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.Location = new Point(14, 389);
            label7.Name = "label7";
            label7.Size = new Size(106, 26);
            label7.TabIndex = 41;
            label7.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(14, 418);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(106, 27);
            txtCantidad.TabIndex = 42;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(165, 418);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(172, 27);
            txtPrecioVenta.TabIndex = 44;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ControlLightLight;
            label8.Location = new Point(165, 389);
            label8.Name = "label8";
            label8.Size = new Size(172, 26);
            label8.TabIndex = 43;
            label8.Text = "Precio de venta:";
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.BackColor = Color.RoyalBlue;
            btnAgregarProducto.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarProducto.ForeColor = SystemColors.ControlLightLight;
            btnAgregarProducto.Location = new Point(11, 465);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(326, 48);
            btnAgregarProducto.TabIndex = 45;
            btnAgregarProducto.Text = "Agregar al detalle";
            btnAgregarProducto.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(14, 553);
            label9.Name = "label9";
            label9.Size = new Size(226, 30);
            label9.TabIndex = 46;
            label9.Text = "Detalle de la venta";
            // 
            // dgvDetalleVenta
            // 
            dgvDetalleVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleVenta.Columns.AddRange(new DataGridViewColumn[] { NombredelCliente, FechaVenta, Producto, Cantidad, PrecioCosto });
            dgvDetalleVenta.Location = new Point(11, 595);
            dgvDetalleVenta.Name = "dgvDetalleVenta";
            dgvDetalleVenta.RowHeadersWidth = 51;
            dgvDetalleVenta.Size = new Size(681, 109);
            dgvDetalleVenta.TabIndex = 47;
            // 
            // NombredelCliente
            // 
            NombredelCliente.HeaderText = "Nombre del Cliente";
            NombredelCliente.MinimumWidth = 6;
            NombredelCliente.Name = "NombredelCliente";
            NombredelCliente.Width = 125;
            // 
            // FechaVenta
            // 
            FechaVenta.HeaderText = "Fecha de Venta";
            FechaVenta.MinimumWidth = 6;
            FechaVenta.Name = "FechaVenta";
            FechaVenta.Width = 125;
            // 
            // Producto
            // 
            Producto.HeaderText = "Producto";
            Producto.MinimumWidth = 6;
            Producto.Name = "Producto";
            Producto.Width = 125;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.MinimumWidth = 6;
            Cantidad.Name = "Cantidad";
            Cantidad.Width = 125;
            // 
            // PrecioCosto
            // 
            PrecioCosto.HeaderText = "Precio de Venta";
            PrecioCosto.MinimumWidth = 6;
            PrecioCosto.Name = "PrecioCosto";
            PrecioCosto.Width = 125;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = SystemColors.ControlLightLight;
            lblTotal.Location = new Point(14, 717);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(67, 26);
            lblTotal.TabIndex = 48;
            lblTotal.Text = "Total:";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.RoyalBlue;
            btnCancelar.ForeColor = SystemColors.ControlLightLight;
            btnCancelar.Location = new Point(464, 535);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(131, 48);
            btnCancelar.TabIndex = 51;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.BackColor = Color.RoyalBlue;
            btnRegistrarVenta.ForeColor = SystemColors.ControlLightLight;
            btnRegistrarVenta.Location = new Point(614, 465);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(131, 48);
            btnRegistrarVenta.TabIndex = 50;
            btnRegistrarVenta.Text = "Registrar venta";
            btnRegistrarVenta.UseVisualStyleBackColor = false;
            // 
            // btnQuitarProducto
            // 
            btnQuitarProducto.BackColor = Color.RoyalBlue;
            btnQuitarProducto.ForeColor = SystemColors.ControlLightLight;
            btnQuitarProducto.Location = new Point(464, 465);
            btnQuitarProducto.Name = "btnQuitarProducto";
            btnQuitarProducto.Size = new Size(131, 48);
            btnQuitarProducto.TabIndex = 49;
            btnQuitarProducto.Text = "Quitar Producto";
            btnQuitarProducto.UseVisualStyleBackColor = false;
            // 
            // FrmVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(765, 760);
            Controls.Add(btnCancelar);
            Controls.Add(btnRegistrarVenta);
            Controls.Add(btnQuitarProducto);
            Controls.Add(lblTotal);
            Controls.Add(dgvDetalleVenta);
            Controls.Add(label9);
            Controls.Add(btnAgregarProducto);
            Controls.Add(txtPrecioVenta);
            Controls.Add(label8);
            Controls.Add(txtCantidad);
            Controls.Add(label7);
            Controls.Add(cmbProducto);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dtpFechaVenta);
            Controls.Add(label4);
            Controls.Add(cmbCliente);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmVentas";
            Text = "Ventas";
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cmbCliente;
        private Label label4;
        private DateTimePicker dtpFechaVenta;
        private Label label5;
        private Label label6;
        private ComboBox cmbProducto;
        private Label label7;
        private TextBox txtCantidad;
        private TextBox txtPrecioVenta;
        private Label label8;
        private Button btnAgregarProducto;
        private Label label9;
        private DataGridView dgvDetalleVenta;
        private DataGridViewTextBoxColumn NombredelCliente;
        private DataGridViewTextBoxColumn FechaVenta;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn PrecioCosto;
        private Label lblTotal;
        private Button btnCancelar;
        private Button btnRegistrarVenta;
        private Button btnQuitarProducto;
    }
}
