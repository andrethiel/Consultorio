using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Negocio.ViewModels
{
    public class ResponseViewModel<T>
    {
        public T Dados { get; set; }
        public bool Sucesso { get; set; }
        public string Message { get; set; }
    }
}
