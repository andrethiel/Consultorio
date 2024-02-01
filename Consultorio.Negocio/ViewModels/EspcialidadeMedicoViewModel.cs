using Consultorio.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Negocio.ViewModels
{
    public class EspcialidadeMedicoViewModel
    {
        public Medico MedicoId { get; set; }
        public Especialidades Especialidade { get; set; }
    }
}
