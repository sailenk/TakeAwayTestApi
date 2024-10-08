
public class SavedListing
{
    public int Id { get; set; }

    public int ListingId { get; set; }

    public int UserId { get; set; }

    public bool IsShortListed { get; set; }

    public DateTime DateAdded { get; set; }

    public DateTime DateUpdated { get; set; }

    public Listing Listing { get; set; }

    public List<User> Users { get; set; }
}