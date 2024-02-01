using Consultorio.Api.Controllers.BaseController;
using Consultorio.Negocio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Api.Controllers
{
    public class SequenceController : ApiBaseController
    {
        private readonly ISequenceService _sequenceServices;

        public SequenceController(ISequenceService sequenceServices)
        {
            _sequenceServices = sequenceServices;
        }

        [HttpGet]
        [Route("Paciente")]
        public async Task<IActionResult> Paciente()
        {
            return Ok(await _sequenceServices.SequencePaciente());
        }

        [HttpGet]
        [Route("Prontuario")]
        public async Task<IActionResult> Prontuario()
        {
            return Ok(await _sequenceServices.SequenceProntuario());
        }

        [HttpGet]
        [Route("Atendimento")]
        public async Task<IActionResult> Atendimento()
        {
            return Ok(await _sequenceServices.SequenceAtendimento());
        }
    }
}
