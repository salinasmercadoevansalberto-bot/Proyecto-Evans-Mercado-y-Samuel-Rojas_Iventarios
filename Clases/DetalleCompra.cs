namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases
{
    // Tabla: DetalleCompra
    public class DetalleCompra
    {
        public int IdDetalleCompra { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCosto { get; set; }

        // Solo para mostrar en el DataGridView
        public string? NombreProducto { get; set; }

        public decimal Subtotal => Cantidad * PrecioCosto;

        public DetalleCompra() { }

        public DetalleCompra(int idProducto, string? nombreProducto, int cantidad, decimal precioCosto)
        {
            IdProducto = idProducto;
            NombreProducto = nombreProducto;
            Cantidad = cantidad;
            PrecioCosto = precioCosto;
        }
    }
}
