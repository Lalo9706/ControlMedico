using System;
using System.Collections.Generic;
using System.Text;

namespace ControlMedico.Data.Model
{
    public class RegistroMedico
    {
        public int IdRegistroMedico { get; set; }
        public int Edad { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }
        public string PresionSanguinea { get; set; }
        public string NivelGlucosa { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public int IdCita { get; set; }
    }
}
