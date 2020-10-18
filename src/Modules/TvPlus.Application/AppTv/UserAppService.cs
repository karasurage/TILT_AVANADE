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

        public User Insert(UserInput input)
        {
            try
            {
                var usuairo = new User(input.FirstName, input.LastName, input.Email, input.Phone);

                if (!usuairo.IsValid())
                {
                    throw new ArgumentException("Os dados obrigatórios não foram preenchidos!");
                }

               var id =  _usuarioRepository.Insert(usuairo);
                usuairo.SetId(id);

                return usuairo;
            }
            catch(Exception e)
            {
                throw new Exception("O banco está fora do Ar no Momento! ");
            }
        }
    }
}
