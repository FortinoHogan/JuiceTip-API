namespace JuiceTip_API.Model
{
    public class AllProductModel
    {
        public Guid ProductId { get; set; }
        public List<string> ProductImageList { get; set; }
        public string ProductImage
        {
            get
            {
                return "[\"" + string.Join("\",\"", ProductImageList) + "\"]";
            }
            set
            {
                ProductImageList = value.Split(new char[] { '[', ',', ']' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }
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
        public Guid? TransactionId { get; set; }
    }
}
