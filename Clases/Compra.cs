namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases
{
    // Tabla: Compras (con su lista de detalles)
    public class Compra
    {
        public int IdCompra { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaCompra { get; set; } = DateTime.Now;
        public decimal Total => Detalles.Sum(d => d.Subtotal);
        public string Estado { get; set; } = "Registrada";

        // Solo para mostrar
        public string? NombreProveedor { get; set; }

        public List<DetalleCompra> Detalles { get; set; } = new List<DetalleCompra>();

        public Compra() { }

        public Compra(int idProveedor, DateTime fechaCompra)
        {
            IdProveedor = idProveedor;
            FechaCompra = fechaCompra;
        }

        // Si el producto ya está en la lista suma la cantidad; si no, agrega una línea nueva
        public void AgregarDetalle(DetalleCompra detalle)
        {
            var existente = Detalles.FirstOrDefault(d => d.IdProducto == detalle.IdProducto);
            if (existente != null)
            {
                existente.Cantidad += detalle.Cantidad;
                existente.PrecioCosto = detalle.PrecioCosto;
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
