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
        public object listViewSource = CitaRepository.RecuperarCitasMedico(Settings.IdMedico, DateTime.Today);
        #endregion


        #region Properties
        public object ListViewSource
        {
            get { return this.listViewSource; }
            set { SetValue(ref this.listViewSource, value); }
        }

        #endregion

        #region Commands

        public ICommand VerPacienteCommand
        {
            get { return new RelayCommand(VerPaciente); }
            set { }
        }

        #endregion


        #region Methods

        private void VerPaciente()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
