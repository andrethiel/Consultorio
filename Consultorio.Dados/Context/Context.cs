using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Dados.Context
{
    public class Context : IContext
    {
        private readonly IConfiguration _configuration;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Context()
        {

        }
        public async Task<List<T>> ExecuteList<T>(string sql)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("ConexaoPrincipal"));

            var dados = await connection.QueryAsync<T>(sql, null, commandType: CommandType.Text);

            return dados.ToList();
        }

        public async Task<T> ExecuteQuery<T>(string sql)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("ConexaoPrincipal"));

            var dados = await connection.QueryAsync<T>(sql, null, commandType: CommandType.Text);

            return dados.FirstOrDefault();
        }

        public async Task ExecuteSave<T>(string sql, T Parameters)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("ConexaoPrincipal"));

            await connection.ExecuteAsync(sql, Parameters, commandType: CommandType.Text);
        }

        public async Task ExecuteUpdate<T>(string sql, T Parameters)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("ConexaoPrincipal"));

            await connection.ExecuteAsync(sql, Parameters, commandType: CommandType.Text);
        }

        public async Task<int> ExecuteSaveScalar<T>(string sql, T Parameters)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("ConexaoPrincipal"));
            
            var dados = await connection.ExecuteScalarAsync<int>(sql, Parameters, commandType: CommandType.Text);

            return dados;
        }
    }
}
