using System;
using System.Collections.Generic;
using System.Text;

namespace ControlMedico.ViewModel.ViewModelMedico
{
    internal class MonitorViewModel : BaseViewModel
    {

        #region Attriutes

        public string nombrePaciente;
        public List<string> pickerSource = new List<string>();

        #endregion

        #region Properties

        public string NombrePaciente
        {
            get { return this.nombrePaciente; }
            set { SetValue(ref this.nombrePaciente, value); }
        }

        public List<string> PickerSource
        {
            get { return new List<string> {"Aldo, Esteban, Alfredo" }; }
        }

        #endregion
    }
}
