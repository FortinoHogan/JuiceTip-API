using JuiceTip_API.Model;

namespace JuiceTip_API.Output
{
    public class UserOutput
    {
        public MsUser? payload { get; set; }
        public UserOutput()
        {
            payload = new MsUser();
        }

    }
}
