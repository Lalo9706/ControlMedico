using Acr.UserDialogs;
using CommunityToolkit.Mvvm.Input;
using ControlMedico.Data;
using ControlMedico.Data.Repository;
using ControlMedico.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlMedico.ViewModel.ViewModelPaciente
{
    internal class FormularioEditarUsuarioViewModel : BaseViewModel
    {
        #region Attributes
        private Usuario datosUsuario;
        private int idUsuario;
        public String nombre;
        public String apellidoPaterno;
        public String apellidoMaterno;
        public String fechaNacimiento;
        public String telefonoLocal;
        public String telefonoCelular;
        public String domicilio;
        public String correoElectronico;
        public String contraseña;

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

        public ICommand GuardarCambiosCommand
        {
            get { return new RelayCommand(GuardarCambios); }
            set { }
        }

        #endregion

        #region Methods

        private void InicializarDatos()
        {
            this.datosUsuario = UsuarioRepository.RecuperarUsuario(Settings.IdPaciente);
            idUsuario = datosUsuario.IdUsuario;
            nombre = datosUsuario.Nombre;
            apellidoPaterno = datosUsuario.ApellidoPaterno;
            apellidoMaterno = datosUsuario.ApellidoMaterno;
            fechaNacimiento = datosUsuario.FechaNacimiento.ToString("dd/MM/yyyy");
            telefonoLocal = datosUsuario.TelefonoLocal;
            telefonoCelular = datosUsuario.TelefonoCelular;
            domicilio = datosUsuario.Domicilio;
            correoElectronico = datosUsuario.CorreoElectronico;
            contraseña = datosUsuario.Contraseña;

        }

        private async void GuardarCambios()
        {
            Boolean validacion = false;
            if (this.TelefonoLocal == null || this.TelefonoLocal == "") { validacion = false; } else { validacion = true; }
            if (this.TelefonoCelular == null || this.TelefonoCelular == "") { validacion = false; } else { validacion = true; }
            if (this.Domicilio == null || this.Domicilio == "") { validacion = false; } else { validacion = true; }
            if(this.CorreoElectronico == null || this.CorreoElectronico == "") { validacion = false; } else { validacion = true; }


            if(validacion != false)
            {
                Usuario usuarioTemp = new Usuario();
                usuarioTemp.IdUsuario = this.idUsuario;
                usuarioTemp.TelefonoLocal = this.TelefonoLocal;
                usuarioTemp.TelefonoCelular = this.TelefonoCelular;
                usuarioTemp.Domicilio = this.Domicilio;
                usuarioTemp.CorreoElectronico = this.CorreoElectronico;

                UserDialogs.Instance.ShowLoading("Actualizando Perfil");
                await Task.Delay(500);
                int respuestaBD = UsuarioRepository.ActualizarUsuario(usuarioTemp);

                if (respuestaBD > 0)
                {
                    await Application.Current.MainPage.Navigation.PopAsync();
                    UserDialogs.Instance.HideLoading();
                    await Application.Current.MainPage.DisplayAlert("Modificar Perfil", "Se actualizó su perfil con exito", "Aceptar");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Modificar Perfil", "No se actualizó su perfil, intentelo mas tarde", "Aceptar");
                    UserDialogs.Instance.HideLoading();
                }

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Campos vacios", "Debe llenar todos los valores para guardar", "Aceptar");
            }
        }

        #endregion

        #region Constructor
        public FormularioEditarUsuarioViewModel()
        {
            InicializarDatos();
        }
        #endregion
    }
}
