using System.ComponentModel.DataAnnotations;

namespace JuiceTip_API.Data
{
    public class OTP
    {
        public static string Otp { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
