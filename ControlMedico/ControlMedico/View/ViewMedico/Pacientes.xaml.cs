using ControlMedico.Model;
using ControlMedico.ViewModel;
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
    public partial class Pacientes : ContentPage
    {
        public Pacientes()
        {
            InitializeComponent();
            BindingContext = new PacientesViewModel();
        }
    }
}