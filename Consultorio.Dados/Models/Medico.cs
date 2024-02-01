using Consultorio.Dados.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Dados.Models
{
    public class Medico : ModelBase
    {
        public string NomeMedico { get; private set; }
        public DateTime DataNacimento { get; private set; }
        public string Sexo { get; private set; }
        public string CPF { get; private set; }
        public string CRO { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }
        public TimeSpan AtendimentoInicio { get; private set; }
        public TimeSpan AtendimentoFinal { get; private set; }
        public string Intervalo { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public Medico()
        {
            
        }

        public Medico(int id, Guid guid, string nome, DateTime data, string sexo, string cpf, string cro, string endereco, 
            string telefone, string inicio, string final, string intervalo)
        {
            this.Id = id;
            this.Guid = guid;
            this.NomeMedico = nome;
            this.DataNacimento = data;
            this.Sexo = sexo;
            this.CPF = cpf;
            this.CRO = cro;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.AtendimentoInicio = TimeSpan.Parse(inicio);
            this.AtendimentoFinal = TimeSpan.Parse(final);
            this.Intervalo = intervalo;
            this.DataCadastro = DateTime.Now;
        }

        public Medico(string nome, string inicio, string final, string intervalo)
        {
            this.NomeMedico= nome;
            this.AtendimentoInicio = TimeSpan.Parse(inicio);
            this.AtendimentoFinal = TimeSpan.Parse (final);
            this.Intervalo = intervalo;
        }

    }
}
