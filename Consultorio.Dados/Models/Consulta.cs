using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Dados.Models
{
    public class Consulta
    {
        public int Id { get; private set; }
        public string NumeroAtendimento { get; private set; }
        public string NumeroProntuario { get; private set; }
        public int MedicoId { get; private set; }
        public int ProcedimentoId { get; private set; }
        public DateTime DataConsulta { get; private set; }
        public int PacienteId { get; set; }
        public TimeSpan Horario { get; set; }

        public Consulta()
        {

        }

        public Consulta(int id, string atendimento, int medico, string data, int paciente)
        {
            this.Id = id;
            this.NumeroAtendimento = atendimento;
            //this.NumeroProntuario = prontuario;
            this.MedicoId = medico;
            this.DataConsulta = Convert.ToDateTime(data);
            this.PacienteId = paciente;
        }

        public int ConsultaProcedimento(int procedimento)
        {
            return this.ProcedimentoId = procedimento;
        }
    }
}
