using TakeAwayTestApi.Presistance.Models;

namespace TakeAwayTestApi.Service;

public class TakeAwayTestSerivce : ITakeAwayTestService
{
    private readonly ITakeAwayTestRepository _repository;

    public TakeAwayTestSerivce(ITakeAwayTestRepository takeAwayTestRepository)
    {
        _repository = takeAwayTestRepository ?? throw new ArgumentNullException(nameof(takeAwayTestRepository));
    }

    public async Task<UserData?> GetUserAsync(int userId)
    {
        try
        {
            User user = await _repository.GetUserAsync(userId);
            if (user != null)
            {
                return user.Map();
            }
        }
        catch (Exception exception)
        {
            //TODO - log the exception
        }

        return null;
    }

    public async Task<bool> AddUserAsync(UserData user)
    {
        try
        {
            bool result = await _repository.AddUserAsync(user.Map());
            return result;
        }
        catch (Exception exception)
        {
            //TODO - log the exception
        }

        return false;
    }

    public async Task<bool> UpdateUserAsync(UserData user)
    {
        try
        {
            User updateUser = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            bool result = await _repository.UpdateUserAsync(updateUser);
            return result;
        }
        catch (Exception exception)
        {
            //TODO - log the exception
        }

        return false;
    }

    public async Task DeleteUserAsync(int userId)
    {
        await _repository.DeleteUserAsync(userId);
    }

    public async Task<ICollection<SavedListingData>?> GetSavedListingAsync(int userId, int pageNumber, int pageSize)
    {
        try
        {
            IEnumerable<SavedListing> savedListings = await _repository.GetSavedListingAsync(userId, pageNumber, pageSize);

            if (savedListings.Any())
            {
                return (List<SavedListingData>)([
                    .. from savedListing in savedListings
                           select savedListing.Map(),
                    ]);
            }
        }
        catch (Exception exception)
        {
            //TODO - log the exception
        }

        return null;
    }

    public async Task<bool> AddSavedListingAsync(SavedListingData savedListing)
    {
        try
        {
            NewSavedListing saveListing = new NewSavedListing(
                savedListing.ListingId,
                savedListing.UserId,
                savedListing.IsShortListed
            );

            return await _repository.AddSavedListingAsync(saveListing);
        }
        catch (Exception exception)
        {
            //TODO - log the exception
        }

        return false;
    }

    public async Task<bool> UpdateSavedListingAsync(SavedListingData savedListing)
    {
        try
        {
            SavedListing updateSaveListing = new SavedListing
            {
                ListingId = savedListing.ListingId,
                UserId = savedListing.UserId,
                IsShortListed = savedListing.IsShortListed
            };

            return await _repository.UpdateSavedListingAsync(updateSaveListing);
        }
        catch (Exception exception)
        {
            //TODO - log the exception
        }

        return false;
    }

    public async Task DeleteSavedListingAsync(int listingId, int userId)
    {
        await _repository.DeleteSavedListingAsync(listingId, userId);
    }

    public async Task<int> GetTotalShortlistedAsync(int propertyId)
    {
        int count = await _repository.GetTotalShortlistedAsync(propertyId);
        return count;
    }
}
