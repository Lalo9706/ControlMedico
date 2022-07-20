﻿using CommunityToolkit.Mvvm.Input;
using ControlMedico.Data;
using ControlMedico.Data.Repository;
using ControlMedico.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlMedico.ViewModel.ViewModelMedico
{
    internal class InicioMedicoViewModel : BaseViewModel
    {
        #region Attributes
        public object listViewSource = CitaRepository.RecuperarCitasMedico(Settings.IdMedico, DateTime.Today);
        public string hora;
        public string descripcion;
        public int idMedico = Settings.IdMedico;
        public bool isRefreshing = false;
        public CultureInfo CultureInfo => new CultureInfo("es-ES");
        private DateTime fechaSeleccionada = DateTime.Today;
        public string lblDiaSeleccionado = "Citas para Hoy";
        #endregion


        #region Properties
        public object ListViewSource
        {
            get { return this.listViewSource; }
            set { SetValue(ref this.listViewSource, value); }
        }

        public string Hora
        {
            get { return this.hora;}
            set { SetValue(ref this.hora, value); }
        }

        public string Descripcion
        {
            get { return this.descripcion; }
            set { SetValue(ref this.descripcion, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public DateTime FechaSeleccionada
        {
            get { return this.fechaSeleccionada; }
            set { SetValue(ref this.fechaSeleccionada, value); }
        }

        public string LblDiaSeleccionado
        {
            get { return this.lblDiaSeleccionado; }
            set { SetValue(ref this.lblDiaSeleccionado, value); }
        }
        #endregion

        #region Commands

        public ICommand FechaSeleccionadaCommand
        {
            get { return new RelayCommand(RecuperarCitasPorFecha); }
            set { }
        }

        #endregion


        #region Methods

        public void RecuperarCitasPorFecha()
        {
            this.IsRefreshing = true;
            this.ListViewSource = CitaRepository.RecuperarCitasMedico(Settings.IdMedico, fechaSeleccionada);
            if (FechaSeleccionada == DateTime.Today)
            {
                this.LblDiaSeleccionado = "Citas para Hoy";
            }
            else
            {
                this.LblDiaSeleccionado = "Citas para el dia " + FechaSeleccionada.ToString("dd/MM/yyyy");
            }

            this.IsRefreshing = false;
        }

        #endregion
    }
}