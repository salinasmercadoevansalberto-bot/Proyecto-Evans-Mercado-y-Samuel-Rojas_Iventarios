namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios
{
    partial class FrmCompras
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
            label2 = new Label();
            label1 = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            txtCompra = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            cmbProducto = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            txtCantidad = new TextBox();
            txtPrecioCosto = new TextBox();
            btnAgregarProducto = new Button();
            label9 = new Label();
            dgvDetalleCompra = new DataGridView();
            NombredelProveedor = new DataGridViewTextBoxColumn();
            FechaCompra = new DataGridViewTextBoxColumn();
            Producto = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            PrecioCosto = new DataGridViewTextBoxColumn();
            lblTotal = new Label();
            btnCancelar = new Button();
            btnRegistrarCompra = new Button();
            btnQuitarProducto = new Button();
            label10 = new Label();
            btnRetroceder = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleCompra).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(12, 56);
            label2.Name = "label2";
            label2.Size = new Size(348, 26);
            label2.TabIndex = 26;
            label2.Text = "Ingreso de productos al inventario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(283, 35);
            label1.TabIndex = 25;
            label1.Text = "Registro de Compras";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 134);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(368, 27);
            txtNombre.TabIndex = 28;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(12, 95);
            label3.Name = "label3";
            label3.Size = new Size(237, 26);
            label3.TabIndex = 27;
            label3.Text = "Nombre del proveedor:";
            // 
            // txtCompra
            // 
            txtCompra.Location = new Point(12, 222);
            txtCompra.Name = "txtCompra";
            txtCompra.Size = new Size(368, 27);
            txtCompra.TabIndex = 30;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(12, 183);
            label4.Name = "label4";
            label4.Size = new Size(186, 26);
            label4.TabIndex = 29;
            label4.Text = "Fecha de compra:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(12, 291);
            label5.Name = "label5";
            label5.Size = new Size(189, 26);
            label5.TabIndex = 31;
            label5.Text = "Agregar producto:";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(12, 344);
            label6.Name = "label6";
            label6.Size = new Size(107, 26);
            label6.TabIndex = 32;
            label6.Text = "Producto:";
            // 
            // cmbProducto
            // 
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(12, 373);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(247, 28);
            cmbProducto.TabIndex = 33;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.Location = new Point(12, 444);
            label7.Name = "label7";
            label7.Size = new Size(106, 26);
            label7.TabIndex = 34;
            label7.Text = "Cantidad:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ControlLightLight;
            label8.Location = new Point(273, 444);
            label8.Name = "label8";
            label8.Size = new Size(174, 26);
            label8.TabIndex = 35;
            label8.Text = "Precio de Costo:";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(12, 482);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(237, 27);
            txtCantidad.TabIndex = 36;
            // 
            // txtPrecioCosto
            // 
            txtPrecioCosto.Location = new Point(273, 482);
            txtPrecioCosto.Name = "txtPrecioCosto";
            txtPrecioCosto.Size = new Size(237, 27);
            txtPrecioCosto.TabIndex = 37;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.BackColor = Color.RoyalBlue;
            btnAgregarProducto.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarProducto.ForeColor = SystemColors.ControlLightLight;
            btnAgregarProducto.Location = new Point(12, 515);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(498, 48);
            btnAgregarProducto.TabIndex = 38;
            btnAgregarProducto.Text = "Agregar al detalle";
            btnAgregarProducto.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(13, 598);
            label9.Name = "label9";
            label9.Size = new Size(222, 26);
            label9.TabIndex = 39;
            label9.Text = "Detalle de la compra:";
            // 
            // dgvDetalleCompra
            // 
            dgvDetalleCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleCompra.Columns.AddRange(new DataGridViewColumn[] { NombredelProveedor, FechaCompra, Producto, Cantidad, PrecioCosto });
            dgvDetalleCompra.Location = new Point(13, 638);
            dgvDetalleCompra.Name = "dgvDetalleCompra";
            dgvDetalleCompra.RowHeadersWidth = 51;
            dgvDetalleCompra.Size = new Size(681, 109);
            dgvDetalleCompra.TabIndex = 42;
            // 
            // NombredelProveedor
            // 
            NombredelProveedor.HeaderText = "Nombre del Proveedor";
            NombredelProveedor.MinimumWidth = 6;
            NombredelProveedor.Name = "NombredelProveedor";
            NombredelProveedor.Width = 125;
            // 
            // FechaCompra
            // 
            FechaCompra.HeaderText = "Fecha de Compra";
            FechaCompra.MinimumWidth = 6;
            FechaCompra.Name = "FechaCompra";
            FechaCompra.Width = 125;
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
            PrecioCosto.HeaderText = "Precio de costo";
            PrecioCosto.MinimumWidth = 6;
            PrecioCosto.Name = "PrecioCosto";
            PrecioCosto.Width = 125;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = SystemColors.ControlLightLight;
            lblTotal.Location = new Point(12, 760);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(67, 26);
            lblTotal.TabIndex = 43;
            lblTotal.Text = "Total:";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.RoyalBlue;
            btnCancelar.ForeColor = SystemColors.ControlLightLight;
            btnCancelar.Location = new Point(563, 552);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(131, 48);
            btnCancelar.TabIndex = 47;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarCompra
            // 
            btnRegistrarCompra.BackColor = Color.RoyalBlue;
            btnRegistrarCompra.ForeColor = SystemColors.ControlLightLight;
            btnRegistrarCompra.Location = new Point(713, 482);
            btnRegistrarCompra.Name = "btnRegistrarCompra";
            btnRegistrarCompra.Size = new Size(131, 48);
            btnRegistrarCompra.TabIndex = 45;
            btnRegistrarCompra.Text = "Registrar compra";
            btnRegistrarCompra.UseVisualStyleBackColor = false;
            // 
            // btnQuitarProducto
            // 
            btnQuitarProducto.BackColor = Color.RoyalBlue;
            btnQuitarProducto.ForeColor = SystemColors.ControlLightLight;
            btnQuitarProducto.Location = new Point(563, 482);
            btnQuitarProducto.Name = "btnQuitarProducto";
            btnQuitarProducto.Size = new Size(131, 48);
            btnQuitarProducto.TabIndex = 44;
            btnQuitarProducto.Text = "Quitar Producto";
            btnQuitarProducto.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(884, 55);
            label10.Name = "label10";
            label10.Size = new Size(69, 35);
            label10.TabIndex = 49;
            label10.Text = "<==";
            // 
            // btnRetroceder
            // 
            btnRetroceder.Location = new Point(959, 50);
            btnRetroceder.Name = "btnRetroceder";
            btnRetroceder.Size = new Size(117, 40);
            btnRetroceder.TabIndex = 48;
            btnRetroceder.Text = "Retroceder";
            btnRetroceder.UseVisualStyleBackColor = true;
            // 
            // FrmCompras
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(1161, 808);
            Controls.Add(label10);
            Controls.Add(btnRetroceder);
            Controls.Add(btnCancelar);
            Controls.Add(btnRegistrarCompra);
            Controls.Add(btnQuitarProducto);
            Controls.Add(lblTotal);
            Controls.Add(dgvDetalleCompra);
            Controls.Add(label9);
            Controls.Add(btnAgregarProducto);
            Controls.Add(txtPrecioCosto);
            Controls.Add(txtCantidad);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(cmbProducto);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtCompra);
            Controls.Add(label4);
            Controls.Add(txtNombre);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmCompras";
            Text = "Compras";
            ((System.ComponentModel.ISupportInitialize)dgvDetalleCompra).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label label2;
        private Label label1;
        private TextBox txtNombre;
        private Label label3;
        private TextBox txtCompra;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox cmbProducto;
        private Label label7;
        private Label label8;
        private TextBox txtCantidad;
        private TextBox txtPrecioCosto;
        private Button btnAgregarProducto;
        private Label label9;
        private DataGridView dgvDetalleCompra;
        private DataGridViewTextBoxColumn NombredelProveedor;
        private DataGridViewTextBoxColumn FechaCompra;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn PrecioCosto;
        private Label lblTotal;
        private Button btnCancelar;
        private Button btnRegistrarCompra;
        private Button btnQuitarProducto;
        private Label label10;
        private Button btnRetroceder;
    }
}
