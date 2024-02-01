using Consultorio.Dados.Context;
using Consultorio.Dados.Models;
using Consultorio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Domain.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly IContext context;

        public MedicoRepository(IContext context)
        {
            this.context = context;
        }
        public Task Alterar(Medico model)
        {
            throw new NotImplementedException();
        }

        public Task<Medico> BuscarPorGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<Medico> BuscarPorId(int id)
        {
            try
            {
                string sql = $"select * from medico where id = {id}";
                return await context.ExecuteQuery<Medico>(sql);
            }
            catch
            {
                throw new Exception("Erro ao buscar lista de medicos");
            }
        }

        public Task Incluir(Medico model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Medico>> Listar()
        {
            try
            {
                string sql = $"select * from medico";
                return await context.ExecuteList<Medico>(sql);
            }
            catch
            {
                throw new Exception("Erro ao buscar lista de medicos");
            }
        }

        public async Task<IEnumerable<Especialidades>> ListarEspecialidades(int id)
        {
            try
            {
                string sql = $"select E.* from Medico M, EspecialidadeMedico EM, Especialidades E where M.Id = EM.MedicoId and EM.EspecialidadeId = E.Id and MedicoId = {id}";
                return await context.ExecuteList<Especialidades>(sql);
            }
            catch
            {
                throw new Exception("Erro ao buscar lista de medicos");
            }
        }
    }
}
