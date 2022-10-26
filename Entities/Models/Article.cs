namespace Entities.Models;

public class Article
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Journal? Journal { get; set; }
    public Guid JournalId { get; set; }
}
