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
            services.AddScoped<IAgendaService, AgendaService>();
            services.AddScoped<IHorarioRepository, HorarioRepository>();
            services.AddScoped<IHorarioService, HorarioService>();
            services.AddScoped<ISequenceRepository, SequenceRespository>();
            services.AddScoped<ISequenceService, SequenceService>();
            services.AddScoped<IPacienteRepository, PacienteRespository>();
            services.AddScoped<IPacienteService, PacienteServices>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IMedicoService, MedicoService>();
            services.AddScoped<IProcedimentoRepository, ProcedimentoRepository>();
            services.AddScoped<IProcedimentoService, ProcedimentoService>();
            services.AddScoped<IConsultaRepository, ConsultaRepository>();
            services.AddScoped<IConsultaService, ConsultaService>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
