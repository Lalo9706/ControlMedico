using System;
using System.Collections.Generic;
using System.Text;

namespace ControlMedico.Model
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String TelefonoLocal { get; set; }
        public String TelefonoCelular { get; set; }
        public String Domicilio { get; set; }
        public int TipoUsuario { get; set; } // 0 = Medico, 1 = Paciente
        public String CorreoElectronico { get; set; }
        public String Contraseña { get; set; }

    }
}
