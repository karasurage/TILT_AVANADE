using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Application.AppTv;
using TvPlus.Application.AppTv.Interfaces;

namespace TvPlus.Infrastructure.Ioc.Application
{
    internal class ApplicationBootsTrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
        }

    }
}
