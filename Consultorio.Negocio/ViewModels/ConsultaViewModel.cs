using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Negocio.ViewModels
{
    public class ConsultaViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Nome do atendimento é obrigatório")]
        public string NumeroAtendimento { get; set; }

        //[DataType(DataType.Text)]
        //[Required(ErrorMessage = "Nome do atendimento é obrigatório")]
        //public string NumeroProntuario { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "É obrigatório selecionar um medico")]
        public int MedicoId { get; set; }

        [DataType(DataType.Text)]
        //[Required(ErrorMessage = "É obrigatório selecionar um procedimento")]
        public int ProcedimentoId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "É obrigatório selecionar a data da consulta")]
        public string DataConsulta { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "É obrigatório selecionar um paciente")]
        public int PacienteId { get; set; }

    }
}
