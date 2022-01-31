namespace GestaoUsuario.Infra.CrossCutting.Model
{
    public class Error
    {
        public Error(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}
