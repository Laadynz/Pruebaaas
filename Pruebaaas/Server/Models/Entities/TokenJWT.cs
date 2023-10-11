namespace Pruebaaas.Server.Models.Entities
{
    public class TokenJWT
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
