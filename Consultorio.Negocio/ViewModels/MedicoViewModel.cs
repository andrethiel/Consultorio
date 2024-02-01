using Consultorio.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Negocio.ViewModels
{
    public class MedicoViewModel
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string NomeMedico { get; set; }
        public string DataNacimento { get; set; }
        public string Sexo { get; set; }
        public string CPF { get; set; }
        public string CRO { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public TimeSpan AtendimentoInicio { get; set; }
        public TimeSpan AtendimentoFinal { get; set; }
        public string Intervalo { get; set; }
        public IEnumerable<Especialidades> Especialidades { get; set; }
        public List<Paciente> Pacientes { get; set;}
    }
}
