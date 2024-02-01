using Consultorio.Dados.Context;
using Consultorio.Dados.Models;
using Consultorio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Domain.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly IContext context;

        public ConsultaRepository(IContext context)
        {
            this.context = context;
        }
        public async Task Inserir(Consulta model)
        {
            try
            {
                string sql = $"insert into Consulta (NumeroAtendimento, NumeroProntuario, MedicoId, DataConsulta) values " +
                    $"(@NumeroAtendimento, (select NumeroProntuario from Prontuario where PacienteId = {model.PacienteId}), @MedicoId, @DataConsulta)";

                await context.ExecuteSave(sql, model);
            }
            catch
            {
                throw new Exception($"Erro ao inserir consulta");
            }
        }

        public async Task<List<Consulta>> ListarConsultaMedico(string data)
        {
            string sql = $"select C.MedicoId, C.DataConsulta, C.NumeroProntuario, H.Horario from Consulta C, Horarios H where C.DataConsulta = '{data}' and C.HorarioId = H.Id";

            return await context.ExecuteList<Consulta>(sql);
        }
    }
}
