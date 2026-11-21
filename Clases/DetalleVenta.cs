namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases
{
    // Tabla: DetalleVenta
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        // Solo para mostrar en el DataGridView
        public string? NombreProducto { get; set; }

        public decimal Subtotal => Cantidad * PrecioUnitario;

        public DetalleVenta() { }

        public DetalleVenta(int idProducto, string? nombreProducto, int cantidad, decimal precioUnitario)
        {
            IdProducto = idProducto;
            NombreProducto = nombreProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }
    }
}
