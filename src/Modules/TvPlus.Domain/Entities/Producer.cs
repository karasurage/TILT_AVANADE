using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Domain.Entities
{
    public class Producer
    {
        public string FantasyName { get; private set; }
        public string CNPJ { get; private set; }
        public int FkUser { get; private set; }

        public Producer(string fantasyName, string cNPJ, int fkUser)
        {
            FantasyName = fantasyName;
            CNPJ = cNPJ;
            FkUser = fkUser;
        }

        public Producer(string fantasyName, string cNPJ)
        {
            FantasyName = fantasyName;
            CNPJ = cNPJ;
        }

        public bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(FantasyName) 
                 || string.IsNullOrEmpty(CNPJ) )
               
                
            {
                valid = false;
            }

            return valid;

        }
    }
}
