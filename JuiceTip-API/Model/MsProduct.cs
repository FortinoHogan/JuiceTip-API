using System.ComponentModel.DataAnnotations;

namespace JuiceTip_API.Model
{
    public class MsProduct
    {
        [Key]
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public Guid RegionId { get; set; }
        public Guid CustomerId { get; set; }
        public string Notes { get; set; }
        public Guid ProductTypeId { get; set; }
    }
}
