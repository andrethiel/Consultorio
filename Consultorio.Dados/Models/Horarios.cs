using Consultorio.Dados.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Dados.Models
{
    public class Horarios : ModelBase
    {
        public TimeSpan Horario { get; set; }
        public int MedicoId { get; set; }
    }
}
