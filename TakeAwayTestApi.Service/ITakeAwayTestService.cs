namespace TakeAwayTestApi.Service;
public interface ITakeAwayTestService
{
    Task<UserData?> GetUserAsync(int userId);

    Task<bool> AddUserAsync(UserData user);

    Task<bool> UpdateUserAsync(UserData user);

    Task DeleteUserAsync(int userId);

    Task<ICollection<SavedListingData>?> GetSavedListingAsync(int userId, int pageNumber, int pageSize);

    Task<bool> AddSavedListingAsync(SavedListingData savedListing);

    Task<bool> UpdateSavedListingAsync(SavedListingData savedListing);

    Task DeleteSavedListingAsync(int listingId, int userId);

    Task<int> GetTotalShortlistedAsync(int propertyId);
}