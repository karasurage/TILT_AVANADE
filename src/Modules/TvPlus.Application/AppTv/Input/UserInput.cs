using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Application.AppTv.Input
{
    public class UserInput
    {
        
        public string FirstName { get;  set; }
        public string LastName { get; set; }    
        public string Email { get;  set; }
        public string Phone { get;  set; }
        public int IdProfile { get; internal set; }
        public string Password { get; internal set; }
        public string Login { get; internal set; }
        public string Name { get; internal set; }
    }
}
