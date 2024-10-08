
namespace TakeAwayTestApi.Presistance.Models;

public interface ITakeAwayTestRepository
{
    Task<User?> GetUserAsync(int userId);

    Task<bool> AddUserAsync(NewUser user);

    Task<bool> UpdateUserAsync(User user);

    Task DeleteUserAsync(int userId);

    Task<IEnumerable<SavedListing>?> GetSavedListingAsync(int userId, int pageNumber, int pageSize);

    Task<bool> AddSavedListingAsync(NewSavedListing savedListing);

    Task<bool> UpdateSavedListingAsync(SavedListing savedListing);

    Task DeleteSavedListingAsync(int listingId, int userId);

    Task<int> GetTotalShortlistedAsync(int propertyId);
}