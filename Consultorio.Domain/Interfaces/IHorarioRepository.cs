using Consultorio.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Domain.Interfaces
{
    public interface IHorarioRepository
    {
        Task<List<Horarios>> Horarios(int medico);
        Task<List<Horarios>> HorariosAgenda(int medico, string data);
    }
}
