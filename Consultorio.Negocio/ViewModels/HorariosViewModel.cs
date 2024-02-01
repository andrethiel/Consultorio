using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Negocio.ViewModels
{
    public  class HorariosViewModel
    {
        public int Id { get;  set; }
        public string Horario { get;  set; }
        public int MedicoId { get; set; }

    }
}
