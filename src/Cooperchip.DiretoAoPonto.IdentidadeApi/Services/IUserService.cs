using Cooperchip.DiretoAoPonto.IdentidadeApi.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Cooperchip.DiretoAoPonto.IdentidadeApi.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> ObterTodos();
        Task<IdentityUser> ObetrUsuarioPorId(string userId);
        Task  AdicionarClaim(IdentityUser user, string type, string value);
    }
}
