﻿using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Domain.Entities;

namespace TvPlus.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {

        void Insert(Usuario usuario);
        Usuario GetById(Guid id);
        IEnumerable<Usuario> Get();
    }
}
