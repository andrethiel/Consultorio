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
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }
        public Task Alterar(MedicoViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<Medico> BuscarPorGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task Incluir(MedicoViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MedicoViewModel>> Listar()
        {
            var medico = await _medicoRepository.Listar();
            

            if (medico == null)
                return new List<MedicoViewModel>();

            return medico.Select(x => new MedicoViewModel()
            {
                Id = x.Id,
                Guid = x.Guid,
                NomeMedico = x.NomeMedico,
                AtendimentoInicio = x.AtendimentoInicio,
                AtendimentoFinal = x.AtendimentoFinal,
                Intervalo = x.Intervalo,
                Especialidades = _medicoRepository.ListarEspecialidades(x.Id).Result

            }).ToList();
        }
    }
}
