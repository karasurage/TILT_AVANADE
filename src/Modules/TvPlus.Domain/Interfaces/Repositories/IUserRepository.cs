using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvPlus.Domain.Entities;

namespace TvPlus.Domain.Interfaces.Repositories
{

    public interface IUserRepository
    {
        Task<int> InsertAsync(User user);
        Task UpdateAsync(User user);
        Task<User> GetByLoginAsync(string login);
        Task<User> GetByIdAsync(int id);
    }
}