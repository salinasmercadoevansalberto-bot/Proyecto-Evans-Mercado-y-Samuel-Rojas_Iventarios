namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios
{
    partial class MenuPrincipal
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnCategorias = new Button();
            btnClientes = new Button();
            btnCompras = new Button();
            btnProductos = new Button();
            btnProveedores = new Button();
            btnVentas = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(81, 19);
            label1.Name = "label1";
            label1.Size = new Size(285, 35);
            label1.TabIndex = 0;
            label1.Text = "Sistema de inventario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(81, 65);
            label2.Name = "label2";
            label2.Size = new Size(469, 26);
            label2.TabIndex = 1;
            label2.Text = "Registro y control de inventario para pulperias";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(81, 101);
            label3.Name = "label3";
            label3.Size = new Size(178, 25);
            label3.TabIndex = 2;
            label3.Text = "Menu Principal";
            // 
            // btnCategorias
            // 
            btnCategorias.BackColor = Color.RoyalBlue;
            btnCategorias.ForeColor = SystemColors.ControlLightLight;
            btnCategorias.Location = new Point(81, 168);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(307, 79);
            btnCategorias.TabIndex = 3;
            btnCategorias.Text = "Categorias";
            btnCategorias.UseVisualStyleBackColor = false;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.RoyalBlue;
            btnClientes.ForeColor = SystemColors.ControlLightLight;
            btnClientes.Location = new Point(81, 296);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(307, 79);
            btnClientes.TabIndex = 4;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = false;
            // 
            // btnCompras
            // 
            btnCompras.BackColor = Color.RoyalBlue;
            btnCompras.ForeColor = SystemColors.ControlLightLight;
            btnCompras.Location = new Point(81, 426);
            btnCompras.Name = "btnCompras";
            btnCompras.Size = new Size(307, 79);
            btnCompras.TabIndex = 5;
            btnCompras.Text = "Compras";
            btnCompras.UseVisualStyleBackColor = false;
            // 
            // btnProductos
            // 
            btnProductos.BackColor = Color.RoyalBlue;
            btnProductos.ForeColor = SystemColors.ControlLightLight;
            btnProductos.Location = new Point(478, 168);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(307, 79);
            btnProductos.TabIndex = 6;
            btnProductos.Text = "Productos";
            btnProductos.UseVisualStyleBackColor = false;
            // 
            // btnProveedores
            // 
            btnProveedores.BackColor = Color.RoyalBlue;
            btnProveedores.ForeColor = SystemColors.ControlLightLight;
            btnProveedores.Location = new Point(478, 296);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(307, 79);
            btnProveedores.TabIndex = 7;
            btnProveedores.Text = "Proveedores";
            btnProveedores.UseVisualStyleBackColor = false;
            // 
            // btnVentas
            // 
            btnVentas.BackColor = Color.RoyalBlue;
            btnVentas.ForeColor = SystemColors.ControlLightLight;
            btnVentas.Location = new Point(478, 426);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(307, 79);
            btnVentas.TabIndex = 8;
            btnVentas.Text = "Ventas";
            btnVentas.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.RoyalBlue;
            btnSalir.ForeColor = SystemColors.ControlLightLight;
            btnSalir.Location = new Point(719, 530);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(108, 43);
            btnSalir.TabIndex = 9;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(865, 599);
            Controls.Add(btnSalir);
            Controls.Add(btnVentas);
            Controls.Add(btnProveedores);
            Controls.Add(btnProductos);
            Controls.Add(btnCompras);
            Controls.Add(btnClientes);
            Controls.Add(btnCategorias);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MenuPrincipal";
            Text = "Menu Principal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnCategorias;
        private Button btnClientes;
        private Button btnCompras;
        private Button btnProductos;
        private Button btnProveedores;
        private Button btnVentas;
        private Button btnSalir;
    }
}
