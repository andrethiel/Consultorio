using Consultorio.Dados.Models;
using Consultorio.Domain.Interfaces;
using Consultorio.Negocio.Interfaces;
using Consultorio.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Negocio.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository _consultaRepository;
        public ConsultaService(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }
        public Task Inserir(ConsultaViewModel model)
        {
            return _consultaRepository.Inserir(new Consulta(model.Id, model.NumeroAtendimento, model.MedicoId, model.DataConsulta, model.PacienteId));
        }
    }
}
