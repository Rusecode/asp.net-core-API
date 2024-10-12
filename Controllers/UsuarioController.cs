using Microsoft.AspNetCore.Mvc;
using BlogUser.Models; // Corrigido para referenciar corretamente o namespace
using BlogUser.Services; // Corrigido para referenciar corretamente o namespace
using System.Collections.Generic; // Adicionado para IEnumerable
using System.Threading.Tasks; // Adicionado para Task

namespace BlogUser.Controllers // Corrigido para referenciar corretamente o namespace
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService; // Corrigido 'oruvate' para 'private'

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService; // Atribuição correta ao campo
        }

        // GET: api/usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.ObterUsuarios(); // Chamada assíncrona
            return Ok(usuarios);
        }

        // GET: api/usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // POST: api/usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] Usuario usuario)
        {
            // Valida se o objeto usuario é nulo ou se o Nome é vazio
            if (usuario == null || string.IsNullOrWhiteSpace(usuario.Nome))
            {
                return BadRequest("Usuário inválido. O nome é obrigatório."); // Retorna erro se o usuário é inválido
            }

            var novoUsuario = await _usuarioService.CriarUsuario(usuario); // Chamada assíncrona
            Console.WriteLine($"Usuário criado: {novoUsuario.Nome}"); // Log no console do servidor

            return CreatedAtAction(nameof(GetUsuario), new { id = novoUsuario.Id }, novoUsuario);
        }
    }
}


