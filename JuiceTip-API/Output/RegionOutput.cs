using JuiceTip_API.Model;

namespace JuiceTip_API.Output
{
    public class RegionOutput
    {
        public List<MsRegion>? payload { get; set; }
        public RegionOutput()
        {
            payload = new List<MsRegion>();
        }
    }
}
