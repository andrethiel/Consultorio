using Consultorio.Dados.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Dados.Models
{
    public class Paciente : ModelBase
    {
        public string NomePaciente { get; private set; }
        public DateTime DataNacimento { get; private set; }
        public string Sexo { get; private set; }
        public string CPF { get; private set; }
        public string NomeMae { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataCadastro { get; private set; } 

        public Paciente()
        {
            
        }

        public Paciente(int id, Guid guid, string nome, DateTime data, string sexo, string cpf, string nomeMae, string endereco, string telefone)
        {
            
            this.Id = id;
            this.Guid = NewGuid(guid);
            this.NomePaciente = nome;
            this.DataNacimento = data;
            this.Sexo = sexo;
            this.CPF = cpf;
            this.NomeMae = nomeMae;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.DataCadastro = DateTime.Now;
        }

        public Paciente(string nomePaciente)
        {
            NomePaciente = nomePaciente;
        }

        private Guid NewGuid(Guid guid)
        {
            if(guid == Guid.Empty)
            {
                return Guid.NewGuid();
            }
            return guid;
        }
    }
}
