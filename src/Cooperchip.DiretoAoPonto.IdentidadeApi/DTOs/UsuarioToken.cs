namespace Cooperchip.DiretoAoPonto.IdentidadeApi.DTOs
{
    public class UsuarioToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UsuarioClaim> Claims { get; set; }

    }

}
