﻿using System;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Owin;
using Owin;
using ParlamentoTarefas.Tarefas.Parlamentares;

[assembly: OwinStartup(typeof(ParlamentoMvc.Startup))]

namespace ParlamentoMvc
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseNinjectActivator(new Ninject.Web.Common.Bootstrapper().Kernel)
                .UseSqlServerStorage("BaseConexao");

            RecurringJob.AddOrUpdate<AtualizarSenadoresTarefa>("AtualizarSenadores", j => j.Executar(), Cron.Yearly);

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
