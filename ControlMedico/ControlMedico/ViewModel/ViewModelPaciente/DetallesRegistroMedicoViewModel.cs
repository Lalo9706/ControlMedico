using ControlMedico.Data.Model;
using ControlMedico.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlMedico.ViewModel.ViewModelPaciente
{
    internal class DetallesRegistroMedicoViewModel : BaseViewModel
    {
        #region Attributes

        private int idCita;
        private RegistroMedico detalles;
        private int edad;
        private string peso;
        private string altura;
        private string presionSanguinea;
        private string nivelGlucosa;
        private string diagnostico;
        private string tratamiento;

        #endregion

        #region Properties

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

        public DetallesRegistroMedicoViewModel(int idCita)
        {
            this.idCita = idCita;
            this.detalles = RegistroMedicoRepository.RecuperarRegistroMedico(idCita);
            this.edad = detalles.Edad;
            this.peso = detalles.Peso;
            this.altura = detalles.Altura;
            this.presionSanguinea = detalles.PresionSanguinea;
            this.nivelGlucosa = detalles.NivelGlucosa;
            this.diagnostico = detalles.Diagnostico;
            this.tratamiento = detalles.Tratamiento;
        }
    }
}
