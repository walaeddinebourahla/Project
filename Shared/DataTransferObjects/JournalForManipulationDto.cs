using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public class JournalForManipulationDto
{
    [Required]
    [MaxLength(255)]
    public string? Name { get; set; }
    [Required]
    [MaxLength(500)]
    public string? Description { get; set; }
}