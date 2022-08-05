using ControlMedico.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ControlMedico.ViewModel.ViewModelMedico
{
    internal class RegistrosMonitorViewModel : BaseViewModel
    {
        #region Attributes
        private string nombrePaciente;
        private int idPacienteMonitoreado;
        TimeSpan timer = TimeSpan.FromSeconds(5);

        //Datos de la lista
        public object listViewSource;
        public DateTime fechaHoraRegistro;
        public int ppm = 0;
        public int oxigen = 0;
        public int temp = 0;


        public bool isRefreshing = false;
        #endregion

        #region Properties

        public string NombrePaciente
        {
            get { return this.nombrePaciente; }
            set { SetValue(ref this.nombrePaciente, value); }
        }

        public int IdPacienteMonitoreado
        {
            get { return this.idPacienteMonitoreado; }
            set { SetValue(ref this.idPacienteMonitoreado, value); }
        }

        //Datos de la Lista
        public object ListViewSource
        {
            get { return this.listViewSource; }
            set { SetValue(ref this.listViewSource, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public DateTime FechaHoraRegistro
        {
            get { return this.fechaHoraRegistro; }
            set { SetValue(ref this.fechaHoraRegistro, value); }
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

        #endregion


        #region Methods

        private void ActualizarRegistros()
        {
            Device.StartTimer(timer, () =>
            {
                //Cada 2 segundos
                Device.BeginInvokeOnMainThread(() =>
                {
                    RecuperarDatos();
                });
                return true;
            });
        }

        private void RecuperarDatos()
        {
            this.IsRefreshing = true;
            this.ListViewSource = RegistroMonitorRepository.RecuperarRegistroMonitorPorPaciente(this.idPacienteMonitoreado);
            this.IsRefreshing = false;

        }

        #endregion

        public RegistrosMonitorViewModel(string nombrePaciente, int idPacienteMonitoreado)
        {
            this.nombrePaciente = nombrePaciente;
            this.idPacienteMonitoreado = idPacienteMonitoreado;
            this.listViewSource = RegistroMonitorRepository.RecuperarRegistroMonitorPorPaciente(this.idPacienteMonitoreado);
            ActualizarRegistros();
        }

        
    }
}
