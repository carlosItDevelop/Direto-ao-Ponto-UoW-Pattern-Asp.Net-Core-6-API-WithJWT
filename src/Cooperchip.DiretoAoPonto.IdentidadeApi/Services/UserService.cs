using Cooperchip.DiretoAoPonto.IdentidadeApi.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Cooperchip.DiretoAoPonto.IdentidadeApi.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task AdicionarClaim(IdentityUser user, string type, string value)
        {
            await _userManager.AddClaimAsync(user, new Claim(type, value));
        }

        public async Task<IdentityUser> ObetrUsuarioPorId(string userId)
        {
            return await Task.FromResult(_userManager.Users.FirstOrDefault(u=>u.Id == userId));
        }

        public async Task<IEnumerable<UserResponseDto>> ObterTodos()
        {
            var usuarios = new List<UserResponseDto>();
            foreach (var user in _userManager.Users)
            {
                var userDto = new UserResponseDto
                {
                    UserId = user.Id,
                    Email = user.Email,
                    EmailConfirmado = user.EmailConfirmed
                };
                usuarios.Add(userDto);
            }
            return await Task.FromResult(usuarios);
        }
    }
}
