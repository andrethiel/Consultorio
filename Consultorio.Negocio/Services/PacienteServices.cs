using Consultorio.Dados.Models;
using Consultorio.Domain.Interfaces;
using Consultorio.Negocio.Interfaces;
using Consultorio.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Negocio.Services
{
    public class PacienteServices : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteServices(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }
        public async Task<PacienteViewModel> BuscarGuid(Guid guid)
        {
            var paciente = await _pacienteRepository.BuscarGuid(guid);

            if (paciente == null)
                return new PacienteViewModel();

            return new PacienteViewModel()
            {
                Id = paciente.Id,
                Guid = paciente.Guid,
                NomePaciente = paciente.NomePaciente,
                DataNacimento = paciente.DataNacimento.ToString("yyyy/MM/dd"),
                CPF = paciente.CPF,
                Sexo = paciente.Sexo,
                Endereco = paciente.Endereco,
                Telefone = paciente.Telefone,
                NomeMae = paciente.NomeMae,
                
            };
        }

        public async Task Inserir(PacienteViewModel model)
        {
            var paciente = new Paciente(model.Id = 0, model.Guid = Guid.NewGuid(), model.NomePaciente, Convert.ToDateTime(model.DataNacimento), model.Sexo, model.CPF, model.NomeMae, model.Endereco, model.Telefone);

           await _pacienteRepository.Inserir(paciente);
        }

        public async Task<IEnumerable<PacienteViewModel>> Listar()
        {
            var paciente = await _pacienteRepository.Listar();

            if (paciente == null)
                return new List<PacienteViewModel>();

            return paciente.Select(x => new PacienteViewModel()
            {
                Id = x.Id,
                Guid = x.Guid,
                NomePaciente = x.NomePaciente,
                DataNacimento = x.DataNacimento.ToShortDateString(),
                
                NomeMae = x.NomeMae,
               
            }).ToList();
        }

        public async Task Modificar(PacienteViewModel model)
        {
            var paciente = new Paciente(model.Id, model.Guid,model.NomePaciente, Convert.ToDateTime(model.DataNacimento), model.Sexo, model.CPF, model.NomeMae, model.Endereco, model.Telefone);
            await _pacienteRepository.Modificar(paciente);
        }
    }
}
