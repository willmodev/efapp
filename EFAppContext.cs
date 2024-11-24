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
            c.Property( p => p.Peso).HasDefaultValue(0);
        });

        modelBuilder.Entity<Tarea>(t => {
            t.ToTable("Tarea");
            t.HasKey(t => t.TareaId);

            t.Property( p => p.Titulo).HasMaxLength(150).IsRequired();
            t.Property( p => p.Descripcion).HasMaxLength(200);
            t.Property( p => p.Prioridad).HasConversion<string>();
            t.Property( p => p.FechaCreacion).HasDefaultValueSql("getdate()");
            t.Ignore( p => p.Resumen);

            t.HasOne(t => t.Categoria)
                .WithMany(c => c.Tareas)
                .HasForeignKey(t => t.CategoriaId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}