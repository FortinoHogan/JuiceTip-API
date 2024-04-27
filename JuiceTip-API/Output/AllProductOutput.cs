using JuiceTip_API.Model;

namespace JuiceTip_API.Output
{
    public class AllProductOutput
    {
        //public List<MsProduct> payload { get; set; }
        public class AllProductModel
        {
            public Guid ProductId { get; set; }
            public string ProductImage { get; set; }
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public double ProductPrice { get; set; }
            public Guid CategoryId { get; set; }
            public string CategoryName { get; set; }
            public Guid RegionId { get; set; }
            public string RegionName { get; set; }
            public Guid CustomerId { get; set; }
            public string CustomerName { get; set; }
            public string Notes { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime LastUpdatedAt { get; set; }
        }
        public List<AllProductModel> payload { get; set; }

        public AllProductOutput() 
        {
            payload = new List<AllProductModel>();
        }
    }
}
