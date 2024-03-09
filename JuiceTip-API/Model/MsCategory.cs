using System.ComponentModel.DataAnnotations;

namespace JuiceTip_API.Model
{
    public class MsCategory
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string Category { get; set; }
    }
}
