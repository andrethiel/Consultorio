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
        public async Task<IEnumerable<HorariosViewModel>> Horarios(int medico, string data)
        {
            var horarios = await _horarioRepository.Horarios(medico);
            var horariosAgenda = await _horarioRepository.HorariosAgenda(medico, data);

            if(horariosAgenda.Count > 0)
            {
                horarios.RemoveAll(x => horariosAgenda.Any(y => y.Id == x.Id));
            }

            return horarios.Select(x => new HorariosViewModel()
            {
                Id = x.Id,
                Horario = x.Horario.ToString(@"hh\:mm"),
                MedicoId = x.MedicoId
            });
        }
    }
}
