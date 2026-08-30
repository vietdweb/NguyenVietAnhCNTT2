namespace NvaLessson3.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt {  get; set; }
    }
}
