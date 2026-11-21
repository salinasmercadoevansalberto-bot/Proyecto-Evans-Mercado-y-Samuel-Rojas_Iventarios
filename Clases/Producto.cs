namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases
{
    // Tabla: Productos
    public class Producto
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public decimal PrecioCosto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Existencias { get; set; }
        public bool Estado { get; set; } = true;

        // Solo para mostrar en el DataGridView (viene del JOIN con Categorias)
        public string? NombreCategoria { get; set; }

        public Producto() { }

        public Producto(int idProducto, int idCategoria, string codigo, string nombre,
                        decimal precioCosto, decimal precioVenta, int existencias, bool estado = true)
        {
            IdProducto = idProducto;
            IdCategoria = idCategoria;
            Codigo = codigo;
            Nombre = nombre;
            PrecioCosto = precioCosto;
            PrecioVenta = precioVenta;
            Existencias = existencias;
            Estado = estado;
        }

        public decimal Ganancia => PrecioVenta - PrecioCosto;

        public bool HayStock(int cantidad) => cantidad > 0 && Existencias >= cantidad;

        public override string ToString() => Nombre;
    }
}
