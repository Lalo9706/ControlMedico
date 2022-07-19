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
        public Usuario paciente = UsuarioRepository.RecuperarUsuario(Settings.IdMedico);

        public ICommand PruebaUsuario
        {
            get { return new RelayCommand(ProbarUsuario); }
            set { }
        }

        private void ProbarUsuario()
        {
            Application.Current.MainPage.DisplayAlert("Paciente:", paciente.Nombre, "Aceptar");

        }

    }
}
