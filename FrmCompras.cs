using Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Metodos;
using System;
using System.Windows.Forms;

namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class FrmCompras : Form
    {
        public FrmCompras()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            Funcion_de_Regreso_Boton.Regreso(this);
        }
    }
}
