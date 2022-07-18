using CommunityToolkit.Mvvm.Input;
using ControlMedico.Data.Model;
using ControlMedico.Data.Repository;
using ControlMedico.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

using Xamarin.Plugin.Calendar.Models;

namespace ControlMedico.ViewModel
{
    internal class PrincipalMedicoViewModel : BaseViewModel
    {

        #region AttributesPrincipal
        public CultureInfo CultureInfo => new CultureInfo("es-ES");
        private DateTime fechaSeleccionada = DateTime.Today;
        public Usuario usuario;
        public List<Cita> Citas = new List<Cita>();
        #endregion

        #region AttributesCitaListView
        public DateTime hora;
        public string descripcion;
        public bool isRefreshing = false;
        public Object listViewSource;
        #endregion

        #region Properties
        public DateTime FechaSeleccionada
        {
            get { return this.fechaSeleccionada; }
            set { SetValue(ref this.fechaSeleccionada, value); }
        }

        public DateTime Hora
        {
            get { return this.hora; }
            set { SetValue(ref this.hora, value); }
        }

        public string Descripcion
        {
            get { return this.descripcion; }
            set { SetValue(ref this.descripcion, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public Object ListViewSource
        {
            get { return this.listViewSource; }
            set { SetValue(ref this.listViewSource, value); }
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

        public async Task CargarCitas()
        {
            this.ListViewSource = await CitaRepository.RecuperarCitasMedico(usuario.IdUsuario);
        }
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
