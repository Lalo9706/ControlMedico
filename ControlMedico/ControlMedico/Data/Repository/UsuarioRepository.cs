using ControlMedico.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlMedico.Data.Repository
{
    internal class UsuarioRepository
    {
        private static String QUERY_INICIAR_SESION =
            "SELECT idUsuario, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, telefonoLocal, telefonoCelular, " +
            "domicilio, tipoUsuario FROM usuario WHERE correoElectronico = @correo AND contrasena = @contrasena";

        internal static Usuario IniciarSesion(string correo, string contraseña)
        {
            Usuario usuario = null;
            MySqlConnection conexionBD = ConexionMySQL.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_INICIAR_SESION, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@correo", correo);
                    mySqlCommand.Parameters.AddWithValue("@contrasena", contraseña);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    usuario = new Usuario();
                    if (respuestaBD.Read())
                    {                      
                        usuario.IdUsuario = respuestaBD.GetInt32(0);
                        usuario.Nombre = respuestaBD.GetString(1);
                        usuario.ApellidoPaterno = respuestaBD.GetString(2);
                        usuario.ApellidoMaterno = respuestaBD.GetString(3);
                        usuario.FechaNacimiento = respuestaBD.GetDateTime(4);
                        usuario.TelefonoLocal = respuestaBD.GetString(5);
                        usuario.TelefonoCelular = respuestaBD.GetString(6);
                        usuario.Domicilio = respuestaBD.GetString(7);
                        usuario.TipoUsuario = respuestaBD.GetInt32(8);
                        usuario.CorreoElectronico = correo;
                        usuario.Contraseña = contraseña;
                    }
                    else if(respuestaBD == null)
                    {
                        usuario.IdUsuario = 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    conexionBD.Close();
                }
            }
            return usuario;
        }
    }
}
