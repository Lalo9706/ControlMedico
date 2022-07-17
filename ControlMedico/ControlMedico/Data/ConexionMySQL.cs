//using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Xb.Db;
using MySqlConnector;

namespace ControlMedico.Data
{
    internal class ConexionMySQL
    {
        private static string SERVIDOR = "bp8bo7tz8uwho31aemzv-mysql.services.clever-cloud.com";
        private static string PUERTO = "3306";
        private static string BASE_DATOS = "bp8bo7tz8uwho31aemzv";
        private static string USUARIO_BD = "ut20b742tz3ud1r9";
        private static string PASSWORD = "MtKSz8DZAi2om0aRb4XS";

        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexionBD = null;
            try
            {
                string urlConexion = string.Format("server={0};" +
                                                   "database={1};" +
                                                   "username={2};" +
                                                   "password={3};" +
                                                   "port={4};", SERVIDOR, BASE_DATOS,
                                                   USUARIO_BD, PASSWORD, PUERTO);
                //String urlConexion = "Server=127.0.0.1;Database=controlmedico;Uid=lalo9706;Pwd=antony_9706;";
                conexionBD = new MySqlConnection(urlConexion);
                conexionBD.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("No se pudó conectar con mysql");
                conexionBD = null;
            }
            return conexionBD;
        }
    }
}
