using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Application.AppTv.Output
{
    class UserViewModel
    {
        {
        public UserViewModel(int id,
                                string login,
                                string nome,
                                Profile profile,
                                DateTime created)
        {
            Id = id;
            Login = login;
            Name = Name;
            Profile = profile;
            Created = created;
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public Profile Profile { get; set; }
        public DateTime Created { get; set; }
    }
}
    }
}
