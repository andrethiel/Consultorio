using Consultorio.Api.Controllers.BaseController;
using Consultorio.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Api.Controllers
{
    public class HorariosController : ApiBaseController
    {
        private readonly IHorarioService horarioService;

        public HorariosController(IHorarioService horarioService)
        {
            this.horarioService = horarioService;   
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await horarioService.Horarios());
        }
    }
}
