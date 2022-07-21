using ControlMedico.View;
using ControlMedico.View.ViewMedico;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlMedico
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new IniciarSesion());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
