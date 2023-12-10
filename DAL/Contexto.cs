using Microsoft.EntityFrameworkCore;

public class Contexto: DbContext
{
    public DbSet<Usuarios> Usuarios { get; set; }
    public Contexto (DbContextOptions <Contexto> options): base (options) 
    {
    }
}