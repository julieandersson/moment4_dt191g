using moment4_dt191g.Models;
using Microsoft.EntityFrameworkCore;

namespace moment4_dt191g.Data;

public class SonglistDbContext : DbContext {
    public SonglistDbContext(DbContextOptions<SonglistDbContext> options) : base(options) { } // konstruktor

    // databastabell
    public DbSet<SonglistModel> Songs { get; set; }

}