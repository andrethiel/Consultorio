using Consultorio.Api.Controllers.BaseController;
using Consultorio.Negocio.Interfaces;
using Consultorio.Negocio.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Api.Controllers
{
    public class MedicoController : ApiBaseController
    {
        private readonly IMedicoService _mediicoService;
        public MedicoController(IMedicoService mediicoService)
        {
            _mediicoService = mediicoService;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar(int medico, string data)
        {
            try
            {
                return Ok(new ResponseViewModel<IEnumerable<MedicoViewModel>>()
                {
                    Dados = await _mediicoService.Listar(),
                    Sucesso = true
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseViewModel<dynamic>
                {
                    Dados = new List<MedicoViewModel>(),
                    Message = ex.Message,
                    Sucesso = false
                });
            }
        }
    }
}
