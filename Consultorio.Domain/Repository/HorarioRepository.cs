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
        public async Task<List<Horarios>> HorariosAgenda(int medico, string data)
        {
            string sql = $"select H.* from Agenda A, Horarios H where A.MedicoId = {medico} and A.Horario = H.Id and A.Dia = '{data}'";

            var dados = await context.ExecuteList<Horarios>(sql);

            return dados;
        }

        public async Task<List<Horarios>> Horarios(int medico)
        {
            string sql = $"select * from Horarios where MedicoId = {medico}";

            var dados = await context.ExecuteList<Horarios>(sql);

            return dados;
        }


    }
}
