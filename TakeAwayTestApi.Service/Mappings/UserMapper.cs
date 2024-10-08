using TakeAwayTestApi.Presistance.Models;

public static class UserMapper
{
    public static NewUser Map(this UserData user)
    {
        return new NewUser(
            user.FirstName,
            user.LastName,
            user.Email
        );
    }

    public static UserData Map(this User user)
    {
        return new UserData(user.Id, user.FirstName, user.LastName, user.Email);
    }
}