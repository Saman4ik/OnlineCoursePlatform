using Microsoft.AspNetCore.Routing;
using NUnit.Framework;
using OnlineCoursePlatform.Modellar;

namespace OnlineCoursePlatform.Tests;

[TestFixture]
public class UserTests
{
    private User _user;

    [SetUp]
    public void Setup()
    {
        _user = new User { Username = "testuser", Email = "test@example.com" };
    }

    [Test]
    public void CanCreateUser()
    {
        Assert.AreEqual("testuser", _user.Username);
        Assert.AreEqual("test@example.com", _user.Email);
    }
}