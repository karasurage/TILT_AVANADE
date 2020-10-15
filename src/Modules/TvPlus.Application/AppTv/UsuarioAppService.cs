using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Application.AppTv.Input;
using TvPlus.Application.AppTv.Interfaces;
using TvPlus.Domain.Entities;
using TvPlus.Domain.Interfaces.Repositories;

namespace TvPlus.Application.AppTv
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioAppService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<Usuario> Get()
        {
            return _usuarioRepository.Get();
        }

        public Usuario GetById(Guid id)
        {
            return _usuarioRepository.GetById(id); 
        }

        public Guid Insert(UsuarioInput input)
        {
            var usuairo = new Usuario(input.Name, input.Email, input.CPF, input.Phone );

            if (!usuairo.IsValid())
            {
                throw new ArgumentException("Os dados obrigatórios não foram preenchidos!");
            }

            _usuarioRepository.Insert(usuairo);

            return usuairo.Id;
        }
    }
}
