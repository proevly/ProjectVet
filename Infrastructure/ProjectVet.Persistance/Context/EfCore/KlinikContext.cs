using Microsoft.EntityFrameworkCore;
using ProjectVet.Models;

namespace ProjectVet.EfCore
{
    public class KlinikContext : DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Pet> Petler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public KlinikContext(DbContextOptions<KlinikContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kullanici>()
                .HasMany(k => k.Petler)
                .WithOne(p => p.Kullanici)
                .HasForeignKey(p => p.KullaniciId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Kullanici>()
                .HasMany(k => k.Randevular)
                .WithOne(r => r.Kullanici)
                .HasForeignKey(r => r.KullaniciId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Pet)
                .WithMany(p => p.Randevular)
                .HasForeignKey(r => r.HayvanId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
