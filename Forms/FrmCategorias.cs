using Microsoft.Data.SqlClient;
using Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Clases;
using Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios.Metodos;

namespace Proyecto_Evans_Mercado_y_Samuel_Rojas_Iventarios
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class FrmCategorias : Form
    {
        private readonly BaseDatosCategoria _baseDatosCategoria = new BaseDatosCategoria();

        // Validaciones del formulario: el nombre es obligatorio y respeta el máximo definido en SQL.
        private bool ValidarCampos()
        {
            string nombre = txtNombre.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingrese el nombre de la categoría.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (nombre.Length > 80)
            {
                MessageBox.Show("El nombre no puede superar los 80 caracteres.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (descripcion.Length > 200)
            {
                MessageBox.Show("La descripción no puede superar los 200 caracteres.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            return true;
        }

        public FrmCategorias()
        {
            InitializeComponent();
            txtNombre.MaxLength = 80;
            txtDescripcion.MaxLength = 200;
        }

        // Carga las categorías al abrir el formulario.
        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        // Carga las categorías en el ListBox mostrando el nombre y conservando su ID.
        private void CargarCategorias()
        {
            try
            {
                lstCategorias.DataSource = null;
                lstCategorias.DisplayMember = nameof(Categoria.Nombre);
                lstCategorias.ValueMember = nameof(Categoria.IdCategoria);
                lstCategorias.DataSource = _baseDatosCategoria.Listar();
                lstCategorias.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las categorías: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Copia al formulario la categoría seleccionada.
        private void lstCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCategorias.SelectedItem is Categoria categoria)
            {
                txtNombre.Text = categoria.Nombre;
                txtDescripcion.Text = categoria.Descripcion ?? string.Empty;
            }
        }

        // Guarda una nueva categoría.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                Categoria categoria = new Categoria
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text)
                        ? null
                        : txtDescripcion.Text.Trim()
                };

                _baseDatosCategoria.Registrar(categoria);
                MessageBox.Show("Categoría registrada correctamente.", "Categorías",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCategorias();
                LimpiarCampos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudo registrar la categoría: " + ex.Message,
                    "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Modifica la categoría seleccionada.
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (lstCategorias.SelectedItem is not Categoria seleccionada)
            {
                MessageBox.Show("Seleccione una categoría para modificar.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                seleccionada.Nombre = txtNombre.Text.Trim();
                seleccionada.Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text)
                    ? null
                    : txtDescripcion.Text.Trim();

                if (!_baseDatosCategoria.Modificar(seleccionada))
                {
                    MessageBox.Show("La categoría seleccionada ya no existe.", "Categorías",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarCategorias();
                    return;
                }

                MessageBox.Show("Categoría modificada correctamente.", "Categorías",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCategorias();
                LimpiarCampos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudo modificar la categoría: " + ex.Message,
                    "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Elimina la categoría seleccionada si no tiene productos relacionados.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstCategorias.SelectedItem is not Categoria seleccionada)
            {
                MessageBox.Show("Seleccione una categoría para eliminar.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                $"¿Desea eliminar la categoría \"{seleccionada.Nombre}\"?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (!_baseDatosCategoria.Eliminar(seleccionada.IdCategoria))
                {
                    MessageBox.Show("La categoría seleccionada ya no existe.", "Categorías",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarCategorias();
                    return;
                }

                MessageBox.Show("Categoría eliminada correctamente.", "Categorías",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCategorias();
                LimpiarCampos();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("La categoría sí está asociada a productos.",
                    "Categoría en uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudo eliminar la categoría: " + ex.Message,
                    "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Limpia los campos y quita la selección.
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Deja el formulario listo para ingresar o seleccionar otra categoría.
        private void LimpiarCampos()
        {
            lstCategorias.SelectedIndex = -1;
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtNombre.Focus();
        }

        // Regresa al formulario anterior.
        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            Funcion_de_Regreso_Boton.Regreso(this);
        }
    }
}
