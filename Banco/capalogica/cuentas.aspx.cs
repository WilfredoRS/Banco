using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Banco.CapaDatos.capalogica.capapresentacion
{
    public partial class Cuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM cuentacliente", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
            }
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
                    lblMensaje.Text = "Ya existe una cuenta con ese código.";
                else if (ex.Number == 547)
                    lblMensaje.Text = "El cliente indicado no existe.";
                else
                    lblMensaje.Text = "Error de base de datos: " + ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtTipo.Text = "";
            txtCodigoCliente.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int codigo, cliente;
            if (!int.TryParse(txtCodigo.Text, out codigo) ||
                !int.TryParse(txtCodigoCliente.Text, out cliente) ||
                string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                lblMensaje.Text = "Completa código, tipo y código del cliente.";
                return;
            }
            Ejecutar(() => capalogica.cuentalogic.Agregarcuenta(codigo, txtTipo.Text.Trim(), cliente),
                     "Cuenta agregada.", "No se agregó la cuenta.");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int codigo, cliente;
            if (!int.TryParse(txtCodigo.Text, out codigo) ||
                !int.TryParse(txtCodigoCliente.Text, out cliente) ||
                string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                lblMensaje.Text = "Completa código, tipo y código del cliente.";
                return;
            }
            Ejecutar(() => capalogica.cuentalogic.Modificarcuenta(codigo, txtTipo.Text.Trim(), cliente),
         "Cuenta actualizada.", "No existe una cuenta con ese código.");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int codigo;
            if (!int.TryParse(txtCodigo.Text, out codigo))
            {
                lblMensaje.Text = "Escribe el código de la cuenta que quieres borrar.";
                return;
            }
            Ejecutar(() => capalogica.cuentalogic.Eliminarcuenta(codigo),
          "Cuenta eliminada.", "No existe una cuenta con ese código.");
        }
    }
}