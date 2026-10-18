using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios
{
    internal class Funcion_de_Regreso
    {
        public static void Regreso()
        {
            Menuprincipal formulario = new Menuprincipal();
            formulario.ShowDialog();
            this.Close();
        }
    }
}
