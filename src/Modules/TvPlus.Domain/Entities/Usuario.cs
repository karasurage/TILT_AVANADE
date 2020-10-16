using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string CPF { get; private set; }

        public Usuario(string name, string email, string phone, string cPF )
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Phone = phone;
            CPF = cPF;
        }

     

        public bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email)
                || string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(CPF))
            {
                valid = false;
            }

            return valid;

        }

    }
}
