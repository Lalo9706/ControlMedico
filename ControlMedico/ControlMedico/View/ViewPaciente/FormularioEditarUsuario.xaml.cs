using ControlMedico.ViewModel.ViewModelPaciente;
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
    public partial class FormularioEditarUsuario : ContentPage
    {
        public FormularioEditarUsuario()
        {
            InitializeComponent();
            BindingContext = new FormularioEditarUsuarioViewModel();
        }
    }
}