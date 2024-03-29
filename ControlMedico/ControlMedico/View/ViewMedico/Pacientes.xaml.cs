﻿using ControlMedico.Model;
using ControlMedico.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        Usuario pacienteSeleccionado = new Usuario();
        public Pacientes()
        {
            InitializeComponent();
            BindingContext = new PacientesViewModel();
        }

        void OnListViewScrolled(object sender, ScrolledEventArgs e)
        {
            Debug.WriteLine("ScrollX: " + e.ScrollX);
            Debug.WriteLine("ScrollY: " + e.ScrollY);
        }

        private void pacientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            pacienteSeleccionado = (Usuario)e.SelectedItem;
        }

        private void ProgramarCita_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FormularioCita(pacienteSeleccionado));
        }
    }
}