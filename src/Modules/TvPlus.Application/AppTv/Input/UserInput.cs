﻿using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Domain.Entities;

namespace TvPlus.Application.AppTv.Input
{
    public class UserInput
    {


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ProducerInput Producer {get; set;}
        public ActorInput Actor { get; set; }

 





    }
}
