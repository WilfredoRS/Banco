using Banco.CapaDatos.Banco.CapaDatos;
using Banco.CapaDatos.capalogica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Banco.capalogica
{
    public class usuarioequipologic
    {

    }

namespace Banco.CapaDatos.capalogica
    {
        public class usuariologic
        {
            public static int Agregar(cls_usuario u)
            {
                using (SqlConnection conn = DBconn.obtenerConexion())
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Usuarios (UsuarioID, Nombre, CorreoElectronico, Telefono) " +
                    "VALUES (@id, @nombre, @correo, @telefono)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", u.UsuarioID);
                    cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                    cmd.Parameters.AddWithValue("@correo", u.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@telefono",
                        string.IsNullOrWhiteSpace(u.Telefono) ? (object)DBNull.Value : u.Telefono);
                    return cmd.ExecuteNonQuery();
                }
            }

            public static int Modificar(cls_usuario u)
            {
                using (SqlConnection conn = DBconn.obtenerConexion())
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE Usuarios SET Nombre = @nombre, CorreoElectronico = @correo, Telefono = @telefono " +
                    "WHERE UsuarioID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", u.UsuarioID);
                    cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                    cmd.Parameters.AddWithValue("@correo", u.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@telefono",
                        string.IsNullOrWhiteSpace(u.Telefono) ? (object)DBNull.Value : u.Telefono);
                    return cmd.ExecuteNonQuery();
                }
            }

            public static int Eliminar(int id)
            {
                using (SqlConnection conn = DBconn.obtenerConexion())
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Usuarios WHERE UsuarioID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public class equipologic
        {
            public static int Agregar(cls_equipo eq)
            {
                using (SqlConnection conn = DBconn.obtenerConexion())
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Equipos (EquipoID, TipoEquipo, Modelo, UsuarioID) " +
                    "VALUES (@id, @tipo, @modelo, @usuario)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", eq.EquipoID);
                    cmd.Parameters.AddWithValue("@tipo", eq.TipoEquipo);
                    cmd.Parameters.AddWithValue("@modelo", eq.Modelo);
                    cmd.Parameters.AddWithValue("@usuario", eq.UsuarioID);
                    return cmd.ExecuteNonQuery();
                }
            }

            public static int Modificar(cls_equipo eq)
            {
                using (SqlConnection conn = DBconn.obtenerConexion())
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE Equipos SET TipoEquipo = @tipo, Modelo = @modelo, UsuarioID = @usuario " +
                    "WHERE EquipoID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", eq.EquipoID);
                    cmd.Parameters.AddWithValue("@tipo", eq.TipoEquipo);
                    cmd.Parameters.AddWithValue("@modelo", eq.Modelo);
                    cmd.Parameters.AddWithValue("@usuario", eq.UsuarioID);
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

}
