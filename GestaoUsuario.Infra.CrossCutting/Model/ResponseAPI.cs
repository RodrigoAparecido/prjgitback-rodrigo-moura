using GestaoUsuario.Domain.Interface.InfraService;

namespace GestaoUsuario.Infra.CrossCutting.Model
{
    public class ResponseAPI : IResponseAPI
    {
        public ResponseAPI() { }

        public ResponseAPI(int statusCode, string request, string response)
        {
            StatusCode = statusCode;
            Request = request;
            Response = response;
        }

        public int StatusCode { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
    }
}
