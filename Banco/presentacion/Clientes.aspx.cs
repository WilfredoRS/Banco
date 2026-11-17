using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;

namespace Banco.CapaDatos.capalogica.capapresentacion
{
    public partial class Clientes : System.Web.UI.Page
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
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM cliente", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
            }
        }

        private bool LeerSaldo(out float saldo)
        {
            string texto = txtSaldo.Text.Trim().Replace(',', '.');
            return float.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out saldo);
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtEdad.Text = "";
            txtSaldo.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo, edad;
                float saldo;
                if (!int.TryParse(txtCodigo.Text, out codigo) ||
                    !int.TryParse(txtEdad.Text, out edad) ||
                    !LeerSaldo(out saldo) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    lblMensaje.Text = "Completa código, nombre, edad y saldo con valores válidos.";
                    return;
                }

                if (clientelogic.Agregarcliente(codigo, txtNombre.Text.Trim(), edad, saldo) > 0)
                {
                    lblMensaje.Text = "Cliente agregado.";
                    LimpiarCampos();
                    LlenarGrid();
                }
                else
                {
                    lblMensaje.Text = "No se agregó el cliente.";
                }
            }
            catch (SqlException ex)
            {
                lblMensaje.Text = ex.Number == 2627
                    ? "Ya existe un cliente con ese código."
                    : "Error de base de datos: " + ex.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo, edad;
                float saldo;
                if (!int.TryParse(txtCodigo.Text, out codigo) ||
                    !int.TryParse(txtEdad.Text, out edad) ||
                    !LeerSaldo(out saldo) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    lblMensaje.Text = "Completa código, nombre, edad y saldo con valores válidos.";
                    return;
                }

                if (clientelogic.Modificarcliente(codigo, txtNombre.Text.Trim(), edad, saldo) > 0)
                {
                    lblMensaje.Text = "Cliente actualizado.";
                    LimpiarCampos();
                    LlenarGrid();
                }
                else
                {
                    lblMensaje.Text = "No existe un cliente con ese código.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo;
                if (!int.TryParse(txtCodigo.Text, out codigo))
                {
                    lblMensaje.Text = "Escribe el código del cliente que quieres borrar.";
                    return;
                }

                if (clientelogic.Eliminarcliente(codigo) > 0)
                {
                    lblMensaje.Text = "Cliente eliminado.";
                    LimpiarCampos();
                    LlenarGrid();
                }
                else
                {
                    lblMensaje.Text = "No existe un cliente con ese código.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }
    }
}