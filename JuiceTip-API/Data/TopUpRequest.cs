using System.ComponentModel.DataAnnotations;

namespace JuiceTip_API.Data
{
    public class TopUpRequest
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public int JuiceCoin { get; set; }
    }
}
