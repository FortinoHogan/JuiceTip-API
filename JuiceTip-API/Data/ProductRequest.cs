using System.ComponentModel.DataAnnotations;

namespace JuiceTip_API.Data
{
    public class ProductRequest
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        public string ProductImage { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public float ProductPrice { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        public string Notes { get; set; }
    }
}
