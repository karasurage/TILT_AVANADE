using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Application.AppTv.Input;
using TvPlus.Domain.Entities;

namespace TvPlus.Application.AppTv.Interfaces
{
    public interface IUsuarioAppService
    {
        Guid Insert(UsuarioInput usuario);
        Usuario GetById(Guid id);
        IEnumerable<Usuario> Get();
    }
}
