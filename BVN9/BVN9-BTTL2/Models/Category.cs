using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BVN9_BTTL2.Models;

public class Category
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public byte Status { get; set; } = 1;

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; } = DateTime.Today;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
