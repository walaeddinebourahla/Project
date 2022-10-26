using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public class ArticleForManipulationDto
{
    [Required]
    [MaxLength(255)]
    public string? Name { get; set; }

    [Required]
    [MaxLength(500)]
    public string? Description { get; set; }
}

