using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Negocio.ViewModels
{
    public  class HorariosViewModels
    {
        public int Id { get; private set; }
        public string Horario { get; private set; }

        public HorariosViewModels(int id, string horario)
        {
            Id = id;
            Horario = horario;
        }
    }
}
