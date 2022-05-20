using Microsoft.EntityFrameworkCore;

namespace NationalInstruments
{
    public class TorpedoContext : DbContext
    {
        public DbSet<TorpedoStats> Torpedo { get; set; }
        public DbSet<Game> Game { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder
                    .UseNpgsql(@"Host=localhost;Username=torpedo;Password=torpedo;Database=torpedo");
    }
}
