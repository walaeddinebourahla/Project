namespace Entities.Models;

public class Journal
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Article>? Articles { get; set; }
}
