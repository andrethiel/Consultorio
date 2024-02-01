using Consultorio.Dados.Models;
using Consultorio.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Negocio.Interfaces
{
    public interface IHorarioService
    {
        Task<IEnumerable<HorariosViewModel>> Horarios(int medico, string data);
    }
}
