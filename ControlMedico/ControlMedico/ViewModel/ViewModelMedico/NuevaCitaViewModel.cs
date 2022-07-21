using CommunityToolkit.Mvvm.Input;
using ControlMedico.Data;
using ControlMedico.Data.Model;
using ControlMedico.Data.Repository;
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
        private DateTime fechaSeleccionada = DateTime.Today;
        private TimeSpan horaSeleccionada;
        private string descripcionTxt = "";
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

        public TimeSpan HoraSeleccionada
        {
            get { return this.horaSeleccionada; }
            set { SetValue(ref this.horaSeleccionada, value); }
        }

        public string DescripcionTxt
        {
            get { return this.descripcionTxt; }
            set { SetValue(ref this.descripcionTxt, value); }
        }

        #endregion

        #region Commands
        public ICommand GuardarCitaCommand
        {
            get { return new RelayCommand(GuardarCita); }
            set { }
        }
        #endregion

        #region Methods
        private void GuardarCita()
        {
            if(DescripcionTxt != "")
            {
                Cita nuevaCita = new Cita();
                nuevaCita.Descripcion = DescripcionTxt;
                nuevaCita.Fecha = FechaSeleccionada;
                nuevaCita.Hora = HoraSeleccionada.ToString(@"hh\:mm");
                nuevaCita.IdMedico = Settings.IdMedico;
                nuevaCita.IdPaciente = paciente.IdUsuario;
                int respuesta = CitaRepository.GuardarCita(nuevaCita);
                if(respuesta != 0)
                {
                    Application.Current.MainPage.DisplayAlert("Nueva Cita", "La cita se guardó con exito", "Aceptar");
                    Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Nueva Cita", "No se guardó la cita, intentelo mas tarde", "Aceptar");
                }
            }
        }

        #endregion

        #region Constructor
        public NuevaCitaViewModel(Usuario pacienteSeleccionado)
        {
            this.paciente = pacienteSeleccionado;
        }
        #endregion
    }
}
