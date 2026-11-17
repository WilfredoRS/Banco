using Banco.CapaDatos.Banco.CapaDatos;
using Banco.capalogica.Banco.CapaDatos.capalogica;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Banco.CapaDatos.capalogica.capapresentacion
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        private void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
            }
        }

        private void LimpiarCampos()
        {
            txtUsuarioID.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
        }

        private void Ejecutar(Func<int> accion, string mensajeOk, string mensajeSinFilas)
        {
            try
            {
                lblMensaje.Text = accion() > 0 ? mensajeOk : mensajeSinFilas;
                LimpiarCampos();
                LlenarGrid();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    lblMensaje.Text = "Ya existe un usuario con ese código.";
                else if (ex.Number == 547)
                    lblMensaje.Text = "No se puede borrar: el usuario tiene equipos. Borra primero sus equipos.";
                else
                    lblMensaje.Text = "Error de base de datos: " + ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        private bool Leer(out cls_usuario u)
        {
            u = null;
            int id;
            if (!int.TryParse(txtUsuarioID.Text, out id) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                lblMensaje.Text = "Completa código, nombre y correo (el teléfono es opcional).";
                return false;
            }
            u = new cls_usuario
            {
                UsuarioID = id,
                Nombre = txtNombre.Text.Trim(),
                CorreoElectronico = txtCorreo.Text.Trim(),
                Telefono = txtTelefono.Text.Trim()
            };
            return true;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            cls_usuario u;
            if (!Leer(out u)) return;
            Ejecutar(() => usuariologic.Agregar(u), "Usuario agregado.", "No se agregó el usuario.");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            cls_usuario u;
            if (!Leer(out u)) return;
            Ejecutar(() => usuariologic.Modificar(u), "Usuario actualizado.", "No existe un usuario con ese código.");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtUsuarioID.Text, out id))
            {
                lblMensaje.Text = "Escribe el código del usuario que quieres borrar.";
                return;
            }
            Ejecutar(() => usuariologic.Eliminar(id), "Usuario eliminado.", "No existe un usuario con ese código.");
        }
    }
}