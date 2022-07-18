using CommunityToolkit.Mvvm.Input;
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
        Usuario paciente; 

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
