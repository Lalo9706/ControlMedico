using ControlMedico.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlMedico.Data.Repository
{
    internal class UsuarioRepository
    {

        #region SQL_QUERY
        private static string QUERY_INICIAR_SESION =
            "SELECT idUsuario, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, telefonoLocal, telefonoCelular, " +
            "domicilio, tipoUsuario FROM usuario WHERE correoElectronico = @correo AND contrasena = @contrasena";

        public static string QUERY_RECUPERAR_USUARIO =
            "SELECT nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, telefonoLocal, telefonoCelular, " +
            "domicilio, tipoUsuario, correoElectronico, contrasena FROM usuario WHERE idUsuario = @idUsuario";

        public static string QUERY_RECUPERAR_PACIENTES =
            "SELECT idPaciente, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, telefonoLocal, telefonoCelular, " +
            "domicilio, tipoUsuario, correoElectronico FROM usuario INNER JOIN medicopaciente ON usuario.idUsuario = medicopaciente.idPaciente WHERE medicopaciente.idMedico = @idMedico";

        #endregion


        #region METHODS
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
                catch (MySqlException ex)
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

        internal static Usuario RecuperarUsuario(int idUsuario)
        {
            Usuario usuario = null;
            MySqlConnection conexionBD = ConexionMySQL.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_RECUPERAR_USUARIO, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    usuario = new Usuario();
                    if (respuestaBD.Read())
                    {
                        usuario.IdUsuario = idUsuario;
                        usuario.Nombre = respuestaBD.GetString(0);
                        usuario.ApellidoPaterno = respuestaBD.GetString(1);
                        usuario.ApellidoMaterno = respuestaBD.GetString(2);
                        usuario.FechaNacimiento = respuestaBD.GetDateTime(3);
                        usuario.TelefonoLocal = respuestaBD.GetString(4);
                        usuario.TelefonoCelular = respuestaBD.GetString(5);
                        usuario.Domicilio = respuestaBD.GetString(6);
                        usuario.TipoUsuario = respuestaBD.GetInt32(7);
                        usuario.CorreoElectronico = respuestaBD.GetString(8);
                        usuario.Contraseña = respuestaBD.GetString(9);
                    }
                    else if (respuestaBD == null)
                    {
                        usuario.IdUsuario = 0;
                    }
                }
                catch (MySqlException ex)
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

        public static List<Usuario> RecuperarPacientesMedico(int idMedico)
        {
            List<Usuario> pacientes = null;
            MySqlConnection conexionBD = ConexionMySQL.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_RECUPERAR_PACIENTES, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idMedico", idMedico);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    pacientes = new List<Usuario>();
                    if (respuestaBD.HasRows)
                    {
                        while (respuestaBD.Read())
                        {
                            Usuario paciente = new Usuario();
                            paciente.IdUsuario = respuestaBD.GetInt16(0);
                            paciente.Nombre = respuestaBD.GetString(1);
                            paciente.ApellidoPaterno = respuestaBD.GetString(2);
                            paciente.ApellidoMaterno = respuestaBD.GetString(3);
                            paciente.FechaNacimiento = respuestaBD.GetDateTime(4);
                            paciente.TelefonoLocal = respuestaBD.GetString(5);
                            paciente.TelefonoCelular = respuestaBD.GetString(6);
                            paciente.Domicilio = respuestaBD.GetString(7);
                            paciente.TipoUsuario = respuestaBD.GetInt32(8);
                            paciente.CorreoElectronico = respuestaBD.GetString(9);
                            pacientes.Add(paciente);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    conexionBD.Close();
                }
            }
            return pacientes;
        }

        #endregion
    }
}
