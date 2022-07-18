using ControlMedico.Model;
using ControlMedico.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlMedico.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalMedico : ContentPage
    {
        public PrincipalMedico(Usuario usuario)
        {
            InitializeComponent();
            BindingContext = new PrincipalMedicoViewModel(usuario);
        }
    }
}
