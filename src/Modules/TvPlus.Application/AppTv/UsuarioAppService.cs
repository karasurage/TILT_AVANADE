﻿using System;
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

        public Usuario GetById(int id)
        {
            return _usuarioRepository.GetById(id); 
        }

        public Usuario Insert(UsuarioInput input)
        {
            try
            {
                var usuairo = new Usuario(input.Name, input.Email, input.Phone, input.CPF);

                if (!usuairo.IsValid())
                {
                    throw new ArgumentException("Os dados obrigatórios não foram preenchidos!");
                }

                _usuarioRepository.Insert(usuairo);

                return usuairo;
            }
            catch(Exception e)
            {
                throw new Exception("O banco está fora do Ar no Momento! ");
            }
        }
    }
}
