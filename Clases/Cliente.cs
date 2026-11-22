namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases
{
    // Tabla: Clientes
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string? Cedula { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public bool Estado { get; set; } = true;

        public Cliente() { }

        public Cliente(int idCliente, string nombre, string? cedula, string? telefono,
                       string? correo, string? direccion, bool estado = true, string codigo = "")
        {
            IdCliente = idCliente;
            Codigo = codigo;
            Nombre = nombre;
            Cedula = cedula;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
            Estado = estado;
        }

        public string CodigoNombre => $"{Codigo} - {Nombre}";

        public override string ToString() => CodigoNombre;
    }
}
