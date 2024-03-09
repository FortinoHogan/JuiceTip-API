using System.ComponentModel.DataAnnotations;

namespace JuiceTip_API.Model
{
    public class MsUser
    {
        [Key]
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string? ProfileImage { get; set; }
        public string Gender { get; set; }
        public double JuiceCoin { get; set; }
        public DateTime Created { get; set; }
        public DateTime DOB { get; set; }
        public Guid? ReviewId { get; set; }
    }
}
