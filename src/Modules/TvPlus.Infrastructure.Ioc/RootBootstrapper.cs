using Microsoft.Extensions.DependencyInjection;
using System;
using TvPlus.Infrastructure.Ioc.Application;
using TvPlus.Infrastructure.Ioc.Repository;

namespace TvPlus.Infrastructure.Ioc
{
    public class RootBootstrapper
    {

        public void RootRegisterServices(IServiceCollection services)
        {
            new ApplicationBootsTrapper().ChildServiceRegister(services);
            new RespositoryBootstrapper().ChildServiceRegister(services);
        }
    }
}
