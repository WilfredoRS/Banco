using Banco.CapaDatos.Banco.CapaDatos;
using Banco.capalogica.Banco.CapaDatos.capalogica;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Banco.CapaDatos.capalogica.capapresentacion
{
    public partial class Equipos : System.Web.UI.Page
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
            using (SqlCommand cmd = new SqlCommand(
                "SELECT e.EquipoID, e.TipoEquipo, e.Modelo, e.UsuarioID, u.Nombre AS Usuario " +
                "FROM Equipos e INNER JOIN Usuarios u ON e.UsuarioID = u.UsuarioID", con))
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
            txtEquipoID.Text = "";
            txtTipo.Text = "";
            txtModelo.Text = "";
            txtUsuarioID.Text = "";
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
                    lblMensaje.Text = "Ya existe un equipo con ese código.";
                else if (ex.Number == 547)
                    lblMensaje.Text = "El usuario indicado no existe.";
                else
                    lblMensaje.Text = "Error de base de datos: " + ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        private bool Leer(out cls_equipo eq)
        {
            eq = null;
            int id, usuario;
            if (!int.TryParse(txtEquipoID.Text, out id) ||
                !int.TryParse(txtUsuarioID.Text, out usuario) ||
                string.IsNullOrWhiteSpace(txtTipo.Text) ||
                string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                lblMensaje.Text = "Completa código, tipo, modelo y código del usuario.";
                return false;
            }
            eq = new cls_equipo
            {
                EquipoID = id,
                TipoEquipo = txtTipo.Text.Trim(),
                Modelo = txtModelo.Text.Trim(),
                UsuarioID = usuario
            };
            return true;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            cls_equipo eq;
            if (!Leer(out eq)) return;
            Ejecutar(() => equipologic.Agregar(eq), "Equipo agregado.", "No se agregó el equipo.");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            cls_equipo eq;
            if (!Leer(out eq)) return;
            Ejecutar(() => equipologic.Modificar(eq), "Equipo actualizado.", "No existe un equipo con ese código.");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtEquipoID.Text, out id))
            {
                lblMensaje.Text = "Escribe el código del equipo que quieres borrar.";
                return;
            }
            Ejecutar(() => equipologic.Eliminar(id), "Equipo eliminado.", "No existe un equipo con ese código.");
        }
    }
}