using JuiceTip_API.Model;

namespace JuiceTip_API.Output
{
    public class CategoryOutput
    {
        public List<MsCategory>? payload { get; set; }
        public CategoryOutput()
        {
            payload = new List<MsCategory>();
        }
    }
}
