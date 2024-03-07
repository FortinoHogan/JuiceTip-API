using System.ComponentModel.DataAnnotations;

namespace JuiceTip_API.Model
{
    public class MsRegion
    {
        [Key]
        public Guid RegionId { get; set; }
        public string Region { get; set; }
        public string RegionImage { get; set; }
    }
}
