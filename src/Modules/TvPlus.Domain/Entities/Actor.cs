namespace TvPlus.Domain.Entities
{
    public class Actor
    {
        public int PkUsuario { get; private set; }
        public string ActorGenre { get; private set; }
        public string CPF { get; private set; }
        public float HourValue { get; private set; }

        /*  Constructor */
        public Actor(string actorGenre, string cpf, float hourValue)
        {
            ActorGenre = actorGenre;
            CPF = cpf;
            HourValue = hourValue;

        }

        public Actor(int pkUsuario, string actorGenre, 
            string cPF, float hourValue)
        {
            PkUsuario = pkUsuario;
            ActorGenre = actorGenre;
            CPF = cPF;
            HourValue = hourValue;
        }


        public bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(ActorGenre) || string.IsNullOrEmpty(CPF) 
                || float.IsNaN(HourValue))
            {
                valid = false;
            }

            return valid;

        }
    }
}
