using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Dados.Context
{
    public interface IContext
    {
        Task<IEnumerable<T>> ExecuteList<T>(string sql);
    }
}
