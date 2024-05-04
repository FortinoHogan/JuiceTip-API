using JuiceTip_API.Model;

namespace JuiceTip_API.Output
{
    public class AllProductOutput
    {
        //public List<MsProduct> payload { get; set; }
        public List<AllProductModel> payload { get; set; }

        public AllProductOutput()
        {
            payload = new List<AllProductModel>();
        }
    }
}
