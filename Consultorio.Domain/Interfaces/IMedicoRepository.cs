using Consultorio.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Domain.Interfaces
{
    public interface IMedicoRepository
    {
        Task Incluir(Medico model);
        Task Alterar(Medico model);
        Task<List<Medico>> Listar();
        Task<Medico> BuscarPorGuid(Guid guid);
        Task<Medico> BuscarPorId(int id);
        Task<IEnumerable<Especialidades>> ListarEspecialidades(int id);
    }
}
