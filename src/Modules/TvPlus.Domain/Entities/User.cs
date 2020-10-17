using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string CPF { get; private set; }
        public DateTime Date { get; private set; }

        public User(int id, string name, string email,
            string phone, string cPF, DateTime date) 
        {
            SetId(id);
            Name = name;
            Email = email;
            Phone = phone;
            CPF = cPF;
            Date = date;

        }
        public User(string name, string email, string phone, string cPF )
        {
            
            Name = name;
            Email = email;
            Phone = phone;
            CPF = cPF;
            Date = DateTime.Now;
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

        public void SetId(int id)
        {
            Id = id;
        }

     

    }
}
