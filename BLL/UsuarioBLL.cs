using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class UsuariosBLL
{
    private Contexto _contexto;

    public UsuariosBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(string nombreUsuario)
    {
        return _contexto.Usuarios
        .Any(o => o.NombreUsuario == nombreUsuario);
    }

    private bool Insertar(Usuarios usuario)
    {
        _contexto.Usuarios.Add(usuario);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Usuarios usuario)
    {
        _contexto.Entry(usuario).State= EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }

    public bool Guardar(Usuarios usuario)
    {
        if(!Existe(usuario.NombreUsuario))
            return this.Insertar(usuario);
        else
            return this.Modificar(usuario);
    }

    public bool Eliminar(Usuarios usuario)
    {
        _contexto.Entry(usuario).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

    public Usuarios? Buscar(string nombreUsuario)
    {
        return _contexto.Usuarios
            .Where(o => o.NombreUsuario == nombreUsuario)
            .AsNoTracking()
            .SingleOrDefault();
    }

    public List<Usuarios> GetList(Expression<Func<Usuarios, bool>> criterio)
    {
        return _contexto.Usuarios
        .AsNoTracking()
        .Where(criterio)
        .ToList();
    }
}