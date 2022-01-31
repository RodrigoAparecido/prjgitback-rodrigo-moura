using System;

#nullable disable

namespace GestaoUsuario.Infra.Data
{
    public partial class Usuario
    {
        public Usuario()
        {
 
        }

        public long ID { get; set; }
        public string Login { get; set; }
        public string PassWord { set; get; }

        public DateTime DataInclusao = DateTime.Now;
   
    }
}
