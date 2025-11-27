using AnimeListLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeListLibrary.Models
{
    public class AnimeContext : DbContext
    {
        public AnimeContext(DbContextOptions<AnimeContext> options) : base(options) { }

        public DbSet<AnimeItem> AnimeItems { get; set; } = null!;
    }
}
