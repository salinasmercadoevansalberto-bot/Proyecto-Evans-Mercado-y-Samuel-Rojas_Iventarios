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
                this.Close();
            }
        }
    }
}
