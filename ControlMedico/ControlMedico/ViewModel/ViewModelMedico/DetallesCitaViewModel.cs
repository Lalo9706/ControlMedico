using CommunityToolkit.Mvvm.Input;
using ControlMedico.Data.Model;
using ControlMedico.View.ViewMedico;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlMedico.ViewModel.ViewModelMedico
{
    internal class DetallesCitaViewModel : BaseViewModel
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
            get { return citaSeleccionada.NombreCompletoPaciente;}
        }

        public string Descripcion
        {
            get { return citaSeleccionada.Descripcion; }
        }

        

        #endregion

        #region Command
        public ICommand RegistrarDMCommand
        {
            get { return new RelayCommand(RegistrarDatosMedicos); }
            set { }
        }
        #endregion

        #region Methods
        public void RegistrarDatosMedicos()
        {
            Application.Current.MainPage.Navigation.PushAsync(new FormularioRegistroMedico(this.citaSeleccionada));
        }

        #endregion

        #region Constructor
        public DetallesCitaViewModel(Cita citaSeleccionada)
        {
            this.citaSeleccionada = citaSeleccionada;
        }
        #endregion
    }
}
