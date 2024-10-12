using BlogUser.Data;
using BlogUser.Models;
using Microsoft.EntityFrameworkCore; // Adicione esta linha
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUser.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        // Retorna todos os usuários
        public async Task<IEnumerable<Usuario>> ObterUsuarios()
        {
            return await _context.Usuarios.ToListAsync(); // Aqui deve funcionar agora
        }

        // Retorna um usuário pelo ID (retorno pode ser nulo)
        public async Task<Usuario?> ObterUsuarioPorId(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

public async Task<Usuario> CriarUsuario(Usuario usuario)
{
    await _context.Usuarios.AddAsync(usuario); // Adiciona o usuário ao contexto
    await _context.SaveChangesAsync(); // Salva as mudanças no banco

    // Busque novamente o usuário que foi criado
    var usuarioCriado = await _context.Usuarios.FindAsync(usuario.Id);
    
    return usuarioCriado; // Retorna o usuário criado com todas as propriedades preenchidas
}
      
    }
}



