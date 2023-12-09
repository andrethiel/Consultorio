using Consultorio.Dados.Base;

namespace Consultorio.Dados.Models
{
    public class Agenda : ModelBase
    {
        public DateTime Dia { get; set; }
        public int Horario { get; set; }
        public int Profissional { get; set; }
    }
}