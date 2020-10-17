using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvPlus.Application.AppTv.Input;
using TvPlus.Domain.Entities;

namespace TvPlus.Application.AppTv.Interfaces
{
    public interface IUsuarioAppService
    {
        Usuario Insert(UsuarioInput usuario);
        Task<Usuario> GetByIdAsync(int id);
        IEnumerable<Usuario> Get();
    }
}
