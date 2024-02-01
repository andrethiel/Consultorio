using Consultorio.Dados.Models;
using Consultorio.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Negocio.Interfaces
{
    public interface IPacienteService
    {
        Task Inserir(PacienteViewModel model);
        Task Modificar(PacienteViewModel model);
        Task<IEnumerable<PacienteViewModel>> Listar();
        Task<PacienteViewModel> BuscarGuid(Guid guid);
    }
}
