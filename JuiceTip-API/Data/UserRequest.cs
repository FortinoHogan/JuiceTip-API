using System.ComponentModel.DataAnnotations;

namespace JuiceTip_API.Data
{
    public class UserRequest
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
