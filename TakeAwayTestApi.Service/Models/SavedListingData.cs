using System.ComponentModel.DataAnnotations;

public class SavedListingData
{
    public SavedListingData(int listingId, int userId, bool isShortListed)
    {
        ListingId = listingId;
        UserId = userId;
        IsShortListed = isShortListed;
    }

    [Required]
    public int ListingId { get; set; }

    [Required]
    public int UserId { get; set; }

    public bool IsShortListed { get; set; }
}