using CommunityToolkit.Mvvm.Input;
using ControlMedico.Data;
using ControlMedico.Data.Repository;
using ControlMedico.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlMedico.ViewModel
{
    internal class PacientesViewModel : BaseViewModel
    {
        #region Attributes
        public object listViewSource = UsuarioRepository.RecuperarPacientesMedico(Settings.IdMedico);
        public string nombreCompleto;
        public int idMedico = Settings.IdMedico;
        public bool isRefreshing = false;
        #endregion


        #region Properties
        public object ListViewSource
        {
            get { return this.listViewSource; }
            set { SetValue(ref this.listViewSource, value); }
        }

        public string NombrePaciente
        {
            get { return this.nombreCompleto;}
            set { SetValue(ref this.nombreCompleto, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        #endregion

            #region Commands

        public ICommand ProgramarCitaCommand
        {
            get { return new RelayCommand(ProgramarCita); }
            set { }
        }

        #endregion


        #region Methods

        private void ProgramarCita()
        {
            
            this.IsRefreshing = true;
            Application.Current.MainPage.DisplayAlert("Aviso", "IDMedico" + idMedico, "Ok");
            //Application.Current.MainPage.DisplayAlert("Aviso", "Mostrando información del paciente", "Aceptar");
            this.IsRefreshing = false;
        }

        #endregion
    }
}
