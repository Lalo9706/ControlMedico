using CommunityToolkit.Mvvm.Input;
using ControlMedico.Data.Model;
using ControlMedico.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

using Xamarin.Plugin.Calendar.Models;

namespace ControlMedico.ViewModel
{
    internal class PrincipalMedicoViewModel : BaseViewModel
    {

        #region Attributes
        public CultureInfo CultureInfo => new CultureInfo("es-ES");
        private DateTime fechaSeleccionada = DateTime.Today;
        public Usuario usuario;
        #endregion

        #region Properties
        public DateTime FechaSeleccionada
        {
            get { return this.fechaSeleccionada; }
            set { SetValue(ref this.fechaSeleccionada, value); }
        }
        #endregion

        #region Commands
        public ICommand PruebaFechaCommand
        {
            get { return new RelayCommand(ProbarFecha); }
            set { }
        }
        #endregion

        #region Methods
        private void ProbarFecha()
        {
            //Application.Current.MainPage.DisplayAlert("Fecha:",fechaSeleccionada.ToString("yyyy-MM-dd"),"Aceptar");
            Application.Current.MainPage.DisplayAlert("Usuario:",usuario.Nombre + fechaSeleccionada.ToString("yyyy-MM-dd"),"Aceptar");
        }
        #endregion

        #region Constructor
        public PrincipalMedicoViewModel(Usuario usuario)
        {
            this.usuario = usuario;
        }
        #endregion
    }
}
