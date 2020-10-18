using System;

namespace TvPlus.Application.AppTv
{
    internal class UserViewModel
    {
        private int id;
        private string login;
        private string name;
        private Profile profile;
        private DateTime created;
        private Profile profile1;

        public UserViewModel(int id, string login, string name, Profile profile, DateTime created)
        {
            this.id = id;
            this.login = login;
            this.name = name;
            this.profile = profile;
            this.created = created;
        }

        public UserViewModel(int id, string login, string name, Profile profile1, DateTime created)
        {
            this.id = id;
            this.login = login;
            this.name = name;
            this.profile1 = profile1;
            this.created = created;
        }

        public UserViewModel(int id, string login, string name, Profile profile2, DateTime created)
        {
            this.id = id;
            this.login = login;
            this.name = name;
            Profile = profile2;
            this.created = created;
        }

        public UserViewModel(int id, string login, string name, Profile profile2, DateTime created)
        {
            this.id = id;
            this.login = login;
            this.name = name;
            this.created = created;
        }

        public UserViewModel(int id, string login, string name, Profile profile2, DateTime created)
        {
            this.id = id;
            this.login = login;
            this.name = name;
            this.created = created;
        }

        public Profile Profile { get; }
    }
}