using Consultorio.Dados.Models;
using Consultorio.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Negocio.Interfaces
{
    public interface ISequenceService
    {
        Task<Sequence> SequencePaciente();

        Task<Sequence> SequenceProntuario();

        Task<SequenceViewModel> SequenceAtendimento();
    }
}
