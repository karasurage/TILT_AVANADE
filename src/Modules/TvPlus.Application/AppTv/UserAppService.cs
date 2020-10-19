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

        /*Get de User*/
        public IEnumerable<User> Get()
        {
            return _usuarioRepository.Get();
        }

        /*Get de User com Id*/
        public async Task<User> GetByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id)
                        .ConfigureAwait(false); 
        }


        /* Input de User    */
        public void Insert(UserInput input)
        {
            try
            {
                var usuario = new User();
                if (input.Actor != null)
                {
                     usuario = new User(input.FirstName, input.LastName, input.Email,
                        new Actor(input.Actor.ActorGenre, input.Actor.CPF,
                        input.Actor.HourValue), input.Phone);

                        if (!usuario.IsValid())
                        {
                            throw new ArgumentException("Os dados obrigatórios não foram preenchidos!");
                        }

                    _usuarioRepository.Insert(usuario);
                }
                else
                {
                     usuario = new User(input.FirstName, input.LastName, input.Email,
                     new Producer(input.Producer.FantasyName, input.Producer.CNPJ), input.Phone);

                        if (!usuario.IsValidP())
                         {
                        throw new ArgumentException("Os dados obrigatórios não foram preenchidos!");
                        }

                    _usuarioRepository.InsertP(usuario);

                }

                

              
                 /*usuario.SetId(id);*/

                 /*return usuario;*/
            }
            catch(Exception e)
            {
                throw new Exception("O banco está fora do Ar no Momento! Erro =" + e);
            }
        }
    }
}
