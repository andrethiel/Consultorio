using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Dados.Context
{
    public interface IContext
    {
        Task<List<T>> ExecuteList<T>(string sql);

        Task<T> ExecuteQuery<T>(string sql);

        Task ExecuteSave<T>(string sql, T Parameters);
        Task ExecuteUpdate<T>(string sql, T Parameters);

        Task<int> ExecuteSaveScalar<T>(string sql, T Parameters);
    }
}
