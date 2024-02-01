using Consultorio.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Domain.Interfaces
{
    public interface IPacienteRepository
    {
        Task Inserir(Paciente model);
        Task Modificar(Paciente model);
        Task<IEnumerable<Paciente>> Listar();
        Task<Paciente> BuscarGuid(Guid guid);
        Task<Paciente> BuscarPorId(int id);
        Task<Paciente> PacienteConsulta(string prontuario);
    }
}
