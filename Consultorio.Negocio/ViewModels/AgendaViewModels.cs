using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Negocio.ViewModels
{
    public class AgendaViewModels
    {
        public int Id { get; set; }
        public DateTime Dia { get; set; }
        public string Horario { get; set; }
        public int Profissional { get; set; }

        public AgendaViewModels()
        {
            
        }
    }
}
