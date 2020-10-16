using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Application.AppTv.Input;
using TvPlus.Domain.Entities;

namespace TvPlus.Application.AppTv.Interfaces
{
    public interface IUsuarioAppService
    {
        Usuario Insert(UsuarioInput usuario);
        Usuario GetById(int id);
        IEnumerable<Usuario> Get();
    }
}
