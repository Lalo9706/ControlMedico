using CommunityToolkit.Mvvm.Input;
using ControlMedico.Data;
using ControlMedico.Data.Repository;
using ControlMedico.Model;
using ControlMedico.View.ViewPaciente;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlMedico.ViewModel.ViewModelPaciente
{
    internal class PerfilPacienteViewModel : BaseViewModel
    {
        #region Attributes
        private Usuario datosPaciente;
        private int idUsuario;
        public String nombre;
        public String apellidoPaterno;
        public String apellidoMaterno;
        public String fechaNacimiento;
        public String telefonoLocal;
        public String telefonoCelular;
        public String domicilio;
        public String correoElectronico;

        #endregion

        #region Properties

        public String Nombre
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }

        public String ApellidoPaterno
        {
            get { return this.apellidoPaterno; }
            set { SetValue(ref this.apellidoPaterno, value); }
        }

        public String ApellidoMaterno
        {
            get { return this.apellidoMaterno; }
            set { SetValue(ref this.apellidoMaterno, value); }
        }

        public String FechaNacimiento
        {
            get { return this.fechaNacimiento; }
            set { SetValue(ref this.fechaNacimiento, value); }
        }

        public String TelefonoLocal
        {
            get { return this.telefonoLocal; }
            set { SetValue(ref this.telefonoLocal, value); }
        }

        public String TelefonoCelular
        {
            get { return this.telefonoCelular; }
            set { SetValue(ref this.telefonoCelular, value); }
        }

        public String Domicilio
        {
            get { return this.domicilio; }
            set { SetValue(ref this.domicilio, value); }
        }

        public String CorreoElectronico
        {
            get { return this.correoElectronico; }
            set { SetValue(ref this.correoElectronico, value); }
        }


        #endregion

        #region Commands

        public ICommand ModificarPerfilCommand
        {
            get { return new RelayCommand(ModificarPerfil); }
            set { }
        }

        #endregion

        #region Methods

        private void InicializarDatos()
        {
            this.datosPaciente = UsuarioRepository.RecuperarUsuario(Settings.IdPaciente);
            idUsuario = datosPaciente.IdUsuario;
            nombre = datosPaciente.Nombre;
            apellidoPaterno = datosPaciente.ApellidoPaterno;
            apellidoMaterno = datosPaciente.ApellidoMaterno;
            fechaNacimiento = datosPaciente.FechaNacimiento.ToString("dd/MM/yyyy");
            telefonoLocal = datosPaciente.TelefonoLocal;
            telefonoCelular = datosPaciente.TelefonoCelular;
            domicilio = datosPaciente.Domicilio;
            correoElectronico = datosPaciente.CorreoElectronico;

        }

        private async void ModificarPerfil()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new FormularioEditarUsuario());
        }

        public PerfilPacienteViewModel()
        {
            InicializarDatos();
        }

        #endregion
    }
}
