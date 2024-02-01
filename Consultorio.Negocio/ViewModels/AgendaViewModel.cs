using Consultorio.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Negocio.ViewModels
{
    public class AgendaViewModel
    {
        public Medico Medico { get; set; }
        public string DataConsulta { get; set; }
        public List<PacienteViewModel> Pacientes { get; set;}
    }
}
