using EntradasHuacales9.Models;
using Microsoft.EntityFrameworkCore;

namespace EntradasHuacales9.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<EntradasHuacales> EntradasHuacales { get; set; }

    public DbSet<EntradasHuacalesDetalle> entradasHuacalesDetalles { get; set; }

    public DbSet<TiposHuacales> TiposHuacales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TiposHuacales>().HasData(
            new List<TiposHuacales>()
            {
                new()
                {
                    TipoId = 1,
                    Descripcion = "Huacal verde pequeño",
                    Existencia = 0,
                },
                new()
                {
                    TipoId = 2,
                    Descripcion = "Huacal rojo pequeño",
                    Existencia = 0,
                },
                new()
                {
                    TipoId = 3,
                    Descripcion = "Huacal verde mediano",
                    Existencia = 0,
                },
                new()
                {
                    TipoId = 4,
                    Descripcion = "Huacal rojo mediano",
                    Existencia = 0,
                },
                new()
                {
                    TipoId = 5,
                    Descripcion = "Huacal verde Grande",
                    Existencia = 0,
                },
                new()
                {
                    TipoId = 6,
                    Descripcion = "Huacal rojo grande",
                    Existencia = 0,
                }
            }
        );
        base.OnModelCreating(modelBuilder);
    }
}
