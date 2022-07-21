﻿using ControlMedico.Data.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedico.Data.Repository
{
    internal class CitaRepository
    {
        #region QUERYS
        private static string QUERY_RECUPERAR_CITAS_MEDICO =
            "SELECT idCita, fecha, hora, descripcionCita, idMedico, idPaciente FROM cita WHERE idMedico = @idMedico AND fecha = @hoy ORDER BY hora";
        /*private static string QUERY_RECUPERAR_CITAS_PACIENTE =
            "SELECT idCita, fecha, hora, descripcionCita, idMedico, idPaciente FROM cita WHERE idPaciente = @idPaciente";*/

        private static string QUERY_INSERTAR_NUEVA_CITA = 
            "INSERT INTO cita (fecha, hora, descripcionCita, idMedico, idPaciente) VALUES (@fecha, @hora, @descripcionCita, @idMedico, @idPaciente)";

        #endregion


        #region Methods
        public static List<Cita> RecuperarCitasMedico(int idMedico, DateTime hoy)
        {
            List<Cita> citas = null;
            MySqlConnection conexionBD = ConexionMySQL.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_RECUPERAR_CITAS_MEDICO, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idMedico", idMedico);
                    mySqlCommand.Parameters.AddWithValue("@hoy", hoy.ToString("yyyy/MM/dd"));
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    citas = new List<Cita>();
                    if (respuestaBD.HasRows)
                    {
                        while (respuestaBD.Read())
                        {
                            Cita citaTemp = new Cita();
                            citaTemp.IdCita = respuestaBD.GetInt16(0);
                            citaTemp.Fecha = respuestaBD.GetDateTime(1);
                            citaTemp.Hora = respuestaBD.GetString(2);
                            citaTemp.Descripcion = respuestaBD.GetString(3);
                            citaTemp.IdMedico = respuestaBD.GetInt16(4);
                            citaTemp.IdPaciente = respuestaBD.GetInt16(5);

                            citas.Add(citaTemp);
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
            return citas;
        }

        internal static int GuardarCita(Cita nuevaCita)
        {
            int respuesta = 0;

            MySqlConnection conexionBD = ConexionMySQL.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_INSERTAR_NUEVA_CITA, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@fecha", nuevaCita.Fecha);
                    mySqlCommand.Parameters.AddWithValue("@hora", nuevaCita.Hora);
                    mySqlCommand.Parameters.AddWithValue("@descripcionCita", nuevaCita.Descripcion);
                    mySqlCommand.Parameters.AddWithValue("@idMedico", nuevaCita.IdMedico);
                    mySqlCommand.Parameters.AddWithValue("@idPaciente", nuevaCita.IdPaciente);
                    mySqlCommand.Prepare();
                    respuesta = mySqlCommand.ExecuteNonQuery();
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
            return respuesta;
        }

        internal static Task<List<Cita>> RecuperarCitasPaciente(int idPaciente)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
