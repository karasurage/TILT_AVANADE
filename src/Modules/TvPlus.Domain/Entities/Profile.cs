using System;
using System.Collections.Generic;
using System.Text;


namespace TvPlus.Domain.Entities
{
    class Profile
    {
        public Profile(string description)
        {
            Description = description;
        }

        public Profile(int id,
                        string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
    }
}
