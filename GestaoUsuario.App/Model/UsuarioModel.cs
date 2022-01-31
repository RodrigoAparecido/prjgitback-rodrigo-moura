using System;

namespace GestaoUsuario.App.Model
{
    public class UsuarioModel
    {
        public string Login { get; set; }
        public string PassWord { set; get; }
    }

    public class UsuarioSenhaModel
    {
        public bool SenhaValida { get; set; }
    }


    public class ResultModel
    {
        public string result { get; set; }
    }
}

