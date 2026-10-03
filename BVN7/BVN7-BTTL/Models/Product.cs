using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BVN7_BTTL.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [MinLength(6, ErrorMessage = "Tên sản phẩm phải có ít nhất 6 ký tự")]
        [MaxLength(150, ErrorMessage = "Tên sản phẩm không được vượt quá 150 ký tự")]
        public string Name { get; set; }

        [Display(Name = "Ảnh sản phẩm")]
        public string Image { get; set; } = string.Empty;

        [Display(Name = "Giá sản phẩm")]
        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        [Range(100000, float.MaxValue, ErrorMessage = "Giá sản phẩm phải tối thiểu là 100000")]
        public float Price { get; set; }

        [Display(Name = "Giá khuyến mãi")]
        [Required(ErrorMessage = "Giá khuyến mãi không được để trống")]
        [Range(0, float.MaxValue, ErrorMessage = "Giá khuyến mãi phải tối thiểu là 0")]
        public float SalePrice { get; set; }

        [Display(Name = "Mô tả sản phẩm")]
        [Required(ErrorMessage = "Mô tả sản phẩm không được để trống")]
        [MaxLength(1500, ErrorMessage = "Mô tả không được vượt quá 1500 ký tự")]
        public string Description { get; set; }

        public int CategoryId { get; set; }

    }
}
