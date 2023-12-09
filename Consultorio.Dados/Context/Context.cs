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
        public async Task<IEnumerable<T>> ExecuteList<T>(string sql)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("ConexaoPrincipal"));

            var dados = await connection.QueryAsync<T>(sql, null, commandType: CommandType.Text);

            return dados;
        }
    }
}
