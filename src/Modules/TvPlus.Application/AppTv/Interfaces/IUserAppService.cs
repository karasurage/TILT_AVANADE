using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvPlus.Application.AppTv.Input;
using TvPlus.Domain.Entities;

namespace TvPlus.Application.AppTv.Interfaces
{
    public interface IUserAppService
    {
        void Insert(UserInput usuario);
        Task<User> GetByIdAsync(int id);

       IEnumerable<User> Get();
    }
}
