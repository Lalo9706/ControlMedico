using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlMedico.ViewModel.ViewModelMedico
{
    internal class MonitorViewModel : BaseViewModel
    {

        #region Attriutes

        public string nombrePaciente;
        public List<string> pacientes = new List<string>();

        public int ppm = 0; //60 - 100
        public int oxigen = 0; //95 - 100
        public int temp = 0; //36 - 37

        TimeSpan timer = TimeSpan.FromSeconds(2);
        Random random = new Random();
        public int pacienteIndex;
        


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

        public ICommand ProbarCommand
        {
            get { return new RelayCommand(Probar); }
            set { }
        }

        private void Probar()
        {
            Application.Current.MainPage.DisplayAlert("Alerta", "Index = " + PacienteIndex, "Acepta");
        }

        #endregion

        #region Methods

        private void SimularValores()
        {
            int i = 0;
            Device.StartTimer(timer, () =>
            {
                //Hace algo cada 2 segundos
                Device.BeginInvokeOnMainThread(() =>
                {               
                    CambiarValores(PacienteIndex);

                });
                return true; // runs again, or false to stop
            });
        }

        private void CambiarValores(int paciente)
        {
            if(paciente == 0)
            {
                this.PPM = random.Next(60, 65);
                this.Oxigen = random.Next(95, 97);
                this.Temp = random.Next(36, 37);
            }
            if(paciente == 1)
            {
                this.PPM = random.Next(70, 73);
                this.Oxigen = random.Next(96, 100);
                this.Temp = random.Next(36, 37);
            }
            if(paciente == 2)
            {
                this.PPM = random.Next(76, 80);
                this.Oxigen = random.Next(94, 95);
                this.Temp = random.Next(37, 39);
            }
            
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
