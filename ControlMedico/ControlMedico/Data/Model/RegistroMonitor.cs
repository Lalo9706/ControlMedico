using System;
using System.Collections.Generic;
using System.Text;

namespace ControlMedico.Data.Model
{
    public class RegistroMonitor
    {
        public int IdRegistroMonitor { get; set; }
        public DateTime FechaHoraRegistro { get; set; }
        public int PPM { get; set; }
        public int Oxigen { get; set; }
        public int Temp { get; set; }
        public int Estado { get; set; }
        public int IdPaciente { get; set; }
        public string NombreCompletoPaciente { get; set; }
    }
}
