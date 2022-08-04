using ControlMedico.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlMedico.View.ViewPaciente
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavegacionPaciente : TabbedPage
    {
        public NavegacionPaciente()
        {
            InitializeComponent();
            BindingContext = new NavegacionPacienteViewModel();
        }
    }
}