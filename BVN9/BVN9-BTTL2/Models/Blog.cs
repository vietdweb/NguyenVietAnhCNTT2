using System.ComponentModel.DataAnnotations;

namespace BVN9_BTTL2.Models;

public class Blog
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public byte Status { get; set; } = 1;

    public DateTime CreatedDate { get; set; } = DateTime.Today;
}
