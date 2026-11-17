using System.Data.SqlClient;

namespace Banco.CapaDatos.capalogica
{
    public class equipoclientelogic
    {
        public static int Agregar(cls_equipo_cliente e)
        {
            using (SqlConnection conn = DBconn.obtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Equipos (EquipoID, TipoEquipo, Modelo, codigocliente) " +
                "VALUES (@id, @tipo, @modelo, @cliente)", conn))
            {
                cmd.Parameters.AddWithValue("@id", e.EquipoID);
                cmd.Parameters.AddWithValue("@tipo", e.TipoEquipo);
                cmd.Parameters.AddWithValue("@modelo", e.Modelo);
                cmd.Parameters.AddWithValue("@cliente", e.CodigoCliente);
                return cmd.ExecuteNonQuery();
            }
        }

        public static int Modificar(cls_equipo_cliente e)
        {
            using (SqlConnection conn = DBconn.obtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Equipos SET TipoEquipo = @tipo, Modelo = @modelo, codigocliente = @cliente " +
                "WHERE EquipoID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", e.EquipoID);
                cmd.Parameters.AddWithValue("@tipo", e.TipoEquipo);
                cmd.Parameters.AddWithValue("@modelo", e.Modelo);
                cmd.Parameters.AddWithValue("@cliente", e.CodigoCliente);
                return cmd.ExecuteNonQuery();
            }
        }

        public static int Eliminar(int id)
        {
            using (SqlConnection conn = DBconn.obtenerConexion())
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Equipos WHERE EquipoID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}