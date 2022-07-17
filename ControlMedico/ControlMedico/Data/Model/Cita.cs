using System;
using System.Collections.Generic;
using System.Text;

namespace ControlMedico.Data.Model
{
    internal class Cita
    {
        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public String DescripcionCita { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
    }
}
