using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Metodos
{
    internal class ErrorProvider_Metodos
    {


        // Mostrar error cuando el nombre no es válido
        public static void MostrarErrorNombre(
            ErrorProvider errorProvider,
            TextBox txtNombre)
        {
            errorProvider.SetError(
                txtNombre,
                "Ingrese un nombre válido.");

            txtNombre.Focus();
        }

        // Mostrar error cuando un campo está vacío
        public static void MostrarErrorCampoVacio(
            ErrorProvider errorProvider,
            Control control,
            string mensaje)
        {
            errorProvider.SetError(control, mensaje);
            control.Focus();
        }

        // Mostrar error cuando se ingresa un número entero inválido
        public static void MostrarErrorNumero(
            ErrorProvider errorProvider,
            TextBox txtNumero)
        {
            errorProvider.SetError(
                txtNumero,
                "Ingrese un número entero válido.");

            txtNumero.Focus();
        }

        // Mostrar error cuando se ingresa un número decimal inválido
        public static void MostrarErrorDecimal(
            ErrorProvider errorProvider,
            TextBox txtDecimal)
        {
            errorProvider.SetError(
                txtDecimal,
                "Ingrese un número decimal válido.");

            txtDecimal.Focus();
        }

        // Mostrar error cuando el correo no es válido
        public static void MostrarErrorCorreo(
            ErrorProvider errorProvider,
            TextBox txtCorreo)
        {
            errorProvider.SetError(
                txtCorreo,
                "Ingrese un correo electrónico válido.");

            txtCorreo.Focus();
        }

        // Mostrar error cuando el teléfono no es válido
        public static void MostrarErrorTelefono(
            ErrorProvider errorProvider,
            TextBox txtTelefono)
        {
            errorProvider.SetError(
                txtTelefono,
                "Ingrese un número de teléfono válido.");

            txtTelefono.Focus();
        }

        // Limpiar el mensaje de error
        public static void LimpiarError(
            ErrorProvider errorProvider,
            Control control)
        {
            errorProvider.SetError(control, "");
        }



    }
}
