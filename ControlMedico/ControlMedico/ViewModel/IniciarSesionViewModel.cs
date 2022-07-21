using CommunityToolkit.Mvvm.Input;
using ControlMedico.Model;
using ControlMedico.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ControlMedico.View;
using System.Threading.Tasks;
using ControlMedico.View.ViewMedico;
using ControlMedico.Data;
using Acr.UserDialogs;

namespace ControlMedico.ViewModel
{
    public class IniciarSesionViewModel  : BaseViewModel
    {
        #region Attributes
        private string email = "";
        private string password = "";
        private Usuario usuario;
        private int MEDICO = 1;
        private int PACIENTE = 2;
        #endregion

        #region Properties
        public string EmailTxt
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string PasswordTxt
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {           
            get { return new RelayCommand(IniciarSesion); }
            set { }
        }

        public ICommand NewAccountCommand
        {
            get { return new RelayCommand(CrearCuenta); }
            set { }
        }
   
        #endregion
        
        #region Methods
        private async void IniciarSesion()
        {
            
            String correo;
            String contraseña;
            if (EmailTxt.Equals(null)) { correo = ""; } else { correo = EmailTxt.ToString(); }
            if (PasswordTxt.Equals(null)) { contraseña = ""; } else { contraseña = PasswordTxt.ToString(); }

            if (correo != "" && contraseña != "")
            {
                UserDialogs.Instance.ShowLoading("Iniciando Sesión");
                await Task.Delay(500);
                usuario = UsuarioRepository.IniciarSesion(correo, contraseña);
                
                if (usuario != null)
                {
                    if (usuario.IdUsuario != 0)
                    {
                        
                        
                        if (usuario.TipoUsuario == MEDICO)
                        {
                            Settings.IdMedico = usuario.IdUsuario;
                            Application.Current.MainPage.Navigation.PushAsync(new NavegacionMedico()); 
                        }
                        if (usuario.TipoUsuario == PACIENTE)
                        {
                            Settings.IdPaciente = usuario.IdUsuario;
                            Application.Current.MainPage.DisplayAlert("Inicio de Sesión", "Abriendo Vista del Paciente", "Aceptar");
                            /*Application.Current.MainPage.Navigation.PushAsync(new PrincipalPaciente(usuario)); */
                        }
                        //await Task.Delay(2000);
                        UserDialogs.Instance.HideLoading();
                        Application.Current.MainPage.DisplayAlert("Inicio de Sesión", "Bienvenido " + usuario.Nombre, "Aceptar");
                    }
                    else { UserDialogs.Instance.HideLoading(); Application.Current.MainPage.DisplayAlert("Datos incorrectos", "Verifique su información", "Aceptar"); }
                }
                else if (usuario == null) { Application.Current.MainPage.DisplayAlert("Error de conexión con el servidor", "No se pudo verificar su cuenta", "Aceptar"); }
            }
            else { Application.Current.MainPage.DisplayAlert("Campos vacios", "Ingresa tu correo y contraseña", "Aceptar"); }
        }

        private void CrearCuenta()
        {
            Application.Current.MainPage.DisplayAlert("Crear Cuenta", "Abriendo nueva vista", "ok");
        }
        #endregion

        #region Constructor

        #endregion
    }
}
