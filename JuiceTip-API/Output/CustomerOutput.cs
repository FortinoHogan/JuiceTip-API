using static JuiceTip_API.Output.AllProductOutput;

namespace JuiceTip_API.Output
{
    public class CustomerOutput
    {
        public class CustomerModel
        {
            public Guid UserId { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string ProfileImage { get; set; }
        }

        public CustomerModel payload { get; set; }

        public CustomerOutput()
        {
            payload = new CustomerModel();
        }
    }
}
