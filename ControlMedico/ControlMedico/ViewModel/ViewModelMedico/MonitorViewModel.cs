﻿using CommunityToolkit.Mvvm.Input;
using ControlMedico.Data.Model;
using ControlMedico.Data.Repository;
using ControlMedico.View.ViewMedico;
using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlMedico.ViewModel.ViewModelMedico
{
    internal class MonitorViewModel : BaseViewModel
    {
        #region Constants
        private int VALOR_MIN_PPM = 60;
        private int VALOR_MAX_PPM = 100;
        private int VALOR_MIN_OXIGEN = 95;
        private int VALOR_MAX_OXIGEN = 100;
        private int VALOR_MIN_TEMP = 35;
        private int VALOR_MAX_TEMP = 37;

        #endregion

        #region Attributes

        //Ajustes
        public Boolean notificar = true; // Switch para desactivar notificaciones del monitor
        public Boolean notificando = false; // Estado de la notificación
        TimeSpan timer = TimeSpan.FromSeconds(2);
        Random random = new Random();
        int pacienteIndex;
        int IdPacienteMonitoreado;

        //Valores
        public string nombrePaciente;
        public List<string> pacientes = new List<string>();
        //-----------------------Min - Max
        public int ppm = 0;    //60 - 100
        public int oxigen = 0; //95 - 100
        public int temp = 0;   //36 - 37

        #endregion

        #region Properties

        public Boolean Notificar
        {
            get { return this.notificar; }
            set { SetValue(ref this.notificar, value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(CambiarNotificaciones));
            }
        }

        private Boolean CambiarNotificaciones()
        {
            return Notificar ? true : false;
        }

        public string NombrePaciente
        {
            get { return this.nombrePaciente; }
            set { SetValue(ref this.nombrePaciente, value); }
        }

        public List<string> Pacientes
        {
            get { return new List<string> { }; }
        }

        public int PPM
        {
            get { return this.ppm; }
            set { SetValue(ref this.ppm, value); }
        }

        public int Oxigen
        {
            get { return this.oxigen; }
            set { SetValue(ref this.oxigen, value); }
        }

        public int Temp
        {
            get { return this.temp; }
            set { SetValue(ref this.temp, value); }
        }

        public int PacienteIndex
        {
            get { return this.pacienteIndex; }
            set { SetValue(ref this.pacienteIndex, value); }
        }

        #endregion

        #region Command

        public ICommand VerHistorialCommand
        {
            get { return new RelayCommand(VerHistorial); }
            set { }
        }


        #endregion

        #region Methods

        private void SimularValores()
        {
            Device.StartTimer(timer, () =>
            {
                //Cada 2 segundos
                Device.BeginInvokeOnMainThread(() =>
                {               
                    CambiarValores(PacienteIndex);
                    VerificarValoresAltos();
                });
                return true;
            });
        }

        private void VerificarValoresAltos()
        {
            var notificarPulsoAlto = new NotificationRequest
            {
                BadgeNumber = 2,
                Title = "PACIENTE CON RITMO CARDIACO ALTO",
                Description = "EL PACIENTE SUPERA LAS 100 PPM",
                NotificationId = 1338,
                CategoryType = NotificationCategoryType.Alarm,
            };

            var notificarPulsoBajo = new NotificationRequest
            {
                BadgeNumber = 2,
                Title = "PACIENTE CON RITMO CARDIACO BAJO",
                Description = "PPM MENOR A 60",
                NotificationId = 1338,
                CategoryType = NotificationCategoryType.Alarm,
            };

            var notificarOxigenacionBaja = new NotificationRequest
            {
                BadgeNumber = 2,
                Title = "PACIENTE CON OXIGENACIÓN BAJA",
                Description = "LA OXIGENACIÓN ES MENOR A 95 SpO2",
                NotificationId = 1338,
                CategoryType = NotificationCategoryType.Alarm
            };

            var notificarTemperaturaAlta = new NotificationRequest
            {
                BadgeNumber = 1,
                Title = "PACIENTE CON TEMPERATURA ALTA",
                Description = "EL PACIENTE SUPERA LOS 38°C",
                NotificationId = 1337,
                CategoryType = NotificationCategoryType.Alarm
            };

            if (Notificar == true)
            {
                if (this.PPM > VALOR_MAX_PPM && notificando == false)
                {
                    RegistrarValores();
                    NotificationCenter.Current.Show(notificarPulsoAlto);
                    Notificando(); 
                }

                if (this.PPM < VALOR_MIN_PPM && notificando == false) {
                    RegistrarValores();
                    NotificationCenter.Current.Show(notificarPulsoBajo);
                    Notificando();
                }

                if (this.Oxigen < VALOR_MIN_OXIGEN && notificando == false) 
                {
                    RegistrarValores();
                    NotificationCenter.Current.Show(notificarOxigenacionBaja);
                    Notificando();
                }

                if (this.Temp > VALOR_MAX_TEMP && notificando == false)
                {
                    RegistrarValores();
                    NotificationCenter.Current.Show(notificarTemperaturaAlta);
                    Notificando(); 
                }     
            }
        }

        private void RegistrarValores()
        {
            RegistroMonitor registroTemp = new RegistroMonitor();
            registroTemp.FechaHoraRegistro = DateTime.Now;
            registroTemp.PPM = this.PPM;
            registroTemp.Oxigen = this.Oxigen;
            registroTemp.Temp = this.Temp;
            registroTemp.IdPaciente = this.IdPacienteMonitoreado;

            int respuestaBD = RegistroMonitorRepository.GuardarRegistroMonitor(registroTemp);
            if (respuestaBD == 0)
            {
                Application.Current.MainPage.DisplayAlert("Error de Conexión", "Se ha perdidó la conexión con el servidor", "Aceptar");
            }
        }

        // Poniendo estado de la notificación en True con un retraso de 2 segundos para luego ponerlo en False
        private async void Notificando()
        {
            this.notificando = true;
            await Task.Delay(3000);
            this.notificando = false;
        }

        private void CambiarValores(int paciente)
        {
            if(paciente == 0) //Paciente con valores normales
            {
                this.NombrePaciente = "Sebastian López Gómez";
                this.IdPacienteMonitoreado = 7; //id en la base de datos
                this.PPM = random.Next(60, 65);
                this.Oxigen = random.Next(95, 97);
                this.Temp = random.Next(36, 37);
            }
            if(paciente == 1) //Paciente con temperatura alta
            {
                this.NombrePaciente = "Luis Alfonso Torres Castillo";
                this.IdPacienteMonitoreado = 8;
                this.PPM = random.Next(70, 73);
                this.Oxigen = random.Next(96, 100);
                this.Temp = random.Next(36, 39);
            }
            if(paciente == 2) //Paciente con pulso Alto
            {
                this.NombrePaciente = "Javier Padrón Rodríguez";
                this.IdPacienteMonitoreado = 9;
                this.PPM = random.Next(98, 103);
                this.Oxigen = random.Next(96, 100);
                this.Temp = random.Next(36, 36);
            }
            if (paciente == 3) //Paciente con oxigenación baja
            {
                this.NombrePaciente = "Natalia Portillo Romero";
                this.IdPacienteMonitoreado = 10;
                this.PPM = random.Next(80, 83);
                this.Oxigen = random.Next(92, 96);
                this.Temp = random.Next(36, 36);
            }
        }

        private void VerHistorial()
        {
            Application.Current.MainPage.Navigation.PushAsync(new RegistrosMonitor(NombrePaciente, IdPacienteMonitoreado));
        }

        #endregion

        #region Constructor

        public MonitorViewModel()
        {
            SimularValores();
        }

        #endregion
    }
}
