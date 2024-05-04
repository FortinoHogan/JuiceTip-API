using JuiceTip_API.Model;

namespace JuiceTip_API.Output
{
    public class ProductByIdOutput
    {
        public AllProductModel payload { get; set; }

        public ProductByIdOutput()
        {
            payload = new AllProductModel();
        }
    }
}
