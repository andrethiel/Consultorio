using Consultorio.Dados.Context;
using Consultorio.Dados.Models;
using Consultorio.Domain.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Consultorio.Domain.Repository
{
    public class AgendaRespository : IAgendaRepository
    {
        private readonly IContext context;

        public AgendaRespository(IContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Agenda>> ListarAgenda()
        {
            string sql = "select * from agenda";

            return await context.ExecuteList<Agenda>(sql);
            
        }
    }
}
