namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases
{
    // Tabla: Ventas (con su lista de detalles)
    public class Venta
    {
        public int IdVenta { get; set; }
        public int? IdCliente { get; set; }   // En la BD es NULL (venta a cliente general)
        public DateTime FechaVenta { get; set; } = DateTime.Now;
        public decimal Total => Detalles.Sum(d => d.Subtotal);
        public string Estado { get; set; } = "Registrada";

        // Solo para mostrar
        public string? NombreCliente { get; set; }

        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();

        public Venta() { }

        public Venta(int? idCliente, DateTime fechaVenta)
        {
            IdCliente = idCliente;
            FechaVenta = fechaVenta;
        }

        public void AgregarDetalle(DetalleVenta detalle)
        {
            var existente = Detalles.FirstOrDefault(d => d.IdProducto == detalle.IdProducto);
            if (existente != null)
            {
                existente.Cantidad += detalle.Cantidad;
                existente.PrecioUnitario = detalle.PrecioUnitario;
            }
            else
            {
                Detalles.Add(detalle);
            }
        }

        public void QuitarDetalle(int idProducto)
        {
            Detalles.RemoveAll(d => d.IdProducto == idProducto);
        }

        public void Limpiar() => Detalles.Clear();
    }
}
