using Microsoft.Extensions.DependencyInjection;
using TvPlus.Domain.Interfaces.Repositories;
using TvPlus.Infrastrutucture.Repositories;

namespace TvPlus.Infrastructure.Ioc.Repository
{
    internal class RespositoryBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }

    }
}
