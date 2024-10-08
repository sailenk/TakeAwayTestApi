using System.ComponentModel.DataAnnotations;
public class UserData
{
    public UserData(int id, string firstName, string lastName, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
}