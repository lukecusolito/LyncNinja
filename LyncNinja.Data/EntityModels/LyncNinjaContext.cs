using Microsoft.EntityFrameworkCore;

namespace LyncNinja.Data.EntityModels
{
    public class LyncNinjaContext : DbContext
    {
        public LyncNinjaContext(DbContextOptions<LyncNinjaContext> options) : base(options) { }

        public DbSet<LinkedResource> LinkedResources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User
            modelBuilder.Entity<LinkedResource>(entity =>
            {
                entity
                    .HasKey(x => x.UID);

                entity
                    .HasIndex(x => x.Url)
                    .IsUnique();

                entity
                    .Property(x => x.Created)
                    .HasDefaultValueSql("getutcdate()");
            });
            #endregion
        }
    }
}
