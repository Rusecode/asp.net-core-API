using BlogUser.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> ObterUsuarios();
    Task<Usuario?> ObterUsuarioPorId(int id);
    Task<Usuario> CriarUsuario(Usuario usuario);
}

