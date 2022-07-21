using CommunityToolkit.Mvvm.Input;
using ControlMedico.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlMedico.ViewModel.ViewModelMedico
{
    internal class NuevaCitaViewModel : BaseViewModel
    {

        #region Attributes
        private Usuario paciente;
        //private string nombreCompletoPaciente;
        private DateTime fechaSeleccionada = DateTime.Today;
        #endregion

        #region Properties

        public string NombreCompletoPaciente
        {
            get { return this.paciente.NombreCompleto; }
        }

        public DateTime FechaSeleccionada
        {
            get { return this.fechaSeleccionada; }
            set { SetValue(ref this.fechaSeleccionada, value); }
        }

        #endregion


        #region Commands
        public ICommand GuardarCitaCommand
        {
            get { return new RelayCommand(GuardarCita); }
            set { }
        }
        #endregion

        private void GuardarCita()
        {
            Application.Current.MainPage.DisplayAlert("Aviso", "Probando fecha: " + FechaSeleccionada.ToString("dd/MM/yyyy"), "Aceptar");
        }


        public NuevaCitaViewModel(Usuario pacienteSeleccionado)
        {
            this.paciente = pacienteSeleccionado;
        }
    }
}
