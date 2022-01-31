using System.Collections.Generic;

namespace GestaoUsuario.Domain.Model
{
    public abstract class ResultadoPaginadoBase
    {
        public int TotalLinha { get; set; }
    }

    public class ResultadoPaginado<T> : ResultadoPaginadoBase where T : class
    {
        public List<T> Linhas { get; set; }

        public ResultadoPaginado()
        {
            Linhas = new List<T>();
        }
    }
}
