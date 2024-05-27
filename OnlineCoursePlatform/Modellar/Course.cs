namespace OnlineCoursePlatform.Modellar;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string VideoUrl { get; set; } = string.Empty;
    public ICollection<Order> Orders { get; set; }
}

