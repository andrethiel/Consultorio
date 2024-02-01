using Consultorio.Dados.Context;
using Consultorio.Dados.Models;
using Consultorio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Domain.Repository
{
    public class SequenceRespository : ISequenceRepository
    {
        private readonly IContext context;

        public SequenceRespository(IContext context)
        {
            this.context = context;
        }

        public async Task<Sequence> SequenceAtendimento()
        {
            string sql = "select next value for Atendimento.AtendimentoSequence As Id";

            return await context.ExecuteQuery<Sequence>(sql);
        }

        public async Task<Sequence> SequencePaciente()
        {
            string sql = "select next value for Paciente.PacienteSequence As Id";
            
            return await context.ExecuteQuery<Sequence>(sql);
        }

        public async Task<Sequence> SequenceProntuario()
        {
            string sql = "select next value for Prontuario.ProntuarioSequence As Id";

            return await context.ExecuteQuery<Sequence>(sql);
        }

    }
}
