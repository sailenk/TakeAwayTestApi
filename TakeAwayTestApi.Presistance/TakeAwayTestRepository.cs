using Microsoft.EntityFrameworkCore;
using TakeAwayTestApi.Presistance.Models;

public class TakeAwayTestRepository : ITakeAwayTestRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TakeAwayTestRepository(ApplicationDbContext applicationDbContext)
    {
        _dbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
    }

    public async Task<User?> GetUserAsync(int userId)
    {
        User? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        return user;
    }

    public async Task<bool> AddUserAsync(NewUser user)
    {
        if (user != null)
        {
            User newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        User? existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

        if (existingUser != null)
        {
            existingUser.DateUpdated = DateTime.UtcNow;
            existingUser.Email = user.Email;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            _dbContext.Update(existingUser);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public async Task DeleteUserAsync(int userId)
    {
        User? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<SavedListing>?> GetSavedListingAsync(int userId, int pageNumber, int pageSize)
    {
        List<SavedListing> listings = await _dbContext.SavedListings.Where(s => s.UserId == userId).OrderBy(d => d.DateAdded)
                                            .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return listings;
    }

    public async Task<bool> AddSavedListingAsync(NewSavedListing savedListing)
    {
        if (savedListing != null)
        {
            SavedListing newSavedListing = new SavedListing
            {
                UserId = savedListing.UserId,
                ListingId = savedListing.ListingId,
                IsShortListed = savedListing.IsShortListed,
                DateAdded = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            //TODO: check user and listing both exists and check if list not added before

            _dbContext.SavedListings.Add(newSavedListing);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<bool> UpdateSavedListingAsync(SavedListing savedListing)
    {
        SavedListing? listing = await _dbContext.SavedListings.FirstOrDefaultAsync(s => s.UserId == savedListing.UserId && s.ListingId == savedListing.ListingId);
        if (listing != null)
        {
            listing.DateUpdated = DateTime.UtcNow;
            listing.IsShortListed = savedListing.IsShortListed;
            _dbContext.Update(listing);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public async Task DeleteSavedListingAsync(int listingId, int userId)
    {
        SavedListing? listing = await _dbContext.SavedListings.FirstOrDefaultAsync(s => s.UserId == userId && s.ListingId == listingId);
        if (listing != null)
        {
            _dbContext.SavedListings.Remove(listing);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<int> GetTotalShortlistedAsync(int propertyId)
    {
        int totalShortlisted = await _dbContext.SavedListings.CountAsync(l => l.ListingId == propertyId && l.IsShortListed);
        return totalShortlisted;
    }
}