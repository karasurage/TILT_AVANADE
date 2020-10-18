using System;
using System.ComponentModel;

namespace TvPlus.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public Actor Actor { get; private set; }
        public string Phone { get; private set; }
        public DateTime Date { get; private set; }

        /*  Constructor */
        public User(int id, string firstname, string lastName, string email,
            Actor actor ,string phone, DateTime data) 
        {
            SetId(id);
            FirstName = firstname;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Actor = actor;
            Date = data;

        }
        public User(string firstname, string lastName, string email,
            Actor actor, string phone)
        {

            FirstName = firstname;
            LastName = lastName;
            Email = email;
            Actor = actor;
            Phone = phone;
            Date = DateTime.Now;
        }


        /*Method Custom*/

        public bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName)|| string.IsNullOrEmpty(Email)
                || string.IsNullOrEmpty(Phone) || !Actor.IsValid() )
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
