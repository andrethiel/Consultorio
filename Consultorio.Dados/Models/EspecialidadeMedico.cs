using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Dados.Models
{
    public class EspecialidadeMedico
    {
        public Medico MedicoId { get; set; }
        public Especialidades Especialidade { get; set; }
    }
}
