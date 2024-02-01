using Consultorio.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Domain.Interfaces
{
    public interface ISequenceRepository
    {
        Task<Sequence> SequencePaciente();

        Task<Sequence> SequenceProntuario();

        Task<Sequence> SequenceAtendimento();
    }
}
