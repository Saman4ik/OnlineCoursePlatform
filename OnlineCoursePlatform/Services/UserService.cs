using OnlineCoursePlatform.Modellar;

namespace OnlineCoursePlatform.Services;

public class UserService
{
    private readonly Func<User, bool> _isAdmin = user => user.IsAdmin;

    public bool CheckIfAdmin(User user)
    {
        return _isAdmin(user);
    }
}