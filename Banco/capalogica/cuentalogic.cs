using System.Data.SqlClient;

namespace Banco.CapaDatos.capalogica
{
    public class cuentalogic
    {
        public static int Agregarcuenta(int codigo, string tipo, int codigoCliente)
        {
            using (SqlConnection conn = DBconn.obtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO cuentacliente (codigo, tipo, codigoclientes) VALUES (@codigo, @tipo, @codigoclientes)", conn))
            {
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@codigoclientes", codigoCliente);
                return cmd.ExecuteNonQuery();
            }
        }

        public static int Modificarcuenta(int codigo, string tipo, int codigoCliente)
        {
            using (SqlConnection conn = DBconn.obtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE cuentacliente SET tipo = @tipo, codigoclientes = @codigoclientes WHERE codigo = @codigo", conn))
            {
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@codigoclientes", codigoCliente);
                return cmd.ExecuteNonQuery();
            }
        }

        public static int Eliminarcuenta(int codigo)
        {
            using (SqlConnection conn = DBconn.obtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM cuentacliente WHERE codigo = @codigo", conn))
            {
                cmd.Parameters.AddWithValue("@codigo", codigo);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}