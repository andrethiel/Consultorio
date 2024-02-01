using Consultorio.Api.Controllers.BaseController;
using Consultorio.Negocio.Interfaces;
using Consultorio.Negocio.Services;
using Consultorio.Negocio.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Api.Controllers
{
    public class AgendaController : ApiBaseController
    {
        private readonly IAgendaService _agendaServices;

        public AgendaController(IAgendaService agendaServices) 
        {
            _agendaServices = agendaServices;
        }

        [HttpGet]
        public async Task<IActionResult> Agenda(string data)
        {
            try
            {
                return Ok(new ResponseViewModel<List<AgendaViewModel>>()
                {
                    Dados = await _agendaServices.ListarAgenda(data),
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
