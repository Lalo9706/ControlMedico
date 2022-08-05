using ControlMedico.ViewModel.ViewModelMedico;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlMedico.View.ViewMedico
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrosMonitor : ContentPage
    {
        public RegistrosMonitor(string nombrePaciente, int idPacienteMonitoreado)
        {
            InitializeComponent();
            BindingContext = new RegistrosMonitorViewModel(nombrePaciente, idPacienteMonitoreado);
        }

        void OnListViewScrolled(object sender, ScrolledEventArgs e)
        {
            Debug.WriteLine("ScrollX: " + e.ScrollX);
            Debug.WriteLine("ScrollY: " + e.ScrollY);
        }

    }
}
