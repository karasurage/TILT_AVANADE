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
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly ISmartNotification _notification;

        public UserAppService(ISmartNotification notification,
                                IUserRepository userRepository,
                                IProfileRepository profileRepository)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _notification = notification;
        }
        public async Task<UserViewModel> InsertAsync(UserInput input)
        {
            var profile = await _profileRepository
                                    .GetByIdAsync(input.IdProfile)
                                    .ConfigureAwait(false);

            if (profile is null)
            {
                _notification.NewNotificationBadRequest("Perfil associado não existe!");
                return default;
            }

            var user = new User(input.Name, input.Login, input.Password, profile);

            if (!user.IsValid())
            {
                _notification.NewNotificationBadRequest("Dados do usuário são obrigatórios");
                return default;
            }

            var id = await _userRepository
                            .InsertAsync(user)
                            .ConfigureAwait(false);

            return new UserViewModel(id, user.Login, user.Name, user.Profile, user.Created);
        }

        public async Task<UserViewModel> UpdateAsync(int id, UserInput input)
        {
            var user = await _userRepository
                                    .GetByIdAsync(id)
                                    .ConfigureAwait(false);

            if (user is null)
            {
                _notification.NewNotificationBadRequest("Usuário não encontrado");
                return default;
            }

            var profile = await _profileRepository
                                    .GetByIdAsync(input.IdProfile)
                                    .ConfigureAwait(false);

            if (profile is null)
            {
                _notification.NewNotificationBadRequest("Perfil associado não existe!");
                return default;
            }

            user.UpdateInfo(input.Name, input.Password, profile);

            await _userRepository
                    .UpdateAsync(user)
                    .ConfigureAwait(false);

            return new UserViewModel(id, user.Login, user.Name, user.Profile, user.Created);
        }
    }
}