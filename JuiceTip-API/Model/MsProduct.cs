using System.ComponentModel.DataAnnotations;

namespace JuiceTip_API.Model
{
    public class MsProduct
    {
        [Key]
        public Guid ProductId { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public Guid CategoryId { get; set; }
        public Guid RegionId { get; set; }
        public Guid CustomerId { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public Guid? TransactionId { get; set; }
    }
}
