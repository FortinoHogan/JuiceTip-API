using JuiceTip_API.Model;

namespace JuiceTip_API.Output
{
    public class ProductOutput
    {
        public MsProduct? payload { get; set; }
        public ProductOutput()
        {
            payload = new MsProduct();
        }
    }
}
