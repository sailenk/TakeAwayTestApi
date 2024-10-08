namespace TakeAwayTestApi.Presistance.Models;

public class NewSavedListing
{
    public NewSavedListing(int listingId, int userId, bool isShortListed)
    {
        ListingId = listingId;
        UserId = userId;
        IsShortListed = isShortListed;
    }

    public int ListingId { get; set; }

    public int UserId { get; set; }

    public bool IsShortListed { get; set; }
}