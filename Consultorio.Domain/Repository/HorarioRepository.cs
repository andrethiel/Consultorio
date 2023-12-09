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
    public class HorarioRepository : IHorarioRepository
    {
        private readonly IContext context;

        public HorarioRepository(IContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Horarios>> Horarios()
        {
            string sql = "select b.* from Agenda a right join Horarios b on a.Horario = b.ID and a.Dia = '18/11/2023' and a.profissional = 1 where a.Horario is null";

            var dados = await context.ExecuteList<Horarios>(sql);

            return dados;
        }

        
    }
}
