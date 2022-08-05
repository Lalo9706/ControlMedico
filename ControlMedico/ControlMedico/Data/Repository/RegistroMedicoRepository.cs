using ControlMedico.Data.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlMedico.Data.Repository
{
    internal class RegistroMedicoRepository
    {
        #region QUERYS

        private static string QUERY_SELECT_REGISTRO_MEDICO = "SELECT * FROM registromedico WHERE idCita = @idCita";

        private static string QUERY_INSERT_REGISTRO_MEDICO =
            "INSERT INTO registromedico(edad, peso, altura, presionSanguinea, nivelGlucosa, diagnostico, tratamiento, idCita)" +
            " VALUES (@edad, @peso, @altura, @presionSanguinea, @nivelGlucosa, @diagnostico, @tratamiento, @idCita)";

        private static string QUERY_UPDATE_REGISTRO_MEDICO = "UPDATE registromedico SET " +
            " edad = @edad, peso = @peso, altura = @altura, presionSanguinea = @presionSanguinea, nivelGlucosa = @nivelGlucosa," +
            " diagnostico = @diagnostico, tratamiento = @tratamiento WHERE idRegistroMedico = @idRegistroMedico";

        #endregion

        #region Methods

        public static RegistroMedico RecuperarRegistroMedico(int idCita)
        {
            RegistroMedico registro = null;
            MySqlConnection conexionBD = ConexionMySQL.ObtenerConexion();
            if(conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_SELECT_REGISTRO_MEDICO, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idCita", idCita);
                    MySqlDataReader resultado = mySqlCommand.ExecuteReader();
                    registro = new RegistroMedico();
                    if (resultado.Read())
                    {
                        registro.IdRegistroMedico = resultado.GetInt32(0);
                        registro.Edad = resultado.GetInt32(1);
                        registro.Peso = resultado.GetString(2);
                        registro.Altura = resultado.GetString(3);
                        registro.PresionSanguinea = resultado.GetString(4);
                        registro.NivelGlucosa = resultado.GetString(5);
                        registro.Diagnostico = resultado.GetString(6);
                        registro.Tratamiento = resultado.GetString(7);
                        registro.IdCita = resultado.GetInt32(8);
                    }

                }catch(MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conexionBD.Close();
                }
            }
            return registro;
        }

        public static int GuardarRegistroMedico(RegistroMedico registroTemp)
        {
            int respuesta = 0;
            MySqlConnection conexionBD = ConexionMySQL.ObtenerConexion();
            if(conexionBD != null)
            {  
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_INSERT_REGISTRO_MEDICO, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@edad", registroTemp.Edad);
                    mySqlCommand.Parameters.AddWithValue("@peso", registroTemp.Peso);
                    mySqlCommand.Parameters.AddWithValue("@altura", registroTemp.Altura);
                    mySqlCommand.Parameters.AddWithValue("@presionSanguinea", registroTemp.PresionSanguinea);
                    mySqlCommand.Parameters.AddWithValue("@nivelGlucosa", registroTemp.NivelGlucosa);
                    mySqlCommand.Parameters.AddWithValue("@diagnostico", registroTemp.Diagnostico);
                    mySqlCommand.Parameters.AddWithValue("@tratamiento", registroTemp.Tratamiento);
                    mySqlCommand.Parameters.AddWithValue("@idCita", registroTemp.IdCita);
                    mySqlCommand.Prepare();
                    respuesta = mySqlCommand.ExecuteNonQuery();

                }
                catch(MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conexionBD.Close();
                }
            }
            return respuesta;
        }

        public static int ActualizarRegistroMedico(RegistroMedico registroTemp)
        {
            int respuesta = 0;
            MySqlConnection conexionBD = ConexionMySQL.ObtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(QUERY_UPDATE_REGISTRO_MEDICO, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@edad", registroTemp.Edad);
                    mySqlCommand.Parameters.AddWithValue("@peso", registroTemp.Peso);
                    mySqlCommand.Parameters.AddWithValue("@altura", registroTemp.Altura);
                    mySqlCommand.Parameters.AddWithValue("@presionSanguinea", registroTemp.PresionSanguinea);
                    mySqlCommand.Parameters.AddWithValue("@nivelGlucosa", registroTemp.NivelGlucosa);
                    mySqlCommand.Parameters.AddWithValue("@diagnostico", registroTemp.Diagnostico);
                    mySqlCommand.Parameters.AddWithValue("@tratamiento", registroTemp.Tratamiento);
                    mySqlCommand.Parameters.AddWithValue("@idRegistroMedico", registroTemp.IdRegistroMedico);
                    mySqlCommand.Prepare();
                    respuesta = mySqlCommand.ExecuteNonQuery();

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conexionBD.Close();
                }
            }
            return respuesta;
        }
        #endregion

    }
}
