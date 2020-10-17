using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvPlus.Domain.Entities;

namespace TvPlus.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {

        int Insert(Usuario usuario);
        Task<Usuario> GetByIdAsync(int id);
        IEnumerable<Usuario> Get();
    }
}
