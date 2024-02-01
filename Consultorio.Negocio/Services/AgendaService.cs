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
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IConsultaRepository _consultaRepository;

        public AgendaService(IAgendaRepository agendaRepository, IConsultaRepository consultaRepository, IMedicoRepository medicoService,
            IPacienteRepository pacienteRepository)
        {
            _agendaRepository = agendaRepository;
            _consultaRepository = consultaRepository;
            _medicoRepository = medicoService;
            _pacienteRepository = pacienteRepository;
        }
        public async Task<List<AgendaViewModel>> ListarAgenda(string data)
        {
            var agendaLista = new List<AgendaViewModel>();
            var pacienteLista = new List<PacienteViewModel>();
            var consultas = await _consultaRepository.ListarConsultaMedico(data);
            var medico = await _medicoRepository.Listar();
            foreach (var item in medico)
            {
                var agenda = new AgendaViewModel();
               
                var consulta = consultas.Where(x => x.MedicoId == item.Id).ToList();
                
                agenda.DataConsulta = consulta.Select(x => x.DataConsulta).FirstOrDefault().ToString("dd/MM/yyyy");

                if (consulta.Count > 0)
                {
                    agenda.Medico = new Medico(item.NomeMedico, item.AtendimentoInicio.ToString(), item.AtendimentoFinal.ToString(), item.Intervalo);

                    foreach (var pac in consulta)
                    {
                        var consultaPaciente = await _pacienteRepository.PacienteConsulta(pac.NumeroProntuario);
                        var paciente = new PacienteViewModel()
                        {
                            NomePaciente = consultaPaciente.NomePaciente,
                            Horario = pac.Horario.ToString(@"hh\:mm")
                    };
                        pacienteLista.Add(paciente);
                        agenda.Pacientes = pacienteLista;
                    }
                    agendaLista.Add(agenda);
                }
                
            }

            return agendaLista;
        }
    }
}
