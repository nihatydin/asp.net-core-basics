namespace dotnet_basics.Models;

public class Course
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Image { get; set; }
    public string Description { get; set; } = null!;
    public int Price { get; set; }
    public bool IsActive { get; set; }
}