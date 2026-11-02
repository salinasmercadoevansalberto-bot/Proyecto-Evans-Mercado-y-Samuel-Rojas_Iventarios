using System;
using System.Windows.Forms;
namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                            "¿Está seguro de que desea salir?",
                            "Confirmar salida",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        //
        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FrmCategorias formulario = new FrmCategorias();
            this.Hide();
            formulario.ShowDialog();
            this.Show();
        }//nos permite abrir el formulario de categorias al hacer click en el boton de categorias
        //
        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes formulario = new FrmClientes();
            this.Hide();
            formulario.ShowDialog();
            this.Show();
        }//nos permite abrir el formulario de clientes al hacer click en el boton de clientes
        //
        private void btnCompras_Click(object sender, EventArgs e)
        {
            FrmCompras formulario = new FrmCompras();
            this.Hide();
            formulario.ShowDialog();
            this.Show();
        }//nos permite abrir el formulario de compras al hacer click en el boton de compras
        //
        private void btnProductos_Click(object sender, EventArgs e)
        {
            FrmProductos formulario = new FrmProductos();
            this.Hide();
            formulario.ShowDialog();
            this.Show();
        }// nos permite abrir el formulario de productos al hacer click en el boton de productos
        //
        private void btnProveedores_Click(object sender, EventArgs e)
        {
            FrmProveedores formulario = new FrmProveedores();
            this.Hide();
            formulario.ShowDialog();
            this.Show();
        }//nos permite abrir el formulario de proveedores al hacer click en el boton de proveedores
        //
        private void btnVentas_Click(object sender, EventArgs e)
        {
            FrmVentas formulario = new FrmVentas();
            this.Hide();
            formulario.ShowDialog();
            this.Show();
        }//nos permite abrir el formulario de ventas al hacer click en el boton de ventas
    }
}
