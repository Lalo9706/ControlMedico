using System;
using System.Collections.Generic;
using System.Text;

namespace ControlMedico.Data.Model
{
    public class Cita
    {
        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Descripcion { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public string NombreCompletoPaciente { get; set; }
    }
}
