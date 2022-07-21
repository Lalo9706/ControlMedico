using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ControlMedico.ViewModel.ViewModelMedico
{
    internal class MonitorViewModel : BaseViewModel
    {

        #region Attriutes

        public string nombrePaciente;
        public List<string> pacientes = new List<string>();

        public string ppm; //60 - 100
        public string oxigen; //95 - 100
        public string temp; //36 - 37

        TimeSpan timer = TimeSpan.FromSeconds(2);

        


        #endregion

        #region Properties

        public string NombrePaciente
        {
            get { return this.nombrePaciente; }
            set { SetValue(ref this.nombrePaciente, value); }
        }

        public List<string> Pacientes
        {
            get { return new List<string> { }; }
        }

        public string PPM
        {
            get { return this.ppm; }
            set { SetValue(ref this.ppm, value); }
        }

        public string Oxigen
        {
            get { return this.oxigen; }
            set { SetValue(ref this.oxigen, value); }
        }

        public string Temp
        {
            get { return this.temp; }
            set { SetValue(ref this.temp, value); }
        }

        #endregion

        #region Command

        #endregion

        #region Methods

        private void SimularValores()
        {
            Device.StartTimer(timer, () =>
            {
                //Hace algo cada 2 segundos
                Device.BeginInvokeOnMainThread(() =>
                {
                    CambiarValores();

                });
                return true; // runs again, or false to stop
            });
        }

        private void CambiarValores()
        {
            this.PPM = "65";
            this.Oxigen = "94";
            this.Temp = "36";
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
