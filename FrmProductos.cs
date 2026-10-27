using Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Metodos;
using System;
using System.Windows.Forms;

namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Funcion_de_Regreso_Boton.Regreso(this);
        }
    }
}
