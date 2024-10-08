using TakeAwayTestApi.Presistance.Models;

public static class SavedListingMapper
{
    public static NewSavedListing Map(this SavedListingData savedListing)
    {
        return new NewSavedListing(savedListing.ListingId, savedListing.UserId, savedListing.IsShortListed);
    }

    public static SavedListingData Map(this SavedListing savedListing)
    {
        return new SavedListingData(savedListing.ListingId, savedListing.UserId, savedListing.IsShortListed);
    }
}