using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvPlus.Application.AppTv.Output;

namespace TvPlus.Application.AppTv.Interfaces
{
    
    public interface ILoginAppService
    {
        Task<UserViewModel> LoginAsync(string login, string password);
    }
}
