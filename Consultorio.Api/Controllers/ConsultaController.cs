using Consultorio.Api.Controllers.BaseController;
using Consultorio.Dados.Models;
using Consultorio.Negocio.Interfaces;
using Consultorio.Negocio.Services;
using Consultorio.Negocio.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Consultorio.Api.Controllers
{
    public class ConsultaController : ApiBaseController
    {
        private readonly IConsultaService _consultaService;
        private readonly IPacienteService _pacienteService;
        private readonly ISequenceService _sequenceService;
        public ConsultaController(IConsultaService consultaService)
        {
           _consultaService = consultaService;
        }

        [HttpPost]
        [Route("Inserir")]
        public async Task<IActionResult> Inserir(ConsultaViewModel model)
        {
            try
            {
                await _consultaService.Inserir(model);

                return Ok(new ResponseViewModel<ConsultaViewModel>()
                {
                    Dados = null,
                    Sucesso = true,
                    Message= "Inserido com sucesso"
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseViewModel<dynamic>
                {
                    Dados = new List<ConsultaViewModel>(),
                    Message = ex.Message,
                    Sucesso = false
                });
            }
        }
    }
}
