using System;
using System.Windows.Forms;

namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnRetroceder_Click_1(object sender, EventArgs e)
        {
            Funcion_de_Regreso_Boton.Regreso(this);
        }
    }
}
