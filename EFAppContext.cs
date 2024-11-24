using efapp.Models;
using Microsoft.EntityFrameworkCore;

namespace efapp;


public class EFAppContext : DbContext {
    public DbSet<Tarea> Tareas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    public EFAppContext(DbContextOptions<EFAppContext> options) : base(options) {}

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    //     optionsBuilder.UseSqlite("Data Source=efapp.db");
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Categoria>(c => {
            c.ToTable("Categoria");
            c.HasKey(c => c.CategoriaId);

            c.Property( p => p.Nombre).HasMaxLength(150).IsRequired();
            c.Property( p => p.Descripcion).HasMaxLength(200);
        });
    }
}