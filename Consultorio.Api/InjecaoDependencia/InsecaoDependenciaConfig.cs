using Consultorio.Dados.Context;
using Consultorio.Domain.Interfaces;
using Consultorio.Domain.Repository;
using Consultorio.Negocio.Interfaces;
using Consultorio.Negocio.Services;

namespace Consultorio.Api.InjecaoDependencia
{
    public static class InsecaoDependenciaConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IContext, Context>();
            services.AddScoped<IAgendaRepository, AgendaRespository>();
            services.AddScoped<IAgendaServices, AgendaService>();
            services.AddScoped<IHorarioRepository, HorarioRepository>();
            services.AddScoped<IHorarioService, HorarioService>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
