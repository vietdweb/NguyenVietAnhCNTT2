using System.ComponentModel.DataAnnotations;

namespace BVN9_BTTL2.Models;

public class Banner
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public byte Status { get; set; } = 1;

    public int Priority { get; set; }

    [StringLength(100)]
    public string? Image { get; set; }

    [StringLength(350)]
    public string? Description { get; set; }
}
