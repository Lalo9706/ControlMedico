using Acr.UserDialogs;
using CommunityToolkit.Mvvm.Input;
using ControlMedico.Data.Model;
using ControlMedico.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlMedico.ViewModel.ViewModelMedico
{
    internal class FormularioRegistroMedicoViewModel : BaseViewModel
    {
        #region Attributes
        private Cita citaSeleccionada;
        private RegistroMedico registroMedicoCita;
        private int edad;
        private string peso;
        private string altura;
        private string presionSanguinea;
        private string nivelGlucosa;
        private string diagnostico;
        private string tratamiento;

        #endregion


        #region Constructor
        public FormularioRegistroMedicoViewModel(Cita citaSeleccionada)
        {
            this.citaSeleccionada = citaSeleccionada;
            RegistroMedico registroTemp = RegistroMedicoRepository.RecuperarRegistroMedico(citaSeleccionada.IdCita);
            if (registroTemp != null)
            {
                this.registroMedicoCita = registroTemp;
                this.Edad = registroTemp.Edad;
                this.Peso = registroTemp.Peso;
                this.Altura = registroTemp.Altura;
                this.PresionSanguinea = registroTemp.PresionSanguinea;
                this.NivelGlucosa = registroTemp.NivelGlucosa;
                this.Diagnostico = registroTemp.Diagnostico;
                this.Tratamiento = registroTemp.Tratamiento;
            }
            else if (registroTemp == null)
            {
                this.Edad = 0;
                this.Peso = "";
                this.Altura = "";
                this.PresionSanguinea = "";
                this.NivelGlucosa = "";
                this.Diagnostico = "";
                this.Tratamiento = "";
            }
        }

        #endregion

        #region Properties

        public string NombreCompletoPaciente
        {
            get { return citaSeleccionada.NombreCompletoPaciente; }
        }

        public int Edad
        {
            get { return this.edad; }
            set { SetValue(ref this.edad, value); }
        }

        public string Peso
        {
            get { return this.peso; }
            set { SetValue(ref this.peso, value); }
        }

        public string Altura
        {
            get { return this.altura; }
            set { SetValue(ref this.altura, value); }
        }

        public string PresionSanguinea
        {
            get { return this.presionSanguinea; }
            set { SetValue(ref this.presionSanguinea, value); }
        }

        public string NivelGlucosa
        {
            get { return this.nivelGlucosa; }
            set { SetValue(ref this.nivelGlucosa, value); }
        }

        public string Diagnostico
        {
            get { return this.diagnostico; }
            set { SetValue(ref this.diagnostico, value); }
        }

        public string Tratamiento
        {
            get { return this.tratamiento; }
            set { SetValue(ref this.tratamiento, value); }
        }


        #endregion

        #region Commands

        public ICommand GuardarRMCommand
        {
            get { return new RelayCommand(GuardarRegistroMedico); }
            set { }
        }

        #endregion

        #region Methods

        public async void GuardarRegistroMedico()
        {
            Boolean validacion = false;
            if (!this.Edad.Equals(0)) { validacion = true; } else { validacion = false; }
            if (!this.Peso.Equals("")) { validacion = true; } else { validacion = false; }
            if (!this.Altura.Equals("")) { validacion = true; } else { validacion = false; }
            if (!this.PresionSanguinea.Equals("")) { validacion = true; } else { validacion = false; }
            if (!this.NivelGlucosa.Equals("")) { validacion = true; } else { validacion = false; }
            if (!this.Diagnostico.Equals("")) { validacion = true; } else { validacion = false; }
            if (!this.Tratamiento.Equals("")) { validacion = true; } else { validacion = false; }


            if (validacion != false)
            {
                RegistroMedico registroTemp = new RegistroMedico();
                registroTemp.Edad = this.Edad;
                registroTemp.Peso = this.Peso;
                registroTemp.Altura = this.Altura;
                registroTemp.PresionSanguinea = this.PresionSanguinea;
                registroTemp.NivelGlucosa = this.NivelGlucosa;
                registroTemp.Diagnostico = this.Diagnostico;
                registroTemp.Tratamiento = this.Tratamiento;
                registroTemp.IdCita = this.citaSeleccionada.IdCita;

                UserDialogs.Instance.ShowLoading("Guardando Registro Medico");
                await Task.Delay(500);
                int respuestaBD = RegistroMedicoRepository.GuardarRegistroMedico(registroTemp);

                if (respuestaBD > 0)
                {
                    await Application.Current.MainPage.Navigation.PopAsync();
                    await Application.Current.MainPage.Navigation.PopAsync();
                    UserDialogs.Instance.HideLoading();
                    await Application.Current.MainPage.DisplayAlert("Registro Medico", "Se guardarón los datos con exito", "Aceptar");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Registro Medico", "No se guardarón los datos, vuelva a intentarlo mas tarde", "Aceptar");
                    UserDialogs.Instance.HideLoading();
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Campos vacios", "Debe llenar todos los valores para guardar", "Aceptar");
            }

            #endregion

        }
    }
}
