using System.ComponentModel.DataAnnotations;

namespace BVN7_BTTL.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        public string Name { get; set; }
    }
}
