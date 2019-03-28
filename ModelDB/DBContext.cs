
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using narilearsi.ModelDB;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    { }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Server= rdsdev.cyizhh2mbeac.us-east-1.rds.amazonaws.com\\SQLEXPRESS,4389;Database=narilearsi;User ID=israelcanul;Password=12345678");
    //}
    public DbSet<Persons> Persons { get; set; }
    public DbSet<EventType> EventType { get; set; }
    public DbSet<Event> Event { get; set; }
    public DbSet<PhotoPackage> PhotoPackage { get; set; }
    public DbSet<ItemPackage> ItemPackage { get; set; }
    public DbSet<Item> Item { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<EventType>()
        //    .HasMany(c => c.Event)
        //    .WithOne(e => e.EventoEventTypeId);


        //modelBuilder.Entity<Event>()
            //.HasOne(c => c.EventoEventTypeId);

    }
}