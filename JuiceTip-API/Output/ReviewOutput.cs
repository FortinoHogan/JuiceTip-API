using static JuiceTip_API.Output.ProductProgressOutput;

namespace JuiceTip_API.Output
{
    public class ReviewOutput
    {
        public class ReviewModel
        {
            public string CustomerName { get; set; }
            public int Rating { get; set; }
            public string Comment { get; set; }
            public DateTime ReviewDate { get; set; }
        }

        public List<ReviewModel> payload { get; set; }
        public ReviewOutput()
        {
            payload = new List<ReviewModel>();
        }
    }
}
