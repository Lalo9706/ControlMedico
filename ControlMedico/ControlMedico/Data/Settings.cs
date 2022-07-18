using System;
using System.Collections.Generic;
using System.Text;
using ControlMedico.Model;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ControlMedico.Data
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        //IdUsuario Medico
        private const String SettingsKeyIdMedico = "IdMedico";
        private static readonly int SettingsDefaultIdMedico = 0;

        //IdUsuario Paciente
        private const String SettingsKeyIdPaciente = "IdPaciente";
        private static readonly int SettingsDefaultIdPaciente = 0;

        #endregion

        //IdUsuarioMedico
        public static int IdMedico
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKeyIdMedico, SettingsDefaultIdMedico);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKeyIdMedico, value);
            }
        }

        //IdUsuarioPaciente
        public static int IdPaciente
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKeyIdPaciente, SettingsDefaultIdPaciente);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKeyIdPaciente, value);
            }
        }


    }
}
