using System;

namespace GestaoUsuario.App.Model
{
    public class TokenModel
    {
        public string usuario { get; set; }

        public string autenticado { get; set; }

        public string token_access;

        public DateTime expires_in { get; set; }

        public string token_type { get; set; }
    }

    public class TokenErro
    {
        public string error_description { get; set; }
    }
}
