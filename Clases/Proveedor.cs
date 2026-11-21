namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases
{
    // Tabla: Proveedores
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public bool Estado { get; set; } = true;

        public Proveedor() { }

        public Proveedor(int idProveedor, string nombre, string? telefono,
                         string? correo, string? direccion, bool estado = true)
        {
            IdProveedor = idProveedor;
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
            Estado = estado;
        }

        public override string ToString() => Nombre;
    }
}
