using Consultorio.Dados.Base;

namespace Consultorio.Dados.Models
{
    public class Agenda : ModelBase
    {
        public DateTime Dia { get; private set; }
        public int Horario { get; private set; }
        public int Profissional { get; private set; }
    }
}