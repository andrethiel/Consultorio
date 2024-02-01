using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Negocio.ViewModels
{
    public class PacienteViewModel
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Nome do paciente é obrigatório")]
        public string NomePaciente { get; set; }

        [DateValidation(ErrorMessage = "Data de nascimento é obrigatório")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy", ApplyFormatInEditMode = true)]
        [DataType(DataType.Text)]
        public string DataNacimento { get; set; }

        [Required(ErrorMessage = "Só é aceito M ou F no campo sexo")]
        [DataType(DataType.Text)]
        [MaxLength(1)]
        public string Sexo { get; set; }

        [ValidateCPF(ErrorMessage = "O CPF é Invalido")]
        [DataType(DataType.Text)]
        public string CPF { get; set; }
        
        [DataType(DataType.Text)]
        public string NomeMae { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]
        [DataType(DataType.Text)]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O Telefone é obrigatório")]
        [DataType(DataType.Text)]
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Horario { get; set; }
    }
    public class DateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (Convert.ToDateTime(value) == new DateTime(0001, 01, 01, 00, 00, 00) || Convert.ToDateTime(value) == new DateTime(0001, 01, 01))
            {
                return false;
            }
            return true;
        }
    }

    public class ValidateCPF : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf, digito, CPF;
            int soma, resto;

            CPF = value.ToString();

            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)
                return false;

            tempCpf = CPF.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto == 0)
                return false;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito +resto.ToString();
            return CPF.EndsWith(digito);
        }
    }
}
