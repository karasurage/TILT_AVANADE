using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TvPlus.Domain.Entities;
using TvPlus.Domain.Interfaces.Repositories;

namespace TvPlus.Infrastrutucture.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private List<Usuario> usuarios;

        public UsuarioRepository(Usuario usuario)
        {
            usuarios.Add(usuario);
        }
        public IEnumerable<Usuario> Get()
        {
            return usuarios.ToList();
        }

        public Usuario GetById(Guid id)
        {
            return usuarios.Where
                (filter => filter.Id == id).FirstOrDefault();


        }

        public void Insert(Usuario usuario)
        {
            usuarios.Add(usuario);
        }
    }
}
