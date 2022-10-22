using Cooperchip.DiretoAoPonto.IdentidadeApi.DTOs;
using Cooperchip.DiretoAoPonto.IdentidadeApi.Services;
using Cooperchip.DiretoAoPonto.WebApiCore.Controllers;
using Cooperchip.DiretoAoPonto.WebApiCore.Identidade.FiltterAuthorizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.DiretoAoPonto.IdentidadeApi.Controllers
{
    [Authorize]
    [Route("api/useradmin")]
    public class UserAdminController : MainController
    {
        private readonly IUserService _userService;

        public UserAdminController(IUserService userService)
        {
            _userService = userService;
        }

        [ClaimsAuthorize("Usuarios", "Listar")]
        [HttpGet("listar-usuarios")]
        public async Task<IActionResult> ObterUsuarios()
        {
            var userResponse = await _userService.ObterTodos();
            if(userResponse == null) return NotFound("Nenhum usuário encontrado!");

            return Ok(userResponse);
        }

        [ClaimsAuthorize("Claim", "Adicionar")]
        [HttpPost("adicionar-claim")]
        public async Task<IActionResult> AdicionarClaim(string userId, string type, string value)
        {
            var usuario = await _userService.ObetrUsuarioPorId(userId);
            if (usuario == null) return NotFound("usuário não encontrado");

            await _userService.AdicionarClaim(usuario, type, value);
            var userDto = new UserResponseDto
            {
                UserId = userId,
                Email = usuario.Email,
                EmailConfirmado = usuario.EmailConfirmed
            };
            return Ok(userDto);
        }

    }
}
