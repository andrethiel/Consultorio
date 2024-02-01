using Consultorio.Dados.Models;
using Consultorio.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Negocio.Interfaces
{
    public interface IMedicoService
    {
        Task Incluir(MedicoViewModel model);
        Task Alterar(MedicoViewModel model);
        Task<IEnumerable<MedicoViewModel>> Listar();
        Task<Medico> BuscarPorGuid(Guid guid);

    }
}
