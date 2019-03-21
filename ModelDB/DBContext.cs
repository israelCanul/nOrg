
using Microsoft.EntityFrameworkCore;
using narilearsi.ModelDB;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    { }
    public DbSet<Persons> Persons { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
}