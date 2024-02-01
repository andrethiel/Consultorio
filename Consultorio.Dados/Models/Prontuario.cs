using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Dados.Models
{
    public class Prontuario
    {
        public string NumeroProntuario { get; private set; }
        public int PacienteId { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public Prontuario(string prontuario, int paciente)
        {
            this.NumeroProntuario = prontuario;
            this.PacienteId = paciente;
            this.DataCadastro = DateTime.Now;
        }
    }
}
