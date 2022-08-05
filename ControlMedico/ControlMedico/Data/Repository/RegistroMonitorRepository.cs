using ControlMedico.Data.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlMedico.Data.Repository
{
    internal class RegistroMonitorRepository
    {
        #region QUERYS

        public static string QUERY_INSERT_REGISTRO_MONITOR =
            "INSERT INTO registromonitor (fechaHoraRegistro, ppm, oxigen, temp, estado, idPaciente) VALUES (@fechaHoraRegistro, @ppm, @oxigen, @temp, @estado, @idPaciente)";

        public static string QUERY_SELECT_REGISTRO_MONITOR =
            "SELECT * FROM registromonitor WHERE idPaciente = @idPaciente ORDER BY fechaHoraRegistro DESC";

        #endregion

        #region METHODS

        public static int GuardarRegistroMonitor(RegistroMonitor registroMonitor)
        {
            int respuesta = 0;
            MySqlConnection conexionBD = ConexionMySQL.ObtenerConexion();
            if(conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_INSERT_REGISTRO_MONITOR, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@fechaHoraRegistro", registroMonitor.FechaHoraRegistro);
                    mySqlCommand.Parameters.AddWithValue("@ppm", registroMonitor.PPM);
                    mySqlCommand.Parameters.AddWithValue("@oxigen", registroMonitor.Oxigen);
                    mySqlCommand.Parameters.AddWithValue("@temp", registroMonitor.Temp);
                    mySqlCommand.Parameters.AddWithValue("@estado", registroMonitor.Estado);
                    mySqlCommand.Parameters.AddWithValue("@idPaciente", registroMonitor.IdPaciente);
                    mySqlCommand.Prepare();
                    respuesta = mySqlCommand.ExecuteNonQuery();
                }
                catch(MySqlException ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    conexionBD.Close();
                }
            }
            return respuesta;
        }

        public static List<RegistroMonitor> RecuperarRegistroMonitorPorPaciente(int idPaciente)
        {
            List<RegistroMonitor> listaRegistroMonitor = null;
            MySqlConnection conexionBD = ConexionMySQL.ObtenerConexion();
            if(conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_SELECT_REGISTRO_MONITOR, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idPaciente", idPaciente);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    listaRegistroMonitor = new List<RegistroMonitor>();
                    if (respuestaBD.HasRows)
                    {
                        while (respuestaBD.Read())
                        {
                            RegistroMonitor rmTemp = new RegistroMonitor();
                            rmTemp.IdRegistroMonitor = respuestaBD.GetInt32(0);
                            rmTemp.FechaHoraRegistro = respuestaBD.GetDateTime(1);
                            rmTemp.PPM = respuestaBD.GetInt32(2);
                            rmTemp.Oxigen = respuestaBD.GetInt32(3);
                            rmTemp.Temp = respuestaBD.GetInt32(4);
                            rmTemp.Estado = respuestaBD.GetInt32(5);
                            rmTemp.IdPaciente = respuestaBD.GetInt32(6);

                            listaRegistroMonitor.Add(rmTemp);
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
            return listaRegistroMonitor;
        }

        #endregion


    }
}
