
public class Listing
{
    public int Id { get; set; }

    public string Address { get; set; }

    public string Suburb { get; set; }

    public string State { get; set; }

    public int Postcode { get; set; }

    public List<SavedListing> SavedListings { get; set; }
}