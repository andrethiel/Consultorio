using Consultorio.Dados.Models;
using Consultorio.Domain.Interfaces;
using Consultorio.Negocio.Interfaces;
using Consultorio.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Negocio.Services
{
    public class SequenceService : ISequenceService
    {
        private readonly ISequenceRepository _sequenceRepository;

        public SequenceService(ISequenceRepository sequenceRepository)
        {
            _sequenceRepository = sequenceRepository;
        }

        public async Task<SequenceViewModel> SequenceAtendimento()
        {
            var dados = await _sequenceRepository.SequenceAtendimento();

            return new SequenceViewModel()
            {
                Numero = dados.Id
            };
        }

        public async Task<Sequence> SequencePaciente() => await _sequenceRepository.SequencePaciente();

        public async Task<Sequence> SequenceProntuario() => await _sequenceRepository.SequenceProntuario();
    }
}
