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
    public class AgendaService : IAgendaServices
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaService(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }
        public async Task<IEnumerable<AgendaViewModels>> ListarAgenda()
        {
            var retorno = await _agendaRepository.ListarAgenda();

            return retorno.Select(x => new AgendaViewModels()
            {
                
            });
        }
    }
}
