using Consultorio.Negocio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaServices _agendaServices;

        public AgendaController(IAgendaServices agendaServices) 
        {
            _agendaServices = agendaServices;
        }

        [HttpGet]
        public async Task<IActionResult> Agenda()
        {
            return Ok(await _agendaServices.ListarAgenda());
        }

    }
}
