using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<SavedListing> SavedListings { get; set; }

    public DbSet<Listing> Listings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=TakeAwayTest.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Listing>().HasMany(s => s.SavedListings).WithOne(l => l.Listing).HasForeignKey(l => l.ListingId);

        modelBuilder.Entity<User>().HasMany(s => s.SavedListings).WithMany(u => u.Users).UsingEntity(t => t.ToTable("UserSavedListings"));
    }

    public async Task Init()
    {
        await InitListingTable();
    }

    private async Task InitListingTable()
    {
        using var context = new ApplicationDbContext();
        context.Database.EnsureCreated();

        if (!context.Listings.Any())
        {
            _ = context.Listings.AddRangeAsync(
                new Listing { Address = "100 Harris Street", Postcode = 2009, State = "NSW", Suburb = "Pyrmont" },
                new Listing { Address = "600 Church Street", Postcode = 3121, State = "VIC", Suburb = "Cremorne" },
                new Listing { Address = "757 Ann Street", Postcode = 4006, State = "QLD", Suburb = "Fortitude Valley" },
                new Listing { Address = "67 Eyre Street", Postcode = 2604, State = "ACT", Suburb = "Kingston" },
                new Listing { Address = "185 Grote Street", Postcode = 5000, State = "SA", Suburb = "Adelaide" },
                new Listing { Address = "29 Station Street", Postcode = 6008, State = "WA", Suburb = "Subiaco" }
            );
            await context.SaveChangesAsync();
        }
    }
}