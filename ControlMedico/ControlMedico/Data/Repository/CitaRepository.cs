using ControlMedico.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedico.Data.Repository
{
    internal class CitaRepository
    {
        #region
        private static string QUERY_RECUPERAR_CITAS_MEDICO =
            "SELECT ";
        #endregion

        internal static Task<List<Cita>> RecuperarCitasMedico(int idMedico)
        {
            throw new NotImplementedException();
        }

        internal static Task<List<Cita>> RecuperarCitasPaciente(int idPaciente)
        {
            throw new NotImplementedException();
        }
    }
}
