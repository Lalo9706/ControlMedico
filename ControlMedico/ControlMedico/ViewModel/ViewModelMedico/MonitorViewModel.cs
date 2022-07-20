using System;
using System.Collections.Generic;
using System.Text;

namespace ControlMedico.ViewModel.ViewModelMedico
{
    internal class MonitorViewModel : BaseViewModel
    {

        #region Attriutes

        public string nombrePaciente;

        #endregion

        #region Properties

        public string NombrePaciente
        {
            get { return this.nombrePaciente; }
            set { SetValue(ref this.nombrePaciente, value); }
        }

        #endregion
    }
}
