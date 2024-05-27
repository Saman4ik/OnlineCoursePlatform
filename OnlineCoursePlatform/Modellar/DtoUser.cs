namespace OnlineCoursePlatform.Modellar;

public class DtoUser
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    public static implicit operator DtoUser(User user)
    {
        return new DtoUser
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email
        };
    }
}
