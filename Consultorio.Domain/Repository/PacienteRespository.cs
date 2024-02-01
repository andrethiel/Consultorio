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
    public class PacienteRespository : IPacienteRepository
    {
        private readonly IContext context;
        private readonly ISequenceRepository sequenceRepository;

        public PacienteRespository(IContext context, ISequenceRepository sequenceRepository)
        {
            this.context = context;
            this.sequenceRepository = sequenceRepository;
        }
        public async Task<Paciente> BuscarGuid(Guid guid)
        {
            try
            {
                string sql = $"select * from Paciente where Guid = '{guid}'";
                return await context.ExecuteQuery<Paciente>(sql);
            }
            catch
            {
                throw new Exception("Erro ao buscar paciente");
            }
        }

        public async Task<Paciente> BuscarPorId(int id)
        {
            try
            {
                string sql = $"select * from Paciente where id = '{id}'";
                return await context.ExecuteQuery<Paciente>(sql);
            }
            catch
            {
                throw new Exception("Erro ao buscar paciente");
            }
        }

        public async Task Inserir(Paciente model)
        {

            try
            {
                string sql = $"insert into Paciente (Guid, NomePaciente, DataNacimento, Sexo, CPF, NomeMae, Endereco, Telefone, DataCadastro) values " +
                    $"(@Guid, @NomePaciente, @DataNacimento, @Sexo, @CPF, @NomeMae, @Endereco, @Telefone, @DataCadastro) SELECT SCOPE_IDENTITY()";

                model.Id = await context.ExecuteSaveScalar(sql, model);
            }
            catch
            {
                throw new Exception($"Erro ao inserir paciente {model.NomePaciente}");
            }

            try
            {
                var numero = await sequenceRepository.SequenceProntuario();
                var prontuario = new Prontuario(numero.Id.ToString(), model.Id);
                string sql = $"insert into Prontuario (NumeroProntuario, PacienteId, DataCadastro) values (@NumeroProntuario,@PacienteId, @DataCadastro)";

                await context.ExecuteSave(sql, prontuario);
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao inserir paciente {model.NomePaciente}");
            }

        }

        public async Task<IEnumerable<Paciente>> Listar()
        {
            try
            {
                string sql = $"select * from Paciente";
                return await context.ExecuteList<Paciente>(sql);
            }
            catch
            {
                throw new Exception("Erro ao buscar lista de pacientes");
            }

        }

        public async Task Modificar(Paciente model)
        {
            try
            {
                string sql = $"update Paciente set NomePaciente = @NomePaciente, DataNacimento = @DataNacimento, Sexo = @Sexo, CPF = @CPF, NomeMae = @NomeMae, Endereco = @Endereco, Telefone = @Telefone";

                await context.ExecuteUpdate(sql, model);
            }
            catch
            {
                throw new Exception($"Erro ao alterar paciente {model.NomePaciente}");
            }

        }

        public async Task<Paciente> PacienteConsulta(string prontuario)
        {
            try
            {
                string sql = $"select P.* from Prontuario PR, Paciente P where P.Id = PR.PacienteId and PR.NumeroProntuario = {prontuario}";
                return await context.ExecuteQuery<Paciente>(sql);
            }
            catch
            {
                throw new Exception("Erro ao buscar lista de pacientes");
            }
        }
    }
}
