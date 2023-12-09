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
        Task<IEnumerable<Horarios>> Horarios();
    }
}
