using simple_rpg_fighting_simulator.Models;
using Microsoft.EntityFrameworkCore;

namespace simple_rpg_fighting_simulator.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spell>().HasData(
                new Spell { Id = 1, Name = "Fireball", Damage = 30 },
                new Spell { Id = 2, Name = "Frenzy", Damage = 20 },
                new Spell { Id = 3, Name = "Blizzard", Damage = 50 }
            );
        }

        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Weapon> Weapons => Set<Weapon>();
        public DbSet<Spell> Spells => Set<Spell>();
        public DbSet<User> Users => Set<User>();
    }
}