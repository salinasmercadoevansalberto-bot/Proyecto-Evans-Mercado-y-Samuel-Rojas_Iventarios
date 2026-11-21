namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases
{
    // Tabla: Categorias
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }

        public Categoria() { }

        public Categoria(int idCategoria, string nombre, string? descripcion)
        {
            IdCategoria = idCategoria;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        // Para mostrarla directamente en ListBox / ComboBox
        public override string ToString() => Nombre;
    }
}
