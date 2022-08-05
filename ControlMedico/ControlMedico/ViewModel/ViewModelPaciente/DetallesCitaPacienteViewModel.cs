using CommunityToolkit.Mvvm.Input;
using ControlMedico.Data.Model;
using ControlMedico.Data.Repository;
using ControlMedico.View.ViewMedico;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlMedico.ViewModel.ViewModelPaciente
{
    internal class DetallesCitaPacienteViewModel : BaseViewModel
    {
        #region Attributes
        private Cita citaSeleccionada;
        #endregion

        #region Properties

        public string Fecha
        {
            get { return citaSeleccionada.Fecha.ToString("dd/MM/yyyy"); }
        }

        public string Hora
        {
            get { return citaSeleccionada.Hora; }
        }

        public string NombreCompletoPaciente
        {
            get { return citaSeleccionada.NombreCompletoPaciente; }
        }

        public string Descripcion
        {
            get { return citaSeleccionada.Descripcion; }
        }
        #endregion

        #region Command
        public ICommand VerRegistroMedicoCommand
        {
            get { return new RelayCommand(VerRegistroMedico); }
            set { }
        }
        #endregion

        #region Methods
        public void VerRegistroMedico()
        {
            RegistroMedico registroTemp = RegistroMedicoRepository.RecuperarRegistroMedico(citaSeleccionada.IdCita);
            if (registroTemp.IdRegistroMedico > 0)
            {
                //Application.Current.MainPage.Navigation.PushAsync(new RegistroMedicoPaciente(this.citaSeleccionada));
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Registro Medico", "El Medico todavia no ha registrado los datos", "Aceptar");
            }
            
        }

        #endregion

        #region Constructor
        public DetallesCitaPacienteViewModel(Cita citaSeleccionada)
        {
            this.citaSeleccionada = citaSeleccionada;
        }
        #endregion
    }
}
