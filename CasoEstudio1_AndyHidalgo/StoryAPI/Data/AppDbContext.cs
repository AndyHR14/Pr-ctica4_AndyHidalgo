using Microsoft.EntityFrameworkCore;
using StoryAPI.Models;

namespace StoryAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<UserStory> UserStory { get; set; } = null!;
        public DbSet<Usuario> Usuario { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserStory>().HasKey(UserStory => UserStory.Id);
            modelBuilder.Entity<Usuario>().HasKey(Usuario => Usuario.Id);

            modelBuilder.Entity<UserStory>(entity =>
            {
                entity.HasOne(us => us.Usuario)
                      .WithMany(u => u.UserStory)
                      .HasForeignKey(us => us.UsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}