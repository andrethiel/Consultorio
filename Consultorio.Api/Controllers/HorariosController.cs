using Consultorio.Api.Controllers.BaseController;
using Consultorio.Negocio.Interfaces;
using Consultorio.Negocio.ViewModels;
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
        public async Task<IActionResult> Get(int medico, string data)
        {
            try
            {
                return Ok(new ResponseViewModel<IEnumerable<HorariosViewModel>>()
                {
                    Dados = await horarioService.Horarios(medico, data),
                    Sucesso = true
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseViewModel<dynamic>
                {
                    Dados = new List<HorariosViewModel>(),
                    Message = ex.Message,
                    Sucesso = false
                });
            }

        }
    }
}
