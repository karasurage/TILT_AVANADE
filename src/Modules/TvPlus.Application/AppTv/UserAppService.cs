using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvPlus.Application.AppTv.Input;
using TvPlus.Application.AppTv.Interfaces;
using TvPlus.Domain.Entities;
using TvPlus.Domain.Interfaces.Repositories;

namespace TvPlus.Application.AppTv
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _usuarioRepository;

        public UserAppService(IUserRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<User> Get()
        {
            return _usuarioRepository.Get();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id)
                        .ConfigureAwait(false); 
        }

        public void Insert(UserInput input)
        {
            try
            {
                var usuario = new User(input.FirstName, input.LastName, input.Email,
                    new Actor(input.Actor.ActorGenre, input.Actor.CPF,
                    input.Actor.HourValue), input.Phone);

                if (!usuario.IsValid())
                {
                    throw new ArgumentException("Os dados obrigatórios não foram preenchidos!");
                }

               /*var id =  _usuarioRepository.Insert(usuario);
                usuario.SetId(id);

                return usuario;*/
            }
            catch(Exception e)
            {
                throw new Exception("O banco está fora do Ar no Momento! Erro =" + e);
            }
        }
    }
}
