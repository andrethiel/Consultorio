using Consultorio.Api.Controllers.BaseController;
using Consultorio.Negocio.Interfaces;
using Consultorio.Negocio.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Consultorio.Api.Controllers
{
    public class PacienteController : ApiBaseController
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpPost]
        [Route("Cadastro")]
        public async Task<IActionResult> Inserir(PacienteViewModel model)
        {
            try
            {
                await _pacienteService.Inserir(model);
                return Ok(new ResponseViewModel<PacienteViewModel>
                {
                    Sucesso = true,
                    Message = "Paciente inserido com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseViewModel<PacienteViewModel>
                {
                    Sucesso = false,
                    Message = ex.Message
                });
            }


        }

        [HttpPost]
        [Route("Modificar")]
        public async Task<IActionResult> Modificar(PacienteViewModel model)
        {
            try
            {
                await _pacienteService.Modificar(model);

                return Ok(new ResponseViewModel<PacienteViewModel>()
                {
                    Message = "Alterado com sucesso",
                    Sucesso = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseViewModel<PacienteViewModel>
                {
                    Sucesso = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                return Ok(new ResponseViewModel<IEnumerable<PacienteViewModel>>()
                {
                    Dados = await _pacienteService.Listar(),
                    Sucesso = true
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseViewModel<dynamic>
                {
                    Dados = new List<PacienteViewModel>(),
                    Message = ex.Message,
                    Sucesso = false
                });
            }
            

        }

        [HttpGet]
        [Route("Buscar")]
        public async Task<IActionResult> BuscarPorGuid(Guid guid)
        {
            try
            {
                return Ok(new ResponseViewModel<PacienteViewModel>
                {
                    Dados = await _pacienteService.BuscarGuid(guid),
                    Sucesso = true
                });
            }
            catch(Exception ex)
            {
                return Ok(new ResponseViewModel<dynamic>
                {
                    Dados = new PacienteViewModel(),
                    Message = ex.Message,
                    Sucesso = false
                });
            }
        }
    }
}