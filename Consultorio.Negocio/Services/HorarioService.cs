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
    public class HorarioService : IHorarioService
    {
        private readonly IHorarioRepository _horarioRepository;

        public HorarioService(IHorarioRepository horarioRepository)
        {
            _horarioRepository = horarioRepository;
        }
        public async Task<IEnumerable<HorariosViewModels>> Horarios()
        {
            var retorno = await _horarioRepository.Horarios();

            return retorno.Select(x => new HorariosViewModels(x.Id, x.Horario.ToString()));
        }
    }
}
