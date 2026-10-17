using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BVN9_BTTL2.Models;

public class Product
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(0, double.MaxValue)]
    [Column(TypeName = "float")]
    public double Price { get; set; }

    [Range(0, double.MaxValue)]
    [Column(TypeName = "float")]
    public double SalePrice { get; set; }

    public byte Status { get; set; } = 1;

    [Required]
    public int CategoryId { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Today;

    [StringLength(100)]
    public string? Image { get; set; }

    [StringLength(350)]
    public string? Description { get; set; }

    public Category? Category { get; set; }
}
