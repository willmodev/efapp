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

    // protected override void OnModelCreating(ModelBuilder modelBuilder) {
    //     modelBuilder.Entity<Tarea>()
    //         .HasOne(t => t.Categoria)
    //         .WithMany(c => c.Tareas)
    //         .HasForeignKey(t => t.CategoriaId);
    // }
}