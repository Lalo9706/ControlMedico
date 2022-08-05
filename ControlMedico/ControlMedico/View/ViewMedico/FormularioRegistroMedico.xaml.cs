using ControlMedico.Data.Model;
using ControlMedico.ViewModel.ViewModelMedico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlMedico.View.ViewMedico
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioRegistroMedico : ContentPage
    {
        public FormularioRegistroMedico(Cita citaSeleccionada)
        {
            InitializeComponent();
            BindingContext = new FormularioRegistroMedicoViewModel(citaSeleccionada);
        }
    }
}