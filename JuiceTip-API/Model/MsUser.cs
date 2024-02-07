using System.ComponentModel.DataAnnotations;

namespace JuiceTip_API.Model
{
    public class MsUser
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
    }
}
